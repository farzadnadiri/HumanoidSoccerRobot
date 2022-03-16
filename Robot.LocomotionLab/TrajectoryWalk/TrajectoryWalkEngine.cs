using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Robot.Environment;
using Robot.Environment.Interface;
using Robot.Probabilistics.Filter;
using Robot.Utils;
using Robot.Utils.Interface;
using Math = System.Math;
using Thread = Robot.Utils.Thread;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class TrajectoryWalkEngine : IStorable
    {

        private enum Phase
        {
            Phase0 = 0,
            Phase1 = 1,
            Phase2 = 2,
            Phase3 = 3
        };

        public bool Enable
        {
            get { return _walkEngineCallBackThread.IsEnable; }
        }

        public Step WalkOffset;

        public double _mPeriodTime;
        double _mDspRatio;
        double _mSspRatio;
        double _mXSwapPeriodTime;
        double _mXMovePeriodTime;
        double _mYSwapPeriodTime;
        double _mYMovePeriodTime;
        double _mZSwapPeriodTime;
        double _mZMovePeriodTime;
        double _mAMovePeriodTime;
        double _mSspTime;
        double _mSspTimeStartL;
        double _mSspTimeEndL;
        double _mSspTimeStartR;
        double _mSspTimeEndR;
        double _mPhaseTime1;
        double _mPhaseTime2;
        double _mPhaseTime3;

        double _mXOffset;
        double _mYOffset;
        double _mZOffset;
        double _mROffset;
        double _mPOffset;
        double _mAOffset;

        double _mXSwapPhaseShift;
        double _mXSwapAmplitude;
        double _mXSwapAmplitudeShift;
        double _mXMovePhaseShift;
        double _mXMoveAmplitude;
        double _mXMoveAmplitudeShift;
        double _mYSwapPhaseShift;
        double _mYSwapAmplitude;
        double _mYSwapAmplitudeShift;
        double _mYMovePhaseShift;
        double _mYMoveAmplitude;
        double _mYMoveAmplitudeShift;
        double _mZSwapPhaseShift;
        double _mZSwapAmplitude;
        double _mZSwapAmplitudeShift;
        double _mZMovePhaseShift;
        double _mZMoveAmplitude;
        double _mZMoveAmplitudeShift;
        double _mAMovePhaseShift;
        double _mAMoveAmplitude;
        double _mAMoveAmplitudeShift;

        public double PelvisOffset
        {
            get;
            set;
        }

        double _mPelvisSwing;
        double _mArmSwingGain;

        public bool ControlRunning
        {
            set;
            get;
        }

        public bool MRealRunning
        {
            set;
            get;
        }
        double _mTime;

        int _mPhase;
        double _mBodySwingY;
        double _mBodySwingZ;

        // Walking initial pose
        public double XOffset
        {
            set;
            get;
        }

        public double YOffset
        {
            set;
            get;
        }

        public double ZOffset
        {
            set;
            get;
        }

        public double AOffset
        {
            set;
            get;
        }

        public double PitchOffset
        {
            set;
            get;
        }

        public double ROllOffset
        {
            set;
            get;
        }

        public double PeriodTime { set; get; }
        public double MaxPeriodTime { set; get; }

        public int TimeUnit
        {
            set
            {
                _walkEngineCallBackThread.Interval = value;
            }
            get
            {
                return _walkEngineCallBackThread.Interval;
            }
        }

        public double DoubleStancePeriodRatio
        {
            set;
            get;
        }

        public double StepForwardBackwardRatio
        {
            set;
            get;
        }

        public double XMoveAmplitude
        {
            set;
            get;
        }

        public double YMoveAmplitude
        {
            set;
            get;
        }

        public double ZMoveAmplitude
        {
            set;
            get;
        }

        public double AMoveAmplitude
        {
            set;
            get;
        }

        public bool AMoveAimOn
        {
            set;
            get;
        }


        public double YSwapAmplitude
        {
            set;
            get;
        }

        public double ZSwapAmplitude
        {
            set;
            get;
        }

        public double ArmSwingGain
        {
            set;
            get;
        }

        public double HipPitchOffset
        {
            set;
            get;
        }

        private readonly Thread _walkEngineCallBackThread;
        private IBody _body;

        private Controll _controllUnit;
        private Kinematics _inverseKinematics;
        public TrajectoryWalkEngine(IBody body, Controll controllUnit, string configurationPath)
        {
            _controllUnit = controllUnit;
            _inverseKinematics = new Kinematics(body);


            _body = body;

            WalkOffset = new Step(_body.Joints.Count, 1);
            _walkEngineCallBackThread = new Thread(Process, ThreadPriority.Highest, 8);


            Load(configurationPath);

            AMoveAimOn = false;
            MaxPeriodTime = PeriodTime;

            _mBodySwingY = 0;
            _mBodySwingZ = 0;

            _mXSwapPhaseShift = Math.PI;
            _mXSwapAmplitudeShift = 0;
            _mXMovePhaseShift = Math.PI / 2;
            _mXMoveAmplitudeShift = 0;
            _mYSwapPhaseShift = 0;
            _mYSwapAmplitudeShift = 0;
            _mYMovePhaseShift = Math.PI / 2;
            _mZSwapPhaseShift = Math.PI * 3 / 2;
            _mZMovePhaseShift = Math.PI / 2;
            _mAMovePhaseShift = Math.PI / 2;

            ControlRunning = true;
            MRealRunning = true;

            _mTime = 0;
            update_param_time();
            update_param_move();

        }

        public void WalkStart()
        {
            ControlRunning = true;
            MRealRunning = true;
            AMoveAimOn = true;
            NoWrite = false;
            _walkEngineCallBackThread.Start();
        }

        public bool NoWrite;

        public void WalkStop(bool justStand)
        {
            ControlRunning = false;
            JustStand = justStand;
        }

        public void ForceStop()
        {
            NoWrite = true;
        }

        public double Wsin(double time, double period, double periodShift, double mag, double magShift)
        {
            return mag * Math.Sin(2 * Math.PI / period * time - periodShift) + magShift;
        }

        public void update_param_time()
        {
            _mPeriodTime = PeriodTime;
            _mDspRatio = DoubleStancePeriodRatio;
            _mSspRatio = 1 - DoubleStancePeriodRatio;

            _mXSwapPeriodTime = _mPeriodTime / 2;
            _mXMovePeriodTime = _mPeriodTime * _mSspRatio;
            _mYSwapPeriodTime = _mPeriodTime;
            _mYMovePeriodTime = _mPeriodTime * _mSspRatio;
            _mZSwapPeriodTime = _mPeriodTime / 2;
            _mZMovePeriodTime = _mPeriodTime * _mSspRatio / 2;
            _mAMovePeriodTime = _mPeriodTime * _mSspRatio;

            _mSspTime = _mPeriodTime * _mSspRatio;
            _mSspTimeStartL = (1 - _mSspRatio) * _mPeriodTime / 4;
            _mSspTimeEndL = (1 + _mSspRatio) * _mPeriodTime / 4;
            _mSspTimeStartR = (3 - _mSspRatio) * _mPeriodTime / 4;
            _mSspTimeEndR = (3 + _mSspRatio) * _mPeriodTime / 4;

            _mPhaseTime1 = (_mSspTimeEndL + _mSspTimeStartL) / 2;
            _mPhaseTime2 = (_mSspTimeStartR + _mSspTimeEndL) / 2;
            _mPhaseTime3 = (_mSspTimeEndR + _mSspTimeStartR) / 2;

            //m_Pelvis_Offset = PELVIS_OFFSET*MX28::RATIO_ANGLE2VALUE; <========HERE========>
            _mPelvisSwing = PelvisOffset * 0.35;
            _mArmSwingGain = ArmSwingGain;
        }

        private void update_param_move()
        {
            // Forward/Back
            _mXMoveAmplitude = XMoveAmplitude;
            _mXSwapAmplitude = XMoveAmplitude * StepForwardBackwardRatio;

            // Right/Left
            _mYMoveAmplitude = YMoveAmplitude / 2;
            if (_mYMoveAmplitude > 0)
                _mYMoveAmplitudeShift = _mYMoveAmplitude;
            else
                _mYMoveAmplitudeShift = -_mYMoveAmplitude;
            _mYSwapAmplitude = YSwapAmplitude + _mYMoveAmplitudeShift * 0.04;

            _mZMoveAmplitude = ZMoveAmplitude / 2;
            _mZMoveAmplitudeShift = _mZMoveAmplitude / 2;
            _mZSwapAmplitude = ZSwapAmplitude;
            _mZSwapAmplitudeShift = _mZSwapAmplitude;

            // Direction
            if (AMoveAimOn == false)
            {
                _mAMoveAmplitude = AMoveAmplitude * Math.PI / 180.0 / 2;
                if (_mAMoveAmplitude > 0)
                    _mAMoveAmplitudeShift = _mAMoveAmplitude;
                else
                    _mAMoveAmplitudeShift = -_mAMoveAmplitude;
            }
            else
            {
                _mAMoveAmplitude = -AMoveAmplitude * Math.PI / 180.0 / 2;
                if (_mAMoveAmplitude > 0)
                    _mAMoveAmplitudeShift = -_mAMoveAmplitude;
                else
                    _mAMoveAmplitudeShift = _mAMoveAmplitude;
            }
        }


        public PID PIDGyro = new PID();

        private void update_param_balance()
        {
            if (StabilizationEnable)
            {
                //PitchOffset = _controllUnit._newControl.GyroError * PitchOffsetGain;

                //XOffset = _controllUnit.PitchZeroOffset * XOffsetGain;

                //var AccelOut = PIDAccel.Calculate(_controllUnit.PitchZero, _controllUnit.ActualPitch, _walkEngineCallBackThread.Interval);
                //var GyroOut = PIDGyro.Calculate(_controllUnit.PreviousGyroPitch, _controllUnit.ActualGyroPitch, _walkEngineCallBackThread.Interval);

                //XOffset = AccelOut * AccelGain;//; GyroOut * HandPitchGain;
                //PitchOffset = GyroOut * GyroGain;
                // OKEY // _controllUnit._newControl.GyroError


                var GyroOut = PIDGyro.Calculate(_controllUnit.PreviousGyroPitch, _controllUnit.ActualGyroPitch, _walkEngineCallBackThread.Interval);
                var anklePitchGyro = -1 * _controllUnit.GyroAnklePitchLowPass.Apply(GyroOut);

                PitchOffset = anklePitchGyro;

            }

            _mXOffset = XOffset;
            _mYOffset = YOffset;
            _mZOffset = ZOffset;
            _mROffset = ROllOffset * Math.PI / 180.0;
            _mPOffset = PitchOffset * Math.PI / 180.0;
            _mAOffset = AOffset * Math.PI / 180.0;
            //m_Hip_Pitch_Offset = HIP_PITCH_OFFSET*MX28::RATIO_ANGLE2VALUE; <========HERE========>
        }

        double _xSwap, _ySwap, _zSwap, _aSwap, _bSwap, _cSwap;
        double _xMoveR, _yMoveR, _zMoveR, _aMoveR, _bMoveR, _cMoveR;
        double _xMoveL, _yMoveL, _zMoveL, _aMoveL, _bMoveL, _cMoveL;
        double _pelvisOffsetR, _pelvisOffsetL;

        double _offset;
        private double _timeUnit;

        double[] _angle = new double[14];
        double[] _ep = new double[12];
        private double[] _outValue;

        //                     R_HIP_YAW, R_HIP_ROLL, R_HIP_PITCH, R_KNEE, R_ANKLE_PITCH, R_ANKLE_ROLL, L_HIP_YAW, L_HIP_ROLL, L_HIP_PITCH, L_KNEE, L_ANKLE_PITCH, L_ANKLE_ROLL, R_ARM_SWING, L_ARM_SWING
        public int[] Dir;

        private double timeUnit;


        public bool JustStand { set; get; }
        public void Process()
        {

            _angle = new double[14];
            _ep = new double[12];

            _timeUnit = TimeUnit;

            _outValue = new double[14];

            // Update walk parameters
            if (_mTime == 0)
            {
                update_param_time();
                _mPhase = (int)Phase.Phase0;
                if (ControlRunning == false)
                {
                    if (_mXMoveAmplitude == 0 && _mYMoveAmplitude == 0 && _mAMoveAmplitude == 0)
                    {
                        MRealRunning = false;

                        if (!JustStand)
                        {
                            _walkEngineCallBackThread.Stop(true, false);
                        }
                    }
                    else
                    {
                        XMoveAmplitude = 0;
                        YMoveAmplitude = 0;
                        AMoveAmplitude = 0;
                    }
                }
            }

            else if (_mTime >= (_mPhaseTime1 - _timeUnit / 2) && _mTime < (_mPhaseTime1 + _timeUnit / 2))
            {
                update_param_move();
                _mPhase = (int)Phase.Phase1;
            }
            else if (_mTime >= (_mPhaseTime2 - _timeUnit / 2) && _mTime < (_mPhaseTime2 + _timeUnit / 2))
            {
                update_param_time();
                _mTime = _mPhaseTime2;
                _mPhase = (int)Phase.Phase2;
                if (ControlRunning == false)
                {
                    if (_mXMoveAmplitude == 0 && _mYMoveAmplitude == 0 && _mAMoveAmplitude == 0)
                    {
                        MRealRunning = false;
                        if (!JustStand)
                        {
                            _walkEngineCallBackThread.Stop(true, false);
                        }
                    }
                    else
                    {
                        XMoveAmplitude = 0;
                        YMoveAmplitude = 0;
                        AMoveAmplitude = 0;
                    }
                }
            }

            else if (_mTime >= (_mPhaseTime3 - _timeUnit / 2) && _mTime < (_mPhaseTime3 + _timeUnit / 2))
            {
                update_param_move();
                _mPhase = (int)Phase.Phase3;
            }
            update_param_balance();

            // Compute endpoints
            _xSwap = Wsin(_mTime, _mXSwapPeriodTime, _mXSwapPhaseShift, _mXSwapAmplitude,
                _mXSwapAmplitudeShift);
            _ySwap = Wsin(_mTime, _mYSwapPeriodTime, _mYSwapPhaseShift, _mYSwapAmplitude,
                _mYSwapAmplitudeShift);
            _zSwap = Wsin(_mTime, _mZSwapPeriodTime, _mZSwapPhaseShift, _mZSwapAmplitude,
                _mZSwapAmplitudeShift);
            _aSwap = 0;
            _bSwap = 0;
            _cSwap = 0;

            if (_mTime <= _mSspTimeStartL)
            {
                _xMoveL = Wsin(_mSspTimeStartL, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartL, _mXMoveAmplitude,
                    _mXMoveAmplitudeShift);
                _yMoveL = Wsin(_mSspTimeStartL, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartL, _mYMoveAmplitude,
                    _mYMoveAmplitudeShift);
                _zMoveL = Wsin(_mSspTimeStartL, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveL = Wsin(_mSspTimeStartL, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartL, _mAMoveAmplitude,
                    _mAMoveAmplitudeShift);
                _xMoveR = Wsin(_mSspTimeStartL, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartL, -_mXMoveAmplitude,
                    -_mXMoveAmplitudeShift);
                _yMoveR = Wsin(_mSspTimeStartL, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartL, -_mYMoveAmplitude,
                    -_mYMoveAmplitudeShift);
                _zMoveR = Wsin(_mSspTimeStartR, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveR = Wsin(_mSspTimeStartL, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartL, -_mAMoveAmplitude,
                    -_mAMoveAmplitudeShift);
                _pelvisOffsetL = 0;
                _pelvisOffsetR = 0;
            }
            else if (_mTime <= _mSspTimeEndL)
            {
                _xMoveL = Wsin(_mTime, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartL, _mXMoveAmplitude,
                    _mXMoveAmplitudeShift);
                _yMoveL = Wsin(_mTime, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartL, _mYMoveAmplitude,
                    _mYMoveAmplitudeShift);
                _zMoveL = Wsin(_mTime, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveL = Wsin(_mTime, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartL, _mAMoveAmplitude,
                    _mAMoveAmplitudeShift);
                _xMoveR = Wsin(_mTime, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartL, -_mXMoveAmplitude,
                    -_mXMoveAmplitudeShift);
                _yMoveR = Wsin(_mTime, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartL, -_mYMoveAmplitude,
                    -_mYMoveAmplitudeShift);
                _zMoveR = Wsin(_mSspTimeStartR, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveR = Wsin(_mTime, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartL, -_mAMoveAmplitude,
                    -_mAMoveAmplitudeShift);
                _pelvisOffsetL = Wsin(_mTime, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, _mPelvisSwing / 2,
                    _mPelvisSwing / 2);
                _pelvisOffsetR = Wsin(_mTime, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, -PelvisOffset / 2,
                    -PelvisOffset / 2);
            }

            else if (_mTime <= _mSspTimeStartR)
            {
                _xMoveL = Wsin(_mSspTimeEndL, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartL, _mXMoveAmplitude,
                    _mXMoveAmplitudeShift);
                _yMoveL = Wsin(_mSspTimeEndL, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartL, _mYMoveAmplitude,
                    _mYMoveAmplitudeShift);
                _zMoveL = Wsin(_mSspTimeEndL, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveL = Wsin(_mSspTimeEndL, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartL, _mAMoveAmplitude,
                    _mAMoveAmplitudeShift);
                _xMoveR = Wsin(_mSspTimeEndL, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartL, -_mXMoveAmplitude,
                    -_mXMoveAmplitudeShift);
                _yMoveR = Wsin(_mSspTimeEndL, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartL, -_mYMoveAmplitude,
                    -_mYMoveAmplitudeShift);
                _zMoveR = Wsin(_mSspTimeStartR, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveR = Wsin(_mSspTimeEndL, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartL, -_mAMoveAmplitude,
                    -_mAMoveAmplitudeShift);
                _pelvisOffsetL = 0;
                _pelvisOffsetR = 0;
            }
            else if (_mTime <= _mSspTimeEndR)
            {
                _xMoveL = Wsin(_mTime, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartR + Math.PI,
                    _mXMoveAmplitude, _mXMoveAmplitudeShift);
                _yMoveL = Wsin(_mTime, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartR + Math.PI,
                    _mYMoveAmplitude, _mYMoveAmplitudeShift);
                _zMoveL = Wsin(_mSspTimeEndL, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveL = Wsin(_mTime, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartR + Math.PI,
                    _mAMoveAmplitude, _mAMoveAmplitudeShift);
                _xMoveR = Wsin(_mTime, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartR + Math.PI,
                    -_mXMoveAmplitude, -_mXMoveAmplitudeShift);
                _yMoveR = Wsin(_mTime, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartR + Math.PI,
                    -_mYMoveAmplitude, -_mYMoveAmplitudeShift);
                _zMoveR = Wsin(_mTime, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveR = Wsin(_mTime, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartR + Math.PI,
                    -_mAMoveAmplitude, -_mAMoveAmplitudeShift);
                _pelvisOffsetL = Wsin(_mTime, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, PelvisOffset / 2,
                    PelvisOffset / 2);
                _pelvisOffsetR = Wsin(_mTime, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, -_mPelvisSwing / 2,
                    -_mPelvisSwing / 2);
            }

            else
            {
                _xMoveL = Wsin(_mSspTimeEndR, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartR + Math.PI,
                    _mXMoveAmplitude, _mXMoveAmplitudeShift);
                _yMoveL = Wsin(_mSspTimeEndR, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartR + Math.PI,
                    _mYMoveAmplitude, _mYMoveAmplitudeShift);
                _zMoveL = Wsin(_mSspTimeEndL, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartL, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveL = Wsin(_mSspTimeEndR, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartR + Math.PI,
                    _mAMoveAmplitude, _mAMoveAmplitudeShift);
                _xMoveR = Wsin(_mSspTimeEndR, _mXMovePeriodTime,
                    _mXMovePhaseShift + 2 * Math.PI / _mXMovePeriodTime * _mSspTimeStartR + Math.PI,
                    -_mXMoveAmplitude, -_mXMoveAmplitudeShift);
                _yMoveR = Wsin(_mSspTimeEndR, _mYMovePeriodTime,
                    _mYMovePhaseShift + 2 * Math.PI / _mYMovePeriodTime * _mSspTimeStartR + Math.PI,
                    -_mYMoveAmplitude, -_mYMoveAmplitudeShift);
                _zMoveR = Wsin(_mSspTimeEndR, _mZMovePeriodTime,
                    _mZMovePhaseShift + 2 * Math.PI / _mZMovePeriodTime * _mSspTimeStartR, _mZMoveAmplitude,
                    _mZMoveAmplitudeShift);
                _cMoveR = Wsin(_mSspTimeEndR, _mAMovePeriodTime,
                    _mAMovePhaseShift + 2 * Math.PI / _mAMovePeriodTime * _mSspTimeStartR + Math.PI,
                    -_mAMoveAmplitude, -_mAMoveAmplitudeShift);
                _pelvisOffsetL = 0;
                _pelvisOffsetR = 0;
            }

            _aMoveL = 0;
            _bMoveL = 0;
            _aMoveR = 0;
            _bMoveR = 0;

            _ep[0] = _xSwap + _xMoveR + _mXOffset;
            _ep[1] = _ySwap + _yMoveR - _mYOffset / 2;
            _ep[2] = _zSwap + _zMoveR + _mZOffset;
            _ep[3] = _aSwap + _aMoveR - _mROffset / 2;
            _ep[4] = _bSwap + _bMoveR + _mPOffset;
            _ep[5] = _cSwap + _cMoveR - _mAOffset / 2;
            _ep[6] = _xSwap + _xMoveL + _mXOffset;
            _ep[7] = _ySwap + _yMoveL + _mYOffset / 2;
            _ep[8] = _zSwap + _zMoveL + _mZOffset;
            _ep[9] = _aSwap + _aMoveL + _mROffset / 2;
            _ep[10] = _bSwap + _bMoveL + _mPOffset;
            _ep[11] = _cSwap + _cMoveL + _mAOffset / 2;

            // Compute body swing
            if (_mTime <= _mSspTimeEndL)
            {
                _mBodySwingY = -_ep[7];
                _mBodySwingZ = _ep[8];
            }
            else
            {
                _mBodySwingY = -_ep[1];
                _mBodySwingZ = _ep[2];
            }
            _mBodySwingZ -= _inverseKinematics.LegLength;

            // Compute arm swing
            if (_mXMoveAmplitude == 0)
            {
                _angle[12] = 0; // Right
                _angle[13] = 0; // Left
            }
            else
            {
                _angle[12] = Wsin(_mTime, _mPeriodTime, Math.PI * 1.5, -_mXMoveAmplitude * _mArmSwingGain, 0);
                _angle[13] = Wsin(_mTime, _mPeriodTime, Math.PI * 1.5, _mXMoveAmplitude * _mArmSwingGain, 0);
            }

            if (MRealRunning)
            {
                _mTime += TimeUnit;
                if (_mTime >= _mPeriodTime)
                {
                    _mTime = 0;
                }
            }

            // Compute angles
            var angle6 = new double[6];
            if ((_inverseKinematics.ComputeIk(ref _angle, _ep[0], _ep[1], _ep[2], _ep[3], _ep[4], _ep[5]))
                && (_inverseKinematics.ComputeIk(ref angle6, _ep[6], _ep[7], _ep[8], _ep[9], _ep[10], _ep[11])))
            {
                for (int i = 0; i < 6; i++)
                {
                    _angle[6 + i] = angle6[i];
                }

                for (int i = 0; i < 12; i++)
                {
                    _angle[i] *= 180.0 / Math.PI;
                }
            }
            else
            {
                return; // Do not use angle;
            }

            for (int i = 0; i < 14; i++)
            {

                if (i == 1)
                {
                    _angle[i] += _pelvisOffsetR;
                }
                else if (i == 7)
                {
                    _angle[i] += _pelvisOffsetL;
                }

                else if (i == 2 || i == 8)
                {
                    _angle[i] -= HipPitchOffset;
                }

                _outValue[i] = (int)(Dir[i] * _angle[i]);
            }

            if (!NoWrite)
            {

                _body.LeftHipYaw.Angle = WalkOffset.Angels[Body.JointIndex.LeftHipYaw] + _outValue[0];
                _body.LeftHipRoll.Angle = WalkOffset.Angels[Body.JointIndex.LeftHipRoll] + _outValue[1];
                _body.LeftHipPitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftHipPitch] + _outValue[2];
                _body.LeftKnee.Angle = WalkOffset.Angels[Body.JointIndex.LeftKnee] + _outValue[3];
                _body.LeftAnklePitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftAnklePitch] + _outValue[4];
                _body.LeftAnkleRoll.Angle = WalkOffset.Angels[Body.JointIndex.LeftAnkleRoll] + _outValue[5] / 8;


                _body.RightHipYaw.Angle = WalkOffset.Angels[Body.JointIndex.RightHipYaw] + _outValue[6];
                _body.RightHipRoll.Angle = WalkOffset.Angels[Body.JointIndex.RightHipRoll] + _outValue[7];
                _body.RightHipPitch.Angle = WalkOffset.Angels[Body.JointIndex.RightHipPitch] + (_outValue[8]);
                _body.RightKnee.Angle = WalkOffset.Angels[Body.JointIndex.RightKnee] + (_outValue[9]);
                _body.RightAnklePitch.Angle = WalkOffset.Angels[Body.JointIndex.RightAnklePitch] + (_outValue[10]);
                _body.RightAnkleRoll.Angle = WalkOffset.Angels[Body.JointIndex.RightAnkleRoll] + _outValue[11] / 8;



                //_body.RightArmPitch.Angle = WalkOffset.Angels[Body.JointIndex.RightArmPitch] + HandAmplitude * _outValue[12];
                //_body.LeftArmPitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftArmPitch] + HandAmplitude * _outValue[13];

                _body.RightArmRoll.Angle = WalkOffset.Angels[Body.JointIndex.RightArmRoll];
                _body.LeftArmRoll.Angle = WalkOffset.Angels[Body.JointIndex.LeftArmRoll];

                _body.RightElbow.Angle = WalkOffset.Angels[Body.JointIndex.RightElbow];
                _body.LeftElbow.Angle = WalkOffset.Angels[Body.JointIndex.LeftElbow];


                if (StabilizationEnable)
                {

                    var handStrategyOutput = _controllUnit.HandLowpass.Apply(_controllUnit.PitchZeroOffset) * HandPitchGain;
                    _body.RightArmPitch.Angle = WalkOffset.Angels[Body.JointIndex.RightArmPitch] + (_outValue[12]) + (Dir[12] * handStrategyOutput);
                    _body.LeftArmPitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftArmPitch] + (_outValue[13]) + (Dir[13] * handStrategyOutput);


                    //var GyroOut = PIDGyro.Calculate(_controllUnit.PreviousGyroPitch, _controllUnit.ActualGyroPitch, _walkEngineCallBackThread.Interval);
                    //var anklePitchGyro = -1 * _controllUnit.GyroAnklePitchLowPass.Apply(GyroOut);
                    //_body.LeftAnklePitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftAnklePitch] + _outValue[4] + (Dir[4] * anklePitchGyro);
                    //_body.RightAnklePitch.Angle = WalkOffset.Angels[Body.JointIndex.RightAnklePitch] + _outValue[10] + (Dir[10] * anklePitchGyro);
                }
                else
                {
                    _controllUnit.HandLowpass.Reset();
                    _body.RightArmPitch.Angle = WalkOffset.Angels[Body.JointIndex.RightArmPitch] + (_outValue[12]);
                    _body.LeftArmPitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftArmPitch] + (_outValue[13]);
                }

                //var anklePIDOutput = _controllUnit.AnklePitchPID.Calculate(_controllUnit.PitchZero, _controllUnit.ActualPitch, realTime);
                //_body.RightHipPitch.Angle = WalkOffset.Angels[Body.JointIndex.RightAnklePitch] - (Dir[8] * _controllUnit._newControl.GyroError * _controllUnit.AnklePitchPID.Kp);
                //_body.LeftHipPitch.Angle = WalkOffset.Angels[Body.JointIndex.LeftAnklePitch] - (Dir[2] * _controllUnit._newControl.GyroError * _controllUnit.AnklePitchPID.Kp);

                //var handRollPIDOutput = _controllUnit.HandRollPID.Calculate(_controllUnit.RollZero, _controllUnit.ActualRoll, realTime);

                _body.HomogenizeSpeeds(ActuatorsSpeed);
            }

        }

        public int ActuatorsSpeed { set; get; }

        public double HandPitchGain { get; set; }

        public bool StabilizationEnable { get; set; }

        public void Save(string path)
        {

            var xmldoc = new XElement("TrajectoryWalk",
                new XAttribute("PeriodTime", String.Format("{0}", PeriodTime)),

                new XAttribute("ActuatorsSpeed", String.Format("{0}", ActuatorsSpeed)),

                new XAttribute("TimeUnit", String.Format("{0}", TimeUnit)),
                new XAttribute("Directions", Utility.SerializeItems(Dir, ",")),

                new XAttribute("XAmplitude", String.Format("{0}", XMoveAmplitude)),
             new XAttribute("YAmplitude", String.Format("{0}", YMoveAmplitude)),
             new XAttribute("ZAmplitude", String.Format("{0}", ZMoveAmplitude)),
             new XAttribute("AAmplitude", String.Format("{0}", AMoveAmplitude)),

             new XAttribute("DoubleStanceRatio", String.Format("{0}", DoubleStancePeriodRatio)),
             new XAttribute("FowardBackwardRatio", String.Format("{0}", StepForwardBackwardRatio)),
             new XAttribute("YSwapAmplitude", String.Format("{0}", YSwapAmplitude)),
             new XAttribute("ZSwapAmplitude", String.Format("{0}", ZSwapAmplitude)),
             new XAttribute("ArmSwingGain", String.Format("{0}", ArmSwingGain)),

             new XAttribute("XOffset", String.Format("{0}", XOffset)),
             new XAttribute("YOffset", String.Format("{0}", YOffset)),
             new XAttribute("ZOffset", String.Format("{0}", ZOffset)),
             new XAttribute("AOffset", String.Format("{0}", AOffset)),

             new XAttribute("GyroP", String.Format("{0}", PIDGyro.Kp)),
             new XAttribute("GyroD", String.Format("{0}", PIDGyro.Kd)),

             new XAttribute("HandPitchGain", String.Format("{0}", HandPitchGain)),

             new XAttribute("StabilizationEnable", String.Format("{0}", StabilizationEnable))

                );

            xmldoc.Save(path);
        }

        public void Load(string path)
        {
            XDocument rootNode = XDocument.Load(path);
            var query = from step in rootNode.Descendants("TrajectoryWalk")
                        select new
                        {
                            PeriodTime = Convert.ToDouble(step.Attribute("PeriodTime").Value),
                            TimeUnit = Convert.ToInt32(step.Attribute("TimeUnit").Value),
                            Directions = Utility.DeserializeItems(step.Attribute("Directions").Value, ','),

                            XAmplitude = Convert.ToDouble(step.Attribute("XAmplitude").Value),
                            YAmplitude = Convert.ToDouble(step.Attribute("YAmplitude").Value),
                            ZAmplitude = Convert.ToDouble(step.Attribute("ZAmplitude").Value),
                            AAmplitude = Convert.ToDouble(step.Attribute("AAmplitude").Value),

                            DoubleStanceRatio = Convert.ToDouble(step.Attribute("DoubleStanceRatio").Value),
                            FowardBackwardRatio = Convert.ToDouble(step.Attribute("FowardBackwardRatio").Value),
                            YSwapAmplitude = Convert.ToDouble(step.Attribute("YSwapAmplitude").Value),
                            ZSwapAmplitude = Convert.ToDouble(step.Attribute("ZSwapAmplitude").Value),
                            ArmSwingGain = Convert.ToDouble(step.Attribute("ArmSwingGain").Value),

                            XOffset = Convert.ToDouble(step.Attribute("XOffset").Value),
                            YOffset = Convert.ToDouble(step.Attribute("YOffset").Value),
                            ZOffset = Convert.ToDouble(step.Attribute("ZOffset").Value),
                            AOffset = Convert.ToDouble(step.Attribute("AOffset").Value),

                            StabilizationEnable = Convert.ToBoolean(step.Attribute("StabilizationEnable").Value),

                            GyroP = Convert.ToDouble(step.Attribute("GyroP").Value),
                            GyroD = Convert.ToDouble(step.Attribute("GyroD").Value),

                            HandPitchGain = Convert.ToDouble(step.Attribute("HandPitchGain").Value),
                            ActuatorsSpeed = Convert.ToInt32(step.Attribute("ActuatorsSpeed").Value),
                        };

            var input = query.Single();

            PeriodTime = input.PeriodTime;

            ActuatorsSpeed = input.ActuatorsSpeed;

            TimeUnit = input.TimeUnit;

            Dir = new int[input.Directions.Length];
            input.Directions.CopyTo(Dir, 0);

            XMoveAmplitude = input.XAmplitude;
            YMoveAmplitude = input.YAmplitude;
            ZMoveAmplitude = input.ZAmplitude;
            AMoveAmplitude = input.AAmplitude;

            DoubleStancePeriodRatio = input.DoubleStanceRatio;
            StepForwardBackwardRatio = input.FowardBackwardRatio;
            YSwapAmplitude = input.YSwapAmplitude;
            ZSwapAmplitude = input.ZSwapAmplitude;
            ArmSwingGain = input.ArmSwingGain;

            XOffset = input.XOffset;
            YOffset = input.YOffset;
            ZOffset = input.ZOffset;
            AOffset = input.AOffset;

            StabilizationEnable = input.StabilizationEnable;

            HandPitchGain = input.HandPitchGain;

            PIDGyro = new PID
            {
                Kp = input.GyroP,
                Kd = input.GyroD,
            };

        }
    }
}
