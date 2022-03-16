using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Robot.Utils;
using Robot.Vision.HeadControl;
using Math = System.Math;
using Thread = Robot.Utils.Thread;

namespace Robot.Locomotion.TrajectoryWalk
{
    public class WalkManager
    {
        private Thread _fsmThread;
        private Controll _controll;
        private TrajectoryWalkEngine _trajectoryWalkEngine;
        private MotionManager _motionManager;
        Environment.Head _head;
        Environment.Body _body;


        public int FallingMotionIndex { set; get; }
        public int FrontStandUpIndex { set; get; }
        public int BackStandUpIndex { set; get; }

        public int LeftKickLittleIndex { set; get; }
        public int LeftKickIndex { set; get; }

        public int RightKickLittleIndex { set; get; }
        public int RightKickIndex { set; get; }
        public int HappyIndex { set; get; }



        public Range<int> XRange { set; get; }
        public Range<int> YRange { set; get; }
        public Range<int> ZRange { set; get; }
        public Range<int> ARange { set; get; }

        public bool XSmoothEnable { set; get; }
        public bool YSmoothEnable { set; get; }
        public bool ZSmoothEnable { set; get; }
        public bool ASmoothEnable { set; get; }

        public int XUpdateInterval { set; get; }
        public int YUpdateInterval { set; get; }
        public int ZUpdateInterval { set; get; }
        public int AUpdateInterval { set; get; }

        public int FSMInterval
        {
            set
            {
                _fsmThread.Interval = value;
            }
            get { return _fsmThread.Interval; }
        }

        private Stopwatch _stopwatchX;
        private Stopwatch _stopwatchY;
        private Stopwatch _stopwatchZ;
        private Stopwatch _stopwatchA;

        private int _x;
        private int _y;
        private int _z;
        private int _a;
        private bool _isMotionPlaying;

        public bool IsMotionPlaying
        {
            get { return _isMotionPlaying; }
        }


        public double X
        {
            set
            {
                _x = XRange.Validate((int)value);
                if (!XSmoothEnable)
                {
                    _trajectoryWalkEngine.XMoveAmplitude = _x;
                }
            }
            get { return _trajectoryWalkEngine.XMoveAmplitude; }
        }

        public double Y
        {
            set
            {
                _y = YRange.Validate((int)value);
                if (!YSmoothEnable)
                {
                    _trajectoryWalkEngine.YSwapAmplitude = _y;
                }
            }
            get { return _trajectoryWalkEngine.YSwapAmplitude; }
        }

        public double Z
        {
            set
            {
                _z = ZRange.Validate((int)value);
                if (!ZSmoothEnable)
                {
                    _trajectoryWalkEngine.ZMoveAmplitude = _z;
                }
            }
            get { return _trajectoryWalkEngine.ZMoveAmplitude; }
        }

        public double A
        {
            set
            {
                _a = ARange.Validate((int)value);
                if (!ASmoothEnable)
                {
                    _trajectoryWalkEngine.AMoveAmplitude = _a;
                }
            }
            get { return _trajectoryWalkEngine.AMoveAmplitude; }
        }

        private Search _search;
        private Tracker _tracker;

        public WalkManager(string path, TrajectoryWalkEngine trajectoryWalkEngine, Controll controll, MotionManager motionManager, Environment.Head head, Environment.Body body, Search search, Tracker tracker)
        {
            _key = new object();
            _controll = controll;

            _search = search;
            _tracker = tracker;

            _trajectoryWalkEngine = trajectoryWalkEngine;
            _motionManager = motionManager;
            _head = head;
            _body = body;

            _falling = new Step(_body.Joints.Count, 1);
            _falling.Load("Config/Falling.xml");
            Load(path);

            _stopwatchX = new Stopwatch();
            _stopwatchY = new Stopwatch();
            _stopwatchZ = new Stopwatch();
            _stopwatchA = new Stopwatch();

            _trajectoryWalkEngine.ZMoveAmplitude = ZRange.Min;

            _walkState = WalkState.Stoped;

            _tiltMax = _head.Tilt.PositionBoundary.Max;
        }

        public void StartFSM()
        {
            _fsmThread.Start();

            _stopwatchX.Start();
            _stopwatchY.Start();
            _stopwatchZ.Start();
            _stopwatchA.Start();
        }

        public void StopFSM()
        {
            _stopwatchX.Stop();
            _stopwatchY.Stop();
            _stopwatchZ.Stop();
            _stopwatchA.Stop();

            _fsmThread.Stop();
        }

        public bool IsRunning { set; get; }

        private Step _falling;

        public enum WalkState
        {
            Running,
            Start,
            Stop,
            Stoped
        }

        private int _tiltMax;

        private WalkState _walkState;
        public void WalkStart()
        {
            _walkState = WalkState.Start;

            _trajectoryWalkEngine.WalkStart();
            IsRunning = true;

            Z = ZRange.Max;
            X = 0;
            Y = 0;
            A = 0;
        }

        public void WalkStop(bool force)
        {
            if (force)
            {
                IsRunning = false;
                _trajectoryWalkEngine.WalkStop(false);
            }

            _walkState = WalkState.Stop;

            _trajectoryWalkEngine.XMoveAmplitude = 0;
            _trajectoryWalkEngine.YMoveAmplitude = 0;
            _trajectoryWalkEngine.AMoveAmplitude = 0;

            Z = ZRange.Min;

        }

        private object _key;

        public void PlayMotion(int index)
        {
            lock (_key)
            {
                _isMotionPlaying = true;
                System.Threading.Thread.Sleep(1500);
                _motionManager.PlayMotion(index);
                System.Threading.Thread.Sleep(1500);
                _isMotionPlaying = false;
            }
        }

        public enum Motion
        {
            Falling,
            FrontStandUp,
            BackStandUp,

            LeftKick,
            LeftKickLittle,
            RightKick,
            RightKickLittle,
            Happy,
        }

        public void PlayMotion(Motion motion)
        {
            if (motion == Motion.Falling)
            {
                //TODO: Call Step
            }
            else if (motion == Motion.FrontStandUp)
            {
                PlayMotion(FrontStandUpIndex);
            }
            else if (motion == Motion.BackStandUp)
            {
                PlayMotion(BackStandUpIndex);
            }
            else if (motion == Motion.LeftKick)
            {
                PlayMotion(LeftKickIndex);
            }
            else if (motion == Motion.LeftKickLittle)
            {
                PlayMotion(LeftKickLittleIndex);
            }
            else if (motion == Motion.RightKick)
            {
                PlayMotion(RightKickIndex);
            }
            else if (motion == Motion.RightKickLittle)
            {
                PlayMotion(RightKickLittleIndex);
            }

            else if (motion == Motion.Happy)
            {
                PlayMotion(HappyIndex);
            }
        }

        public void PlayStep(Step step)
        {
            lock (_key)
            {
                _isMotionPlaying = true;
                _motionManager.PlayStep(step, 1023);
                _isMotionPlaying = false;
            }
        }

        public void FSM()
        {

            if (_controll.RobotState != RobotState.Stable)
            {
                //WalkStop(true);

                _trajectoryWalkEngine.ForceStop();

                _search.Stop();
                _tracker.Stop();

                _head.Tilt.AutoFlush = true;
                _head.Pan.AutoFlush = true;

                _head.Tilt.PositionBoundary.Max = 650;

                _head.Pan.Speed = 1023;
                _head.Tilt.Speed = 1023;
                _head.Pan.Angle = 0;
                _head.Tilt.Position = 650;

                _head.Tilt.AutoFlush = false;
                _head.Pan.AutoFlush = false;

                if (!_isMotionPlaying)
                {
                    PlayStep(_falling);
                }

                if (_controll.RobotState == RobotState.FallBack)
                {
                    if (!_isMotionPlaying)
                    {
                        PlayMotion(BackStandUpIndex);
                    }
                }
                else if (_controll.RobotState == RobotState.FallFront)
                {
                    if (!_isMotionPlaying)
                    {
                        PlayMotion(FrontStandUpIndex);
                    }
                }
            }

            else
            {
                _head.Tilt.PositionBoundary.Max = _tiltMax;
            }


            if (_walkState == WalkState.Stop && (int)Z == ZRange.Min)
            {
                _walkState = WalkState.Stoped;
                WalkStop(true);
            }

            if (IsRunning)
            {
                if (_stopwatchX.ElapsedMilliseconds > XUpdateInterval)
                {

                    var xDif = _x - _trajectoryWalkEngine.XMoveAmplitude;
                    _trajectoryWalkEngine.XMoveAmplitude += Math.Sign(xDif) * 1;

                    _stopwatchX.Stop();
                    _stopwatchX.Restart();

                }

                if (_stopwatchY.ElapsedMilliseconds > YUpdateInterval)
                {
                    var yDif = _y - _trajectoryWalkEngine.YSwapAmplitude;
                    _trajectoryWalkEngine.YSwapAmplitude += Math.Sign(yDif) * 1;
                    _stopwatchY.Stop();
                    _stopwatchY.Restart();
                }

                if (_stopwatchZ.ElapsedMilliseconds > ZUpdateInterval)
                {
                    var zDif = _z - _trajectoryWalkEngine.ZMoveAmplitude;
                    var timerate = 1 - (Math.Abs(zDif) / ZRange.Max / 4);
                    _trajectoryWalkEngine.PeriodTime = _trajectoryWalkEngine.MaxPeriodTime * timerate;
                    _trajectoryWalkEngine.ZMoveAmplitude += Math.Sign(zDif) * 1;
                    _stopwatchZ.Stop();
                    _stopwatchZ.Restart();
                }
                if (_stopwatchA.ElapsedMilliseconds > AUpdateInterval)
                {
                    var aDif = _a - _trajectoryWalkEngine.AMoveAmplitude;
                    _trajectoryWalkEngine.AMoveAmplitude += Math.Sign(aDif) * 1;
                    _stopwatchA.Stop();
                    _stopwatchA.Restart();
                }

            }

        }


        public void Save(string path)
        {
            var xmldoc = new XElement("WalkManager",


                new XAttribute("XUpdateInterval", String.Format("{0}", XUpdateInterval)),
                new XAttribute("YUpdateInterval", String.Format("{0}", YUpdateInterval)),
                new XAttribute("ZUpdateInterval", String.Format("{0}", ZUpdateInterval)),
                new XAttribute("AUpdateInterval", String.Format("{0}", AUpdateInterval)),

                new XAttribute("FSMInterval", String.Format("{0}", FSMInterval)),

                new XAttribute("FallingMotionIndex", String.Format("{0}", FallingMotionIndex)),
                new XAttribute("FrontStandUpIndex", String.Format("{0}", FrontStandUpIndex)),
                new XAttribute("BackStandUpIndex", String.Format("{0}", BackStandUpIndex)),

                new XAttribute("LeftKickIndex", String.Format("{0}", LeftKickIndex)),
                new XAttribute("LeftKickLittleIndex", String.Format("{0}", LeftKickLittleIndex)),
                new XAttribute("RightKickIndex", String.Format("{0}", RightKickIndex)),
                new XAttribute("RightKickLittleIndex", String.Format("{0}", RightKickLittleIndex)),
                new XAttribute("HappyIndex", String.Format("{0}", HappyIndex)),


                new XAttribute("XSmoothEnable", String.Format("{0}", XSmoothEnable)),
                new XAttribute("YSmoothEnable", String.Format("{0}", YSmoothEnable)),
                new XAttribute("ZSmoothEnable", String.Format("{0}", ZSmoothEnable)),
                new XAttribute("ASmoothEnable", String.Format("{0}", ASmoothEnable)),


                new XAttribute("XRangeMin", String.Format("{0}", XRange.Min)),
                new XAttribute("XRangeMax", String.Format("{0}", XRange.Max)),
                new XAttribute("YRangeMin", String.Format("{0}", YRange.Min)),
                new XAttribute("YRangeMax", String.Format("{0}", YRange.Max)),
                new XAttribute("ZRangeMin", String.Format("{0}", ZRange.Min)),
                new XAttribute("ZRangeMax", String.Format("{0}", ZRange.Max)),
                new XAttribute("ARangeMin", String.Format("{0}", ARange.Min)),
                new XAttribute("ARangeMax", String.Format("{0}", ARange.Max))

                );

            xmldoc.Save(path);
        }

        public void Load(string path)
        {

            XDocument rootNode = XDocument.Load(path);
            var query = from step in rootNode.Descendants("WalkManager")
                        select new
                        {

                            XUpdateInterval = Convert.ToInt32(step.Attribute("XUpdateInterval").Value),
                            YUpdateInterval = Convert.ToInt32(step.Attribute("YUpdateInterval").Value),
                            ZUpdateInterval = Convert.ToInt32(step.Attribute("ZUpdateInterval").Value),
                            AUpdateInterval = Convert.ToInt32(step.Attribute("AUpdateInterval").Value),

                            FSMInterval = Convert.ToInt32(step.Attribute("FSMInterval").Value),

                            FallingMotionIndex = Convert.ToInt32(step.Attribute("FallingMotionIndex").Value),
                            FrontStandUpIndex = Convert.ToInt32(step.Attribute("FrontStandUpIndex").Value),
                            BackStandUpIndex = Convert.ToInt32(step.Attribute("BackStandUpIndex").Value),


                            LeftKickIndex = Convert.ToInt32(step.Attribute("LeftKickIndex").Value),
                            LeftKickLittleIndex = Convert.ToInt32(step.Attribute("LeftKickLittleIndex").Value),
                            RightKickIndex = Convert.ToInt32(step.Attribute("RightKickIndex").Value),
                            RightKickLittleIndex = Convert.ToInt32(step.Attribute("RightKickLittleIndex").Value),
                            HappyIndex = Convert.ToInt32(step.Attribute("HappyIndex").Value),

                            XRangeMin = Convert.ToInt32(step.Attribute("XRangeMin").Value),
                            XRangeMax = Convert.ToInt32(step.Attribute("XRangeMax").Value),
                            YRangeMin = Convert.ToInt32(step.Attribute("YRangeMin").Value),
                            YRangeMax = Convert.ToInt32(step.Attribute("YRangeMax").Value),
                            ZRangeMin = Convert.ToInt32(step.Attribute("ZRangeMin").Value),
                            ZRangeMax = Convert.ToInt32(step.Attribute("ZRangeMax").Value),
                            ARangeMin = Convert.ToInt32(step.Attribute("ARangeMin").Value),
                            ARangeMax = Convert.ToInt32(step.Attribute("ARangeMax").Value),

                            XSmoothEnable = Convert.ToBoolean(step.Attribute("XSmoothEnable").Value),
                            YSmoothEnable = Convert.ToBoolean(step.Attribute("YSmoothEnable").Value),
                            ZSmoothEnable = Convert.ToBoolean(step.Attribute("ZSmoothEnable").Value),
                            ASmoothEnable = Convert.ToBoolean(step.Attribute("ASmoothEnable").Value),

                        };

            if (query.Any())
            {
                var input = query.Single();

                XUpdateInterval = input.XUpdateInterval;
                YUpdateInterval = input.YUpdateInterval;
                ZUpdateInterval = input.ZUpdateInterval;
                AUpdateInterval = input.AUpdateInterval;

                FallingMotionIndex = input.FallingMotionIndex;
                FrontStandUpIndex = input.FrontStandUpIndex;
                BackStandUpIndex = input.BackStandUpIndex;

                LeftKickIndex = input.LeftKickIndex;
                LeftKickLittleIndex = input.LeftKickLittleIndex;
                RightKickIndex = input.RightKickIndex;
                RightKickLittleIndex = input.RightKickLittleIndex;
                HappyIndex = input.HappyIndex;

                XRange = new Range<int>(input.XRangeMin, input.XRangeMax);
                YRange = new Range<int>(input.YRangeMin, input.YRangeMax);
                ZRange = new Range<int>(input.ZRangeMin, input.ZRangeMax);
                ARange = new Range<int>(input.ARangeMin, input.ARangeMax);

                XSmoothEnable = input.XSmoothEnable;
                YSmoothEnable = input.YSmoothEnable;
                ZSmoothEnable = input.ZSmoothEnable;
                ASmoothEnable = input.ASmoothEnable;

                _fsmThread = new Thread(FSM, ThreadPriority.Highest, input.FSMInterval);

            }
        }
    }
}
