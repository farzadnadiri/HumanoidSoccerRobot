using System;
using System.Threading;

using Robot.Environment;
using Robot.Environment.Interface;
using Math = Robot.Utils.Math;
using Thread = Robot.Utils.Thread;

namespace Robot.Locomotion
{
    public class FourStepWalkEngine
    {
        private readonly Thread _walkThread;
        private readonly IBody _body;
        private int _direction;
        private readonly Kinematics _kinematics;
        private object _key;


        public bool Enable { get { return _walkThread.IsEnable; } }

        public int Direction
        {
            get
            {
                lock (_key)
                {
                    if ((int)StepLength == 0)
                    {
                        return 0;
                    }

                    return _direction;
                }
            }
            set
            {
                lock (_key)
                {
                    _direction = value;
                    X = (Math.Cos(value) * StepLength);
                    Y = (Math.Sin(value) * StepLength);
                }
            }
        }


        public double PhaseTime
        {
            get;
            set;
        }

        private double _x;
        public double X
        {
            set
            {
                lock (_key)
                {
                    _x = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _x;
                }
            }
        }


        private double _y;
        public double Y
        {
            set
            {
                lock (_key)
                {
                    _y = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _y;
                }
            }
        }


        private double _z;
        public double Z
        {
            set
            {
                lock (_key)
                {
                    _z = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _z;
                }
            }
        }


        private double _yaw;
        public double Yaw
        {
            set
            {
                lock (_key)
                {
                    _yaw = value;
                }
            }
            get
            {
                lock (_key)
                {
                    return _yaw;
                }
            }
        }

        private double _stepLength;
        public double StepLength
        {
            get
            {
                lock (_key)
                {
                    return _stepLength;
                }
            }
            set
            {
                lock (_key)
                {
                    _stepLength = value;
                    X = value;
                    Y = value;
                }
            }
        }

        private Controll _controll;

        public FourStepWalkEngine(IBody body, Controll controll)
        {
            _key = new object();
            _controll = controll;
            _body = body;
            _kinematics = new Kinematics(body);
            _walkThread = new Thread(RunGait, ThreadPriority.Highest, 8);

        }

        public bool Start()
        {
            if (!_walkThread.IsEnable)
            {
                _gaitState = GaitState.Gait1;
                counter = 0;
                isFirstStop = true;
            }


            return _walkThread.Start();
        }

        public void Stop()
        {
            _gaitState = GaitState.Stop;

            System.Threading.Thread.Sleep(Convert.ToInt32(PhaseTime * 5 * 1000));
            _walkThread.Stop();
        }

        public void RunGait()
        {
            _kinematics.Foot(X, Y, Z, Yaw);

            ContinuesGait();

            //Gait1();
            //Gait2();
            //Gait3();
            //Gait4();


            //_body.RightHipYaw.Angle = _body.StandStyle[Body.JointIndex.RightHipYaw];
            //_body.RightHipPitch.Angle = _body.StandStyle[Body.JointIndex.RightHipPitch];
            //_body.RightHipRoll.Angle = _body.StandStyle[Body.JointIndex.RightHipRoll];
            //_body.RightKnee.Angle = _body.StandStyle[Body.JointIndex.RightKnee];
            //_body.RightAnklePitch.Angle = _body.StandStyle[Body.JointIndex.RightAnklePitch] + _controll.pitchOffsetGyroAnkle;
            //_body.RightAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.RightAnkleRoll];


            //_body.LeftHipYaw.Angle = _body.StandStyle[Body.JointIndex.LeftHipYaw];
            //_body.LeftHipPitch.Angle = _body.StandStyle[Body.JointIndex.LeftHipPitch];
            //_body.LeftHipRoll.Angle = _body.StandStyle[Body.JointIndex.LeftHipRoll];
            //_body.LeftKnee.Angle = _body.StandStyle[Body.JointIndex.LeftKnee];
            //_body.LeftAnklePitch.Angle = _body.StandStyle[Body.JointIndex.LeftAnklePitch] - _controll.pitchOffsetGyroAnkle; ;
            //_body.LeftAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.LeftAnkleRoll];
        }

        enum GaitState
        {
            Stop,
            Gait1,
            Gait2,
            Gait3,
            Gait4,
        }

        private GaitState _gaitState;
        private int counter = 0;

        private bool isFirstStop;

        private void ContinuesGait()
        {

            if (_gaitState == GaitState.Stop)
            {

                if (isFirstStop)
                {


                    _body.RightHipYaw.Angle = _body.StandStyle[Body.JointIndex.RightHipYaw];
                    _body.RightHipPitch.Angle = _body.StandStyle[Body.JointIndex.RightHipPitch];
                    _body.RightHipRoll.Angle = _body.StandStyle[Body.JointIndex.RightHipRoll];
                    _body.RightKnee.Angle = _body.StandStyle[Body.JointIndex.RightKnee];
                    _body.RightAnklePitch.Angle = _body.StandStyle[Body.JointIndex.RightAnklePitch];
                    _body.RightAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.RightAnkleRoll];


                    _body.LeftHipYaw.Angle = _body.StandStyle[Body.JointIndex.LeftHipYaw];
                    _body.LeftHipPitch.Angle = _body.StandStyle[Body.JointIndex.LeftHipPitch];
                    _body.LeftHipRoll.Angle = _body.StandStyle[Body.JointIndex.LeftHipRoll];
                    _body.LeftKnee.Angle = _body.StandStyle[Body.JointIndex.LeftKnee];
                    _body.LeftAnklePitch.Angle = _body.StandStyle[Body.JointIndex.LeftAnklePitch];
                    _body.LeftAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.LeftAnkleRoll];

                    isFirstStop = false;
                }

                return;

            }

            //_body.RightArmPitch.Speed = 1000;
            //_body.LeftArmPitch.Speed = 1000;

            //_body.RightArmPitch.Angle = _body.StandStyle[Body.JointIndex.RightArmPitch] + (-1 * _controll.PitchZeroOffset);
            //_body.LeftArmPitch.Angle = _body.StandStyle[Body.JointIndex.LeftArmPitch] + (_controll.pitchOffsetAccel);


            int phaseTime = Convert.ToInt32(1000 * PhaseTime);
            if (_gaitState == GaitState.Gait1)
            {
                if (phaseTime < _walkThread.Interval * counter)
                {
                    _gaitState = GaitState.Gait2;
                    counter = 0;
                    return;
                }

                // if first calculate phase time 
                if (counter == 0)
                {

                    _body.RightHipYaw.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightHipYaw] + _kinematics.HipYaw);
                    _body.RightHipPitch.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightHipPitch] + _kinematics.HipPitch);
                    _body.RightHipRoll.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightHipRoll] + _kinematics.HipRoll);
                    _body.RightKnee.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightKnee] + _kinematics.Knee);
                    _body.RightAnklePitch.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightAnklePitch] + _kinematics.AnklePitch);
                    _body.RightAnkleRoll.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightAnkleRoll] + _kinematics.AnkleRoll);
                }

                //else set position
                _body.RightHipYaw.Angle = _body.StandStyle[Body.JointIndex.RightHipYaw] + _kinematics.HipYaw;
                _body.RightHipPitch.Angle = _body.StandStyle[Body.JointIndex.RightHipPitch] + _kinematics.HipPitch;
                _body.RightHipRoll.Angle = _body.StandStyle[Body.JointIndex.RightHipRoll] + _kinematics.HipRoll;
                _body.RightKnee.Angle = _body.StandStyle[Body.JointIndex.RightKnee] + _kinematics.Knee;
                _body.RightAnklePitch.Angle = _body.StandStyle[Body.JointIndex.RightAnklePitch] + _kinematics.AnklePitch;// + _controll.pitchOffsetGyroAnkle;
                _body.RightAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.RightAnkleRoll] + _kinematics.AnkleRoll;

            }


            if (_gaitState == GaitState.Gait2)
            {
                if (phaseTime < _walkThread.Interval * counter)
                {
                    _gaitState = GaitState.Gait3;
                    counter = 0;
                    return;
                }

                if (counter == 0)
                {
                    _body.RightHipYaw.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightHipYaw]);
                    _body.RightHipPitch.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightHipPitch]);
                    _body.RightHipRoll.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightHipRoll]);
                    _body.RightKnee.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightKnee]);
                    _body.RightAnklePitch.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightAnklePitch]);
                    _body.RightAnkleRoll.MoveToAngle(PhaseTime,
                        _body.StandStyle[Body.JointIndex.RightAnkleRoll]);
                }

                _body.RightHipYaw.Angle = _body.StandStyle[Body.JointIndex.RightHipYaw];
                _body.RightHipPitch.Angle = _body.StandStyle[Body.JointIndex.RightHipPitch];
                _body.RightHipRoll.Angle = _body.StandStyle[Body.JointIndex.RightHipRoll];
                _body.RightKnee.Angle = _body.StandStyle[Body.JointIndex.RightKnee];
                _body.RightAnklePitch.Angle = _body.StandStyle[Body.JointIndex.RightAnklePitch];// + _controll.pitchOffsetGyroAnkle;
                _body.RightAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.RightAnkleRoll];

            }

            if (_gaitState == GaitState.Gait3)
            {
                if (phaseTime < _walkThread.Interval * counter)
                {
                    _gaitState = GaitState.Gait4;
                    counter = 0;
                    return;
                }

                if (counter == 0)
                {

                    _body.LeftHipYaw.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftHipYaw] + _kinematics.HipYaw);
                    _body.LeftHipPitch.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftHipPitch] - _kinematics.HipPitch);
                    _body.LeftHipRoll.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftHipRoll] + _kinematics.HipRoll);
                    _body.LeftKnee.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftKnee] - _kinematics.Knee);
                    _body.LeftAnklePitch.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftAnklePitch] - _kinematics.AnklePitch);
                    _body.LeftAnkleRoll.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftAnkleRoll] - _kinematics.AnkleRoll);
                }

                _body.LeftHipYaw.Angle = _body.StandStyle[Body.JointIndex.LeftHipYaw] + _kinematics.HipYaw;
                _body.LeftHipPitch.Angle = _body.StandStyle[Body.JointIndex.LeftHipPitch] - _kinematics.HipPitch;
                _body.LeftHipRoll.Angle = _body.StandStyle[Body.JointIndex.LeftHipRoll] + _kinematics.HipRoll;
                _body.LeftKnee.Angle = _body.StandStyle[Body.JointIndex.LeftKnee] - _kinematics.Knee;
                _body.LeftAnklePitch.Angle = _body.StandStyle[Body.JointIndex.LeftAnklePitch] - _kinematics.AnklePitch;// - _controll.pitchOffsetGyroAnkle;
                _body.LeftAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.LeftAnkleRoll] - _kinematics.AnkleRoll;
            }

            if (_gaitState == GaitState.Gait4)
            {
                if (phaseTime < _walkThread.Interval * counter)
                {
                    _gaitState = GaitState.Gait1;
                    counter = 0;
                    return;
                }

                if (counter == 0)
                {
                    _body.LeftHipYaw.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftHipYaw]);
                    _body.LeftHipPitch.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftHipPitch]);
                    _body.LeftHipRoll.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftHipRoll]);
                    _body.LeftKnee.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftKnee]);
                    _body.LeftAnklePitch.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftAnklePitch]);
                    _body.LeftAnkleRoll.MoveToAngle(PhaseTime, _body.StandStyle[Body.JointIndex.LeftAnkleRoll]);
                }

                _body.LeftHipYaw.Angle = _body.StandStyle[Body.JointIndex.LeftHipYaw];
                _body.LeftHipPitch.Angle = _body.StandStyle[Body.JointIndex.LeftHipPitch];
                _body.LeftHipRoll.Angle = _body.StandStyle[Body.JointIndex.LeftHipRoll];
                _body.LeftKnee.Angle = _body.StandStyle[Body.JointIndex.LeftKnee];
                _body.LeftAnklePitch.Angle = _body.StandStyle[Body.JointIndex.LeftAnklePitch];// - _controll.pitchOffsetGyroAnkle; ;
                _body.LeftAnkleRoll.Angle = _body.StandStyle[Body.JointIndex.LeftAnkleRoll];
            }
            counter++;

        }

        private void Gait1()
        {
            lock (_key)
            {
                _body.RightHipYaw.MoveToAngle(PhaseTime, +_kinematics.HipYaw, true);
                _body.RightHipPitch.MoveToAngle(PhaseTime, +_kinematics.HipPitch, true);
                _body.RightHipRoll.MoveToAngle(PhaseTime, +_kinematics.HipRoll, true);
                _body.RightKnee.MoveToAngle(PhaseTime, +_kinematics.Knee, true);
                _body.RightAnklePitch.MoveToAngle(PhaseTime, +_kinematics.AnklePitch, true);
                _body.RightAnkleRoll.MoveToAngle(PhaseTime, +_kinematics.AnkleRoll, true);


                _body.ApplySpeedPositions();
                System.Threading.Thread.Sleep(Convert.ToInt32(PhaseTime * 1000));
            }
        }

        private void Gait2()
        {

            lock (_key)
            {
                _body.RightHipYaw.MoveToAngle(PhaseTime, -_kinematics.HipYaw, true);
                _body.RightHipPitch.MoveToAngle(PhaseTime, -_kinematics.HipPitch, true);
                _body.RightHipRoll.MoveToAngle(PhaseTime, -_kinematics.HipRoll, true);
                _body.RightKnee.MoveToAngle(PhaseTime, -_kinematics.Knee, true);
                _body.RightAnklePitch.MoveToAngle(PhaseTime, -_kinematics.AnklePitch, true);
                _body.RightAnkleRoll.MoveToAngle(PhaseTime, -_kinematics.AnkleRoll, true);

                _body.ApplySpeedPositions();
                System.Threading.Thread.Sleep(Convert.ToInt32(PhaseTime * 1000));
            }
        }


        private void Gait3()
        {
            lock (_key)
            {

                _body.LeftHipYaw.MoveToAngle(PhaseTime, +_kinematics.HipYaw, true);
                _body.LeftHipPitch.MoveToAngle(PhaseTime, -_kinematics.HipPitch, true);
                _body.LeftHipRoll.MoveToAngle(PhaseTime, +_kinematics.HipRoll, true);
                _body.LeftKnee.MoveToAngle(PhaseTime, -_kinematics.Knee, true);
                _body.LeftAnklePitch.MoveToAngle(PhaseTime, -_kinematics.AnklePitch, true);
                _body.LeftAnkleRoll.MoveToAngle(PhaseTime, -_kinematics.AnkleRoll, true);

                _body.ApplySpeedPositions();
                System.Threading.Thread.Sleep(Convert.ToInt32(PhaseTime * 1000));
            }
        }

        private void Gait4()
        {
            lock (_key)
            {
                _body.LeftHipYaw.MoveToAngle(PhaseTime, -_kinematics.HipYaw, true);
                _body.LeftHipPitch.MoveToAngle(PhaseTime, +_kinematics.HipPitch, true);
                _body.LeftHipRoll.MoveToAngle(PhaseTime, -_kinematics.HipRoll, true);
                _body.LeftKnee.MoveToAngle(PhaseTime, +_kinematics.Knee, true);
                _body.LeftAnklePitch.MoveToAngle(PhaseTime, _kinematics.AnklePitch, true);
                _body.LeftAnkleRoll.MoveToAngle(PhaseTime, +_kinematics.AnkleRoll, true);

                _body.ApplySpeedPositions();
                System.Threading.Thread.Sleep(Convert.ToInt32(PhaseTime * 1000));
            }
        }

    }
}
