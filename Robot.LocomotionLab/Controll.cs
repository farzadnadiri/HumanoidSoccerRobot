using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using GNRobot.Device;
using GNRobot.Device.Enums;
using Robot.Locomotion.TrajectoryWalk;
using Robot.Utils.Interface;
using Math = System.Math;

namespace Robot.Locomotion
{
    public enum RobotState
    {
        Stable,
        Falling,
        FallFront,
        FallBack,
        FallSideLeft,
        FallSideRight
    }

    public class Controll : IStorable
    {
        private readonly Utils.Thread _controllThread;
        private byte _id;

        private int _interval;

        public NewControl _newControl { set; get; }

        public Robot.Probabilistics.Filter.LowPass HandLowpass;

        public Robot.Probabilistics.Filter.LowPass GyroAnklePitchLowPass;


        public string PortName { set; get; }

        public RobotState RobotState;

        public int CompassOffset { set; get; }

        public int Interval
        {
            get { return _interval; }
        }

        public int PitchZero { set; get; }
        public int RollZero { set; get; }


        private readonly object _key = new object();

        private IMUData _imuData;
        public IMUData ImuData
        {
            get { lock (_key) { return _imuData; } }
            set { lock (_key) { _imuData = value; } }
        }




        public Controll(string portName, int id, int compassOffset, int pitchZero = 0, int rollZero = 0, int interval = 2)
        {
             
            _newControl = new NewControl();
            HandLowpass = new Probabilistics.Filter.LowPass(0.3);
            GyroAnklePitchLowPass = new Probabilistics.Filter.LowPass(0.3);

            _id = (byte)id;
            CompassOffset = compassOffset;
            _interval = interval;
            PortName = portName;

            PitchZero = pitchZero;
            RollZero = rollZero;

            _imu = new SerialDevice(portName, 1000000);

            try
            {
                _imu.Open();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
            _controllThread = new Utils.Thread(GetImu, ThreadPriority.Highest, _interval);
        }

        public Controll(string configPath)
        {
           
            _newControl = new NewControl();

            Load(configPath);

            _imu = new SerialDevice(PortName, 1000000);
            try
            {
                _imu.Open();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
            _controllThread = new Utils.Thread(GetImu, ThreadPriority.Highest, _interval);
        }

        private readonly SerialDevice _imu;

        public void Start()
        {
            _controllThread.Start();
        }
        public void Stop()
        {
            _controllThread.Stop();
        }

        public void Reset()
        {
            _imu.Reset(_id);
        }

        public double ActualPitch { set; get; }
        public double ActualRoll { set; get; }
        public double ActualGyroPitch { set; get; }
        public double PreviousGyroPitch { set; get; }
        public double PitchZeroOffset { set; get; }
        public double RollZeroOffset { set; get; }

        public double FallingBoundary { set; get; }
        public double FallFrontBoundary { set; get; }
        public double FallBackBoundary { set; get; }

        public double FallSideLeftBoundary { set; get; }
        public double FallSideRightBoundary { set; get; }

        public int FallCounter { set; get; }

        public int _insuranceCounter;

 
       
        public double Compass
        {
            get
            {
                lock (_key)
                {
                    var x = (_imuData.FilteredAngleYaw * 180 / Math.PI) + CompassOffset;
                    if (x > 180)
                    {
                        return x - 360;
                    }
                    if (x < -180)
                    {
                        return x + 360;
                    }
                    return x;
                }
            }
        }
 

        public void GetImu()
        {

            const GnMPUReg startAddress = GnMPUReg.ModelNumber;
            const int count = IMUData.SizeOfArray - (int)startAddress;
            var data = _imu.ReadData(_id, startAddress, count);

            if (data != null && data.Count == count)
            {
                _imuData = IMUData.FromBytes(data.ToArray(), 0, count);

                ActualPitch = GetDeltaCircle(ImuData.FilteredAngleRoll) * -1 * 180 / Math.PI;
                ActualRoll = GetDeltaCircle(ImuData.FilteredAnglePitch) * -1 * 180 / Math.PI;

                PreviousGyroPitch = ActualGyroPitch;
                ActualGyroPitch = GetDeltaCircle(ImuData.GyroY) * -1 * 180 / Math.PI;
                _newControl.GetGyroError(ActualGyroPitch);
                //_newControl.GetGyroError(ActualPitch);

                PitchZeroOffset = ActualPitch - PitchZero;
                RollZeroOffset = ActualRoll - RollZero;

                if (PitchZeroOffset < FallBackBoundary)
                {
                    if (_insuranceCounter > FallCounter)
                    {
                        RobotState = RobotState.FallBack;
                    }
                    _insuranceCounter++;

                }
                else if (PitchZeroOffset > FallFrontBoundary)
                {
                    if (_insuranceCounter > FallCounter)
                    {
                        RobotState = RobotState.FallFront;
                    }
                    _insuranceCounter++;

                }

                //else if (RollZeroOffset > FallSideLeftBoundary)
                //{
                //    if (_insuranceCounter > FallCounter)
                //    {
                //        RobotState = RobotState.FallSideLeft;
                //    }
                //    _insuranceCounter++;
                //}

                //else if (RollZeroOffset < FallSideRightBoundary)
                //{
                //    if (_insuranceCounter > FallCounter)
                //    {
                //        RobotState = RobotState.FallSideLeft;
                //    }
                //    _insuranceCounter++;
                //}

                else if ((Math.Abs(PitchZeroOffset) > FallingBoundary) || (Math.Abs(RollZeroOffset) > FallingBoundary))
                {
                    if (_insuranceCounter > FallCounter)
                    {
                        RobotState = RobotState.Falling;
                    }
                    _insuranceCounter++;

                }
                else
                {
                    RobotState = RobotState.Stable;
                    _insuranceCounter = 0;
                }

            }

        }



        public float GetDeltaCircle(float delta)
        {
            const float hPi = (float)Math.PI / 2;
            return Math.Abs(delta) > Math.PI
                       ? delta > 0 ? delta - hPi * 4 : delta + hPi * 4
                       : delta;
        }


        public void Save(string path)
        {
            var xmldoc = new XElement("ControllUnit",
                new XAttribute("Id", String.Format("{0}", _id)),
                new XAttribute("Interval", String.Format("{0}", _interval)),
                new XAttribute("PortName", String.Format("{0}", PortName)),

                new XAttribute("PitchZero", String.Format("{0}", PitchZero)),
                new XAttribute("RollZero", String.Format("{0}", RollZero)),

                new XAttribute("CompassOffset", String.Format("{0}", CompassOffset)),

                new XAttribute("FallingBoundary", String.Format("{0}", FallingBoundary)),
                new XAttribute("FallFrontBoundary", String.Format("{0}", FallFrontBoundary)),
                new XAttribute("FallBackBoundary", String.Format("{0}", FallBackBoundary)),
                new XAttribute("FallSideLeftBoundary", String.Format("{0}", FallSideLeftBoundary)),
                new XAttribute("FallSideRightBoundary", String.Format("{0}", FallSideRightBoundary)),
                new XAttribute("HandLowpassGain", String.Format("{0}", HandLowpass.Gain)),
                new XAttribute("GyroAnklePitchLowPassGain", String.Format("{0}", GyroAnklePitchLowPass.Gain)),

                new XAttribute("FallCounter", String.Format("{0}", FallCounter))
                );

            xmldoc.Save(path);
        }

        public void Load(string path)
        {

            XDocument rootNode = XDocument.Load(path);
            var query = from step in rootNode.Descendants("ControllUnit")
                        select new
                        {
                            Id = Convert.ToByte(step.Attribute("Id").Value),
                            Interval = Convert.ToInt32(step.Attribute("Interval").Value),
                            PortName = step.Attribute("PortName").Value,
                            CompassOffset = Convert.ToInt32(step.Attribute("CompassOffset").Value),

                            PitchZero = Convert.ToInt32(step.Attribute("PitchZero").Value),
                            RollZero = Convert.ToInt32(step.Attribute("RollZero").Value),

                            FallCounter = Convert.ToInt32(step.Attribute("FallCounter").Value),

                            FallingBoundary = Convert.ToDouble(step.Attribute("FallingBoundary").Value),
                            FallFrontBoundary = Convert.ToDouble(step.Attribute("FallFrontBoundary").Value),
                            FallBackBoundary = Convert.ToDouble(step.Attribute("FallBackBoundary").Value),
                            FallSideLeftBoundary = Convert.ToDouble(step.Attribute("FallSideLeftBoundary").Value),
                            FallSideRightBoundary = Convert.ToDouble(step.Attribute("FallSideRightBoundary").Value),

                            HandLowpassGain = Convert.ToDouble(step.Attribute("HandLowpassGain").Value),
                            GyroAnklePitchLowPassGain = Convert.ToDouble(step.Attribute("GyroAnklePitchLowPassGain").Value),

                        };

            if (query.Any())
            {
                var input = query.Single();
                CompassOffset = input.CompassOffset;
                _interval = input.Interval;
                _id = input.Id;
                PortName = input.PortName;

                PitchZero = input.PitchZero;
                RollZero = input.RollZero;

                FallCounter = input.FallCounter;

                FallingBoundary = input.FallingBoundary;
                FallFrontBoundary = input.FallFrontBoundary;
                FallBackBoundary = input.FallBackBoundary;
                FallSideLeftBoundary = input.FallSideLeftBoundary;
                FallSideRightBoundary = input.FallSideRightBoundary;

                HandLowpass = new Probabilistics.Filter.LowPass(input.HandLowpassGain);
                GyroAnklePitchLowPass = new Probabilistics.Filter.LowPass(input.GyroAnklePitchLowPassGain);
            }
        }
    }
}
