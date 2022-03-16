using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Robot.Environment;
using Robot.Locomotion;
using Robot.Locomotion.TrajectoryWalk;
using Robot.Network;
using Robot.Utils;
using Robot.Vision.HeadControl;
using Robot.Vision.ImageProcessing;
using Math = System.Math;
using Thread = Robot.Utils.Thread;

namespace Robot.Behavior
{
    public class BehaviorControl
    {

        #region Private Data Member

        private readonly WalkManager _walkmanager;
        private readonly Head _head;
        private readonly Tracker _tracker;
        private readonly Search _search;
        private readonly Vision.Vision _vision;
        private readonly ImageProcess _imageProcess;
        private readonly Capture _capture;
        private readonly GameController _gameController;
        private readonly MotionManager _motionManager;
        private readonly Communication _communication;
        private readonly Controll _controll;
        private readonly Thread _behaviorControlThread;
        private GameController.GameControllerStatus _gameControllerStatus;
        private double _sight;
        private double _destination;
        private int _aimAndKick;
        private int _searchGoal;
        private int _detected;
        private bool _isFirstAttack;
        private bool _isFirstTime = true;
        private readonly Stopwatch _walkToBallAwardGoal;
        private bool _testPassed;
        private bool _goalCompleteDetected;
        private const int tiltPos = 60;
        private bool KickLeftLeg;
        public bool isGoalie;
        public bool CommunicationEnabled;
        #endregion

        #region Properties
        #region SearchBall
        public Utils.Range<double> BallStopAndSearchRange { get; set; }
        public Utils.Range<double> BallWalkAndSearchRange { get; set; }
        public Utils.Range<double> BallTurnAndSearchRange { get; set; }
        public Utils.Range<double> BallSecWalkAndSearchRange { get; set; }
        public double LittleWalkRate { get; set; }

        public int BallLostTimeToSearch { set; get; }
        #endregion

        #region WalkToBall
        public int CommunicationDistance { get; set; }
        public Range<int> BallStopTiltBounder { get; set; }
        public Range<int> StandAndTurnBounder { get; set; }
        public double PerseptionPresionWalkToBall { get; set; }
        public Utils.Range<double> TurnHeadDirection { get; set; }

        #endregion

        #region SearchGoal
        public Utils.Range<double> GoalStopAndSearchRange { get; set; }
        public Utils.Range<double> GoalWalkAndSearchRange { get; set; }
        public double PerseptionPresionGoalSearch { get; set; }
        public double[] SearchGoalFourStepLeftTurn { get; set; }
        public int IntervalGoalSearch { get; set; }

        #endregion

        #region TurnBall

        public Utils.Range<double> SightBoundaryRange { get; set; }
        public double PerseptionPresionTurn { get; set; }
        public double TurnPresion { get; set; }
        public double AimPerseptionPresion { get; set; }

        public double[] FourStepLeftTurn { get; set; }
        public double[] FourStepRightTurn { get; set; }
        public double[] FourStepBackWard { get; set; }
        #endregion

        #region Aim And Kick
        public double[] LittleFourStepForward { get; set; }
        public double[] LittleFourStepLeftSide { get; set; }
        public double[] LittleFourStepRightSide { get; set; }
        public double[] LittleFourStepBackWard { get; set; }
        public Utils.Range<int> BallXposLeftLeg;
        public Utils.Range<int> BallXposRightLeg;
        public Utils.Range<int> BallYposLeg;
        public int LeftKickMotionIndex;
        public int RightKickMotionIndex;
        public int SleepBeforeMotionPlay;
        public double RightOrLeftBoundar { get; set; }
        #endregion

        #region Walk To Ball Awards Goal
        public Utils.Range<double> BallLocationXReange { get; set; }
        public double[] RightWalkSettings { get; set; }
        public double[] LeftWalkSettings { get; set; }
        public int WalkTime { get; set; }
        #endregion

        #region Test
        public int TiltPos { get; set; }
        public int PanLeftPos { get; set; }
        public int PanRightPos { get; set; }
        public int Interval { get; set; }
        public int TurnGain { get; set; }
        #endregion

        #region Settings
        public bool GameControllerEnabled { get; set; }
        public bool AttackModeIsKick { get; set; }
        public bool RivalGoalIsBlue { get; set; }

        #endregion

        #endregion

        #region Constructor
        public BehaviorControl(WalkManager walkManager, Head head, Tracker tracker,
            Search search, Vision.Vision vision, ImageProcess imageProcess, Capture capture,
            GameController gameController, MotionManager motionManager, Communication communication, Controll controll)
        {
            _walkmanager = walkManager;
            _head = head;
            _tracker = tracker;
            _search = search;
            _vision = vision;
            _imageProcess = imageProcess;
            _capture = capture;
            _gameController = gameController;
            _motionManager = motionManager;
            _communication = communication;
            _controll = controll;
            _behaviorControlThread = new Thread(AttakerControl) { Priority = ThreadPriority.Highest, Interval = 5 };
            gameController.GameStatusCheanged += GameControllerStatusCheanged;
            _gameControllerStatus = gameController.GameStatus;
            _walkToBallAwardGoal = new Stopwatch();
            CurrentState = State.Start;
            _capture.Start();
            _communication.Start();
            _isFirstAttack = true;


            gameController.StartingModeCheanged += StartingModeCheanged;
            gameController.RivalResultCheanged += RivalResultCheanged;

            #region Initialize Properties
            TurnHeadDirection = new Range<double>(0, 0);
            BallStopAndSearchRange = new Range<double>(0, 0);
            BallWalkAndSearchRange = new Range<double>(0, 0);
            BallTurnAndSearchRange = new Range<double>(0, 0);
            BallSecWalkAndSearchRange = new Range<double>(0, 0);
            GoalStopAndSearchRange = new Range<double>(0, 0);
            GoalWalkAndSearchRange = new Range<double>(0, 0);
            BallStopTiltBounder = new Range<int>(0, 0);
            StandAndTurnBounder = new Range<int>(0, 0);
            SearchGoalFourStepLeftTurn = new double[5];
            SightBoundaryRange = new Range<double>(0, 0);
            FourStepLeftTurn = new double[5];
            FourStepRightTurn = new double[5];
            FourStepBackWard = new double[5];


            LittleFourStepForward = new double[5];
            LittleFourStepLeftSide = new double[5];
            LittleFourStepRightSide = new double[5];
            LittleFourStepBackWard = new double[5];
            BallXposLeftLeg = new Range<int>(0, 0);
            BallXposRightLeg = new Range<int>(0, 0); ;
            BallYposLeg = new Range<int>(0, 0);
            BallLocationXReange = new Range<double>(0, 0);
            RightWalkSettings = new double[4];
            LeftWalkSettings = new double[4];
            RightOrLeftBoundar = 0;

            #endregion
            LoadConfig("Config/Behavior.xml");


        }

        private void RivalResultCheanged(int result)
        {
            _isFirstAttack = true;
        }

        private void StartingModeCheanged(GameController.TstartingMode mode)
        {
            if (mode != GameController.TstartingMode.DropBall)
                _isFirstAttack = true;
        }


        private bool _fall;

        #endregion

        #region GameController Settings
        private void GameControllerStatusCheanged(GameController.GameControllerStatus status)
        {
            _gameControllerStatus = status;
            if (status == GameController.GameControllerStatus.Finish)
            {
                _search.Stop();
                _tracker.Stop();
      
               WalkStop(false);
               _head.Pan.Speed = _head.Tilt.Speed = 512;
               _head.Pan.Angle = 0;
               _head.Tilt.Angle = 0;
                if (_gameController.HalfTime == GameController.ThalfTime.SecondHalf &&
                    _gameController.RivalResult < _gameController.OurResult && !isGoalie)
                {
                    _behaviorControlThread.Sleep(500);
                    _motionManager.PlayMotion(14);
                }
            }
        }
        private bool IsPlay
        {
            get
            {
                if (isGoalie)
                {
                    return false;
                }
                if (GameControllerEnabled)
                {
                    return (_gameControllerStatus == GameController.GameControllerStatus.Play);
                }
             
                    return true;
            }
        }

        private bool isReady
        {
            get
            {
                if (GameControllerEnabled)
                    return (_gameControllerStatus == GameController.GameControllerStatus.Ready);
                return true;
            }
        }

        private bool IsSet
        {
            get
            {
                if (GameControllerEnabled)
                    return (_gameControllerStatus == GameController.GameControllerStatus.Set);
                return true;
            }
        }
        #endregion

        #region Start Stop Functions
        public void Start()
        {
            CurrentState = State.Start;

            if (isGoalie)
            {
                _walkmanager.PlayMotion(19);
            }
            
            _behaviorControlThread.Start();

        }
        public void Stop()
        {
            _behaviorControlThread.Stop();
        }
        #endregion

        #region State and Levels
        public State CurrentState { set; get; }
        public enum State
        {
            Start,
            SearchBall,
            WalkToBall,
            SearchGoal,
            AimAndKick,
            FallDown,
            WalkToBallAwardsGoal,
            TurnAroundBall,
            Test
        }
        #endregion

        #region AttakerControl

        public void AttakerControl()
        {

            if (_controll.RobotState != RobotState.Stable || _walkmanager.IsMotionPlaying)
            {
                _communication.MyDistance = -1;
               GoToStart();
                return;
            }



            switch (CurrentState)
            {

  
                case State.Start:
                    _communication.MyDistance = -1;
                    if (isReady || IsSet || IsPlay || isGoalie)
                    {
                        GotoSearchBallState();
                    }
                    break;

                case State.SearchBall:
                    _communication.MyDistance = -1;
                    if (isReady || IsSet || IsPlay || isGoalie)
                    {
                        if (_vision.Ball.FoundTime>1)
                        {
                            _search.Stop();
                            _tracker.Start();
                            if (IsPlay)
                            {
                                GotoWalkToBallState(); 
                            }
                        }

                        else if (_vision.Ball.LostTime >= BallLostTimeToSearch)
                        {
                            _tracker.Stop();
                            _search.Start();

                            if (IsPlay)
                            {
                                if (_vision.Ball.LostTime < BallStopAndSearchRange.Max)
                                {
                                    WalkStop(false);
                                }

                                if (_vision.Ball.LostTime > BallWalkAndSearchRange.Min &&
                                    _vision.Ball.LostTime < BallWalkAndSearchRange.Max)
                                
                                {
                                WalkStart();

                                    _walkmanager.X = _walkmanager.XRange.Max*LittleWalkRate;
                                    _walkmanager.Y = 0;
                                    _walkmanager.A = 0;

                          
                                }

                                else if (_vision.Ball.LostTime > BallTurnAndSearchRange.Min && _vision.Ball.LostTime < BallTurnAndSearchRange.Max)
                                {
                                    _walkmanager.X = 0;
                                    _walkmanager.Y = 0;
                                    _walkmanager.A = 0.5*_walkmanager.ARange.Max;
                                }
                                else if (_vision.Ball.LostTime > BallSecWalkAndSearchRange.Min && _vision.Ball.LostTime < BallSecWalkAndSearchRange.Max)
                                {

                                    _walkmanager.X = _walkmanager.XRange.Max * LittleWalkRate;
                                    _walkmanager.Y = 0;
                                    _walkmanager.A = 0;

                                }
                                else if (_vision.Ball.LostTime > BallSecWalkAndSearchRange.Max)
                                {
                                    _vision.Ball.LostTime = BallLostTimeToSearch + 1;
                                }

                            }
                        }
                    }
                    break;

                case State.WalkToBall:

                    if (!IsPlay)
                    {
                        GoToStart();
                        return;
                    }

                    if (_vision.Ball.LostTime >= BallLostTimeToSearch)
                    {
                        GotoSearchBallState();
                        return;
                    }
                    _communication.MyDistance = _vision.Ball.Distance;
     if(CommunicationEnabled)
     {
         if (_communication.TeamMateDistance != -1 && _vision.Ball.Distance < CommunicationDistance &&
         (_vision.Ball.Distance > _communication.TeamMateDistance))
         {
             var x = 3 * (_head.Tilt.Angle + 20);

             _walkmanager.X = x;
             _walkmanager.A = -1 * _head.Pan.Angle;
             _walkmanager.Y = 0;



             Console.WriteLine("Communication:" + _communication.TeamMateDistance);


             return;
         }
     }

                    if (!_walkmanager.IsRunning)
                    {
                        WalkStart();
                    }
                    var tilt = _head.Tilt.Angle;
                    var pan = _head.Pan.Angle;



                    double _xWalk = 0;
                    double _yWalk = 0;
                    double _aWalk = 0;

                    if (pan > _walkmanager.ARange.Max || pan < _walkmanager.ARange.Min)
                    {
                        if (tilt < -75)
                        {
                            _xWalk = _walkmanager.XRange.Min;
                        }
                        else
                        {
                            _xWalk = 0;
                        }


                        _aWalk = pan;
 

                    }
                    else
                    {


                        _xWalk = tilt + tiltPos;

                        _aWalk = pan;


                        if (pan < 5 && pan > -5 && -10 < _xWalk && 10 > _xWalk)
                        {
                            _destination = _imageProcess.GoalIsBlue ? 180 : 0;
                            _sight = _controll.Compass;
                            if (_destination != 0)
                            {
                                _sight = -1*_sight;
                            }
                            GoToTurnAroundBall();
                        }
  

                    }


                    _walkmanager.X = _xWalk;
                    _walkmanager.Y = _yWalk;
                    _walkmanager.A = -1*_aWalk;

                    break;

                case State.SearchGoal:
                    _communication.MyDistance = 1;

                    if (!IsPlay)
                    {
                        GoToStart();
                        break;
                    }

                    if (_vision.Goal.IsDetected)
                    {
                        if (_detected > PerseptionPresionGoalSearch)
                        {
                            _search.Stop();
                            var panMovingDelta = (int)Math.Round(Math.Round((double)(_capture.FrameCenter.X - Convert.ToInt32(_vision.Goal.Location.X))));
                            _head.Pan.Position += panMovingDelta;
                            _behaviorControlThread.Sleep(IntervalGoalSearch);
                            GoToTurnAroundBall();
                            break;
                        }
                        _detected++;
                    }

                    else if (_vision.Goal.LostTime > GoalStopAndSearchRange.Min && _vision.Goal.LostTime < GoalStopAndSearchRange.Max)
                    {
                        _detected = 0;
                        WalkStop(false);
                        _search.Start();

                    }

                    else if (_vision.Goal.LostTime > GoalWalkAndSearchRange.Min && _vision.Goal.LostTime < GoalWalkAndSearchRange.Max)
                    {
                        _detected = 0;
                        _search.Start();

                    }
                    else if (_vision.Goal.LostTime >= GoalWalkAndSearchRange.Max)
                    {
                        _detected = 0;
                        GoToStart();
                    }

                    break;

                case State.TurnAroundBall:

                    _communication.MyDistance = 1;
                    if (!IsPlay)
                    {
                        GoToStart();
                        break;
                    }


                    if (Math.Abs(CalculateCompassDistance(_destination - _controll.Compass)) > PerseptionPresionTurn && _sight >= 0 )
                    {
                        _aimAndKick = 0;

                        if (_vision.Ball.IsDetected)
                        {

                            if (_head.Tilt.Angle > -40)
                            {
                                GotoWalkToBallState();
                            }


                           double x = _head.Tilt.Angle + tiltPos -10 ;
                           double y = _walkmanager.YRange.Max ;
                           double a = _walkmanager.ARange.Max - Math.Abs(_head.Pan.Angle/2);


                            _walkmanager.X = x;
                            _walkmanager.Y = y;
                            _walkmanager.A = a;
                        }

                        else if (_vision.Ball.LostTime > BallLostTimeToSearch)
                        {
                            GotoSearchBallState();
                        }

                    }
                    else if (Math.Abs(CalculateCompassDistance(_destination - _controll.Compass)) > PerseptionPresionTurn && _sight < 0 )
                    {
                        _aimAndKick = 0;

                        if (_vision.Ball.IsDetected)
                        {
                            if (_head.Tilt.Angle > -50)
                            {
                                GotoWalkToBallState();
                            }


                            double x = _head.Tilt.Angle + tiltPos-10;
                            double y = _walkmanager.YRange.Min;
                            double a = _walkmanager.ARange.Min + Math.Abs(_head.Pan.Angle / 2);


                            _walkmanager.X = x;
                            _walkmanager.Y = y;
                            _walkmanager.A = a;


                        }
                        else if (_vision.Ball.LostTime > BallLostTimeToSearch)
                        {
                            GotoSearchBallState();

                        }
                    }
                    else
                    {
                        _walkmanager.A = 0;
                        _walkmanager.X = 0;
                        _walkmanager.Y = 0;
                        if (_aimAndKick > AimPerseptionPresion)
                        {


                            if (true) //_goalCompleteDetected || _testPassed
                            {


                                var x =
                                 Math.Abs(CalculateCompassDistance(_destination - _controll.Compass));
                           
                                if (AttackModeIsKick)
                                    GoToAimAndKickState();
                                else
                                    GotoWalkToBallAwardsGoal();

                            }


                            break;
                        }
                        _aimAndKick++;
                    }
                    break;

                case State.AimAndKick:
                    _communication.MyDistance = 1;
                    if (!IsPlay)
                    {
                        GoToStart();
                        break;
                    }



                    if (_vision.Ball.LostTime<BallLostTimeToSearch)
                    {



                        if (KickLeftLeg)
                        {

                            var x = 0;
                            var y = 0;
                            var a = 0;
                            var rightLeft = false;
                            var forwardBackward = false;


                            if (_vision.Ball.Location.Y >= BallYposLeg.Max)
                            {
                                x = _walkmanager.XRange.Min/2;
                            }
                            else if (_vision.Ball.Location.Y < BallYposLeg.Min)
                            {
                                x = _walkmanager.XRange.Max/2;
                            }
                            else
                            {
                                x = 0;
                               
                                forwardBackward = true;
                            }
                            if (_vision.Ball.Location.X >= BallXposLeftLeg.Max )
                            {

                                y = _walkmanager.YRange.Min / 2;
                                a = _walkmanager.ARange.Max / 3;
                         
                            }
                            else if (_vision.Ball.Location.X < BallXposLeftLeg.Min)
                            {
                                y = _walkmanager.YRange.Max / 2;
                                a = _walkmanager.ARange.Min / 3;
                             
                             
                            }
                            else
                            {
                                y = 0;
                                a = 0;
                                rightLeft = true;
                            }

                            _walkmanager.X = x;
                            _walkmanager.Y = y;
                            _walkmanager.A = a;
                       if(rightLeft && forwardBackward)
                            {

                                WalkStop(false);

                            
                                _walkmanager.PlayMotion(LeftKickMotionIndex);


                                if (_vision.Ball.LostTime < BallLostTimeToSearch)
                                {

                                    GoToAimAndKickState();

                                }

                                else
                                {
                                    _head.Pan.Speed = _head.Tilt.Speed = 512;
                                    _head.Tilt.Position = 490;
                                    _head.Pan.Position = 512;
                                    _behaviorControlThread.Sleep(1000);

                                    if (_vision.Ball.LostTime < BallLostTimeToSearch)
                                    {
                                        GotoWalkToBallState();
                                    }
                                    else
                                    {
                                        GoToStart();
                                    }
                                }
                            }
                        }
                        else
                        {

                          
                   var x = 0;
                            var y = 0;
                            var a = 0;
                            var rightLeft = false;
                            var forwardBackward = false;


                            if (_vision.Ball.Location.Y >= BallYposLeg.Max)
                            {
                                x = _walkmanager.XRange.Min/2;
                            }
                            else if (_vision.Ball.Location.Y < BallYposLeg.Min)
                            {
                                x = _walkmanager.XRange.Max/2;
                            }
                            else
                            {
                                x = 0;
                               
                                forwardBackward = true;
                            }
                            if (_vision.Ball.Location.X >= BallXposRightLeg.Max )
                            {
                                y = _walkmanager.YRange.Min / 2;
                                a = _walkmanager.ARange.Max / 3;

                    

                            }
                            else if (_vision.Ball.Location.X < BallXposRightLeg.Min)
                            {
                      
                                y = _walkmanager.YRange.Max / 2;
                                a = _walkmanager.ARange.Min / 3;
                            }
                            else
                            {
                                y = 0;
                                a = 0;
                                rightLeft = true;
                            }

                            _walkmanager.X = x;
                            _walkmanager.Y = y;
                            _walkmanager.A = a;
                       if(rightLeft && forwardBackward)
                            {
                                WalkStop(false);

                             
                       
                            
                                _walkmanager.PlayMotion(RightKickMotionIndex);


                                if (_vision.Ball.LostTime < BallLostTimeToSearch)
                                {

                                    GoToAimAndKickState();

                                }

                                else
                                {
                                    _head.Pan.Speed = _head.Tilt.Speed = 512;
                                    _head.Tilt.Position = 490;
                                    _head.Pan.Position = 512;
                                    _behaviorControlThread.Sleep(1000);
                                    if (_vision.Ball.LostTime < BallLostTimeToSearch)
                                    {
                                        GotoWalkToBallState();
                                    }
                                    else
                                    {
                                        GoToStart();
                                    }
                                }
                            }



                                
                        }


                    }
                    else if (_vision.Ball.LostTime >= BallLostTimeToSearch)
                    {

                        GotoSearchBallState();
                    }

                    break;



                case State.WalkToBallAwardsGoal:
                    _communication.MyDistance = 1;

                    if (_walkToBallAwardGoal.ElapsedMilliseconds > WalkTime)
                    {

                        GotoSearchBallState();

                    }
                    else
                    {

                        _walkmanager.X = _walkmanager.XRange.Max;
                        _walkmanager.Y = 0;
                        _walkmanager.A = 0;
                  
                    }

                    break;
                case State.Test:
                    if (_vision.Ball.IsDetected)
                    {
                        GotoWalkToBallState();
                    }
                    else
                    {
                        GoToStart();
                    }

                    break;


            }

        }

        #endregion


        private void GoToTurnAroundBall()
        {
            _search.Stop();



            _goalCompleteDetected = _imageProcess.GoalCompleteDetected;

            _imageProcess.onfildOff = true;



            _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
            CurrentState = State.TurnAroundBall;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Turn Around Ball");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private double CalculateCompassDistance(double x)
        {
            if (x > 180)
            {
                return x -= 360;
            }
            if (x < -180)
            {
                return x += 360;
            }
            return x;
        }

        private void GoToTestState()
        {
            _tracker.Start();
            _head.Tilt.Speed = 50;
            _head.Tilt.Angle = -20;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Test");
            Console.ForegroundColor = ConsoleColor.White;

            CurrentState = State.Test;
        }

        private void GoToStart()
        {

            _imageProcess.onfildOff = false;
            _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);

            _search.SelectSearchMethod(Search.SearchMethod.Around);
            WalkStop(false);

            _search.Stop();
            _tracker.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Start");
            Console.ForegroundColor = ConsoleColor.White;


       


            CurrentState = State.Start;
        }

        private void GotoSearchBallState()
        {
            _imageProcess.onfildOff = false;
            WalkStop(false);
            switch (CurrentState)
            {
                case State.Start:
                    _searchGoal = 0;
                    _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
                    _search.SelectSearchMethod(Search.SearchMethod.Around);
                    _search.Start();
      

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SearchBall From Start");
                    Console.ForegroundColor = ConsoleColor.White;
                    CurrentState = State.SearchBall;
                    break;
                case State.WalkToBall:
                    _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
                    _search.SelectSearchMethod(Search.SearchMethod.Around);
                    _search.Start();
            

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SearchBall From WalkToBall");
                    Console.ForegroundColor = ConsoleColor.White;
                    CurrentState = State.SearchBall;
                    break;
                case State.AimAndKick:
                    _vision.Ball.IsDetected = false;
                    _vision.Goal.IsDetected = false;
                    _aimAndKick = 0;
                

                    _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
                    _search.SelectSearchMethod(Search.SearchMethod.Around);
                    _search.Start();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SearchBall From AimAndKick");
                    Console.ForegroundColor = ConsoleColor.White;
                    CurrentState = State.SearchBall;
                    break;
                case State.WalkToBallAwardsGoal:
                    _vision.Ball.IsDetected = false;
                    _vision.Goal.IsDetected = false;
                    _aimAndKick = 0;
                 

                    _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
                    _search.SelectSearchMethod(Search.SearchMethod.Around);
                    _search.Start();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SearchBall From AwardsGoal");
                    Console.ForegroundColor = ConsoleColor.White;
                    CurrentState = State.SearchBall;
                    break;
                case State.TurnAroundBall:
                    _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
                    _search.SelectSearchMethod(Search.SearchMethod.Around);
                    _search.Start();
               

                    _aimAndKick = 0;
              
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SearchBall From TurnAroundBall");
                    Console.ForegroundColor = ConsoleColor.White;
                    CurrentState = State.SearchBall;
                    break;
            }
        }

        private void GotoWalkToBallState()
        {
            _imageProcess.onfildOff = false;

            _testPassed = false;
            _search.Stop();
            _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
            _tracker.Start();
            WalkStart();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WalkToBall");
            Console.ForegroundColor = ConsoleColor.White;
            CurrentState = State.WalkToBall;

        }

        private void GoToAimAndKickState()
        {
            _imageProcess.onfildOff = true;
            _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
            WalkStart();
            _tracker.Stop();
            _search.Stop();

            _head.Pan.Speed = _head.Tilt.Speed = 200;
            _head.Pan.Angle = 0;
            _head.Tilt.Angle = -70;
         

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AimAndKick");
            Console.ForegroundColor = ConsoleColor.White;
            _vision.Ball.LostTime = 0;

            _behaviorControlThread.Sleep(100);
            KickLeftLeg =
          _vision.Ball.Location.X < RightOrLeftBoundar;

            Console.WriteLine("Ball Location={0} RightOrLeft={1} KickLeftLeg={2}",_vision.Ball.Location, RightOrLeftBoundar,KickLeftLeg);

            CurrentState = State.AimAndKick;

        }

        private void GotoSearchGoalState()
        {

            _imageProcess.onfildOff = false;
            if (CurrentState == State.WalkToBall)
            {
                _tracker.Stop();
                _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourGoal);
                _search.SelectSearchMethod(Search.SearchMethod.Far);
                _search.Start();
WalkStop(false);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("SearchGoal");
                Console.ForegroundColor = ConsoleColor.White;
                CurrentState = State.SearchGoal;

            }
        }




        private void GotoWalkToBallAwardsGoal()
        {
            _imageProcess.onfildOff = false;
            _search.Stop();
            _tracker.Stop();
            _head.Tilt.Speed = 1023;
            _head.Pan.Speed = 1023;
            _head.Tilt.Position = 275;
            _head.Pan.Position = 512;
            if (_walkToBallAwardGoal.IsRunning)
            {
                _walkToBallAwardGoal.Restart();
            }
            else
            {
                _walkToBallAwardGoal.Start();
            }
            _imageProcess.SelectProsessedObjectFunction(ImageProcess.ProcessedObjectFunction.ContourBall);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("WalkToBallAwardsGoal");
            Console.ForegroundColor = ConsoleColor.White;

            CurrentState = State.WalkToBallAwardsGoal;
        }



        #region WalkFunctions

        private void WalkStart()
        {
            if (!_walkmanager.IsRunning)
            {
                _walkmanager.X = 0;
                _walkmanager.Y = 0;
                _walkmanager.A = 0;
                _walkmanager.WalkStart();
                _behaviorControlThread.Sleep((_walkmanager.ZRange.Max - _walkmanager.ZRange.Min) * _walkmanager.ZUpdateInterval);
            }
        }

        private void WalkStop(bool isForse)
        {
            if (_walkmanager.IsRunning)
            {
                _walkmanager.X = 0;
                _walkmanager.Y = 0;
                _walkmanager.A = 0;
                _walkmanager.WalkStop(isForse);
                _behaviorControlThread.Sleep((_walkmanager.ZRange.Max - _walkmanager.ZRange.Min) * _walkmanager.ZUpdateInterval);
            }

        }




        #endregion

        #region Configuration
        public void LoadConfig(string path)
        {


            var xmlDoc = XDocument.Load(path);


            #region SearchBall
            var searchBallConfig = from query in xmlDoc.Descendants("SearchBall")
                                   select new
                                   {
                                       BallStopAndSearchRangeMin = Convert.ToDouble(query.Attribute("BallStopAndSearchRangeMin").Value),
                                       BallStopAndSearchRangeMax = Convert.ToDouble(query.Attribute("BallStopAndSearchRangeMax").Value),
                                       BallWalkAndSearchRangeMin = Convert.ToDouble(query.Attribute("BallWalkAndSearchRangeMin").Value),
                                       BallWalkAndSearchRangeMax = Convert.ToDouble(query.Attribute("BallWalkAndSearchRangeMax").Value),
                                       BallTurnAndSearchRangeMin = Convert.ToDouble(query.Attribute("BallTurnAndSearchRangeMin").Value),
                                       BallTurnAndSearchRangeMax = Convert.ToDouble(query.Attribute("BallTurnAndSearchRangeMax").Value),
                                       BallSecWalkAndSearchRangeMin = Convert.ToDouble(query.Attribute("BallSecWalkAndSearchRangeMin").Value),
                                       BallSecWalkAndSearchRangeMax = Convert.ToDouble(query.Attribute("BallSecWalkAndSearchRangeMax").Value),
                                       LittleWalkRate = Convert.ToDouble(query.Attribute("LittleWalkRate").Value),
                                       BallLostTimeToSearch = Convert.ToInt32(query.Attribute("BallLostTimeToSearch").Value),

                                   };

            var searchBall = searchBallConfig.Single();

            BallStopAndSearchRange.Min = searchBall.BallStopAndSearchRangeMin;
            BallStopAndSearchRange.Max = searchBall.BallStopAndSearchRangeMax;
            BallWalkAndSearchRange.Min = searchBall.BallWalkAndSearchRangeMin;
            BallWalkAndSearchRange.Max = searchBall.BallWalkAndSearchRangeMax;
            BallTurnAndSearchRange.Min = searchBall.BallTurnAndSearchRangeMin;
            BallTurnAndSearchRange.Max = searchBall.BallTurnAndSearchRangeMax;
            BallSecWalkAndSearchRange.Min = searchBall.BallSecWalkAndSearchRangeMin;
            BallSecWalkAndSearchRange.Max = searchBall.BallSecWalkAndSearchRangeMax;
            LittleWalkRate = searchBall.LittleWalkRate;
            BallLostTimeToSearch = searchBall.BallLostTimeToSearch;

            #endregion

            #region WalkToBall
            var walkToBallConfig = from query in xmlDoc.Descendants("WalkToBall")
                                   select new
                                   {
                                       CommunicationDistance = Convert.ToInt32(query.Attribute("CommunicationDistance").Value),
                                       BallStopTiltBounderMin = Convert.ToInt32(query.Attribute("BallStopTiltBounderMin").Value),
                                       BallStopTiltBounderMax = Convert.ToInt32(query.Attribute("BallStopTiltBounderMax").Value),

                                       StandAndTurnBounderMin = Convert.ToInt32(query.Attribute("StandAndTurnBounderMin").Value),
                                       StandAndTurnBounderMax = Convert.ToInt32(query.Attribute("StandAndTurnBounderMax").Value),

                                       TurnHeadDirectionMin = Convert.ToDouble(query.Attribute("TurnHeadDirectionMin").Value),
                                       TurnHeadDirectionMax = Convert.ToDouble(query.Attribute("TurnHeadDirectionMax").Value),
                                       XwalkValue = Convert.ToInt32(query.Attribute("XwalkValue").Value),
                                       YwalkValue = Convert.ToInt32(query.Attribute("YwalkValue").Value),
                                       AwalkValue = Convert.ToInt32(query.Attribute("AwalkValue").Value),
                                       PerseptionPresionWalkToBall = Convert.ToDouble(query.Attribute("PerseptionPresionWalkToBall").Value),
                                   };

            var walkToBall = walkToBallConfig.Single();
            CommunicationDistance = walkToBall.CommunicationDistance;

            BallStopTiltBounder.Min = walkToBall.BallStopTiltBounderMin;
            BallStopTiltBounder.Max = walkToBall.BallStopTiltBounderMax;

            StandAndTurnBounder.Min = walkToBall.StandAndTurnBounderMin;
            StandAndTurnBounder.Max = walkToBall.StandAndTurnBounderMax;

            TurnHeadDirection.Min = walkToBall.TurnHeadDirectionMin;
            TurnHeadDirection.Max = walkToBall.TurnHeadDirectionMax;

            PerseptionPresionWalkToBall = walkToBall.PerseptionPresionWalkToBall;

            #endregion

            #region SearchGoal
            var searchGoalConfig = from query in xmlDoc.Descendants("SearchGoal")
                                   select new
                                   {
                                       GoalStopAndSearchRangeMin = Convert.ToDouble(query.Attribute("GoalStopAndSearchRangeMin").Value),
                                       GoalStopAndSearchRangeMax = Convert.ToDouble(query.Attribute("GoalStopAndSearchRangeMax").Value),
                                       GoalWalkAndSearchRangeMin = Convert.ToDouble(query.Attribute("GoalWalkAndSearchRangeMin").Value),
                                       GoalWalkAndSearchRangeMax = Convert.ToDouble(query.Attribute("GoalWalkAndSearchRangeMax").Value),
                                       PerseptionPresion = Convert.ToDouble(query.Attribute("PerseptionPresion").Value),
                                       IntervalGoalSearch = Convert.ToInt32(query.Attribute("IntervalGoalSearch").Value),
                                       SearchGoalFourStepLeftTurnX = Convert.ToDouble(query.Attribute("SearchGoalFourStepLeftTurnX").Value),
                                       SearchGoalFourStepLeftTurnY = Convert.ToDouble(query.Attribute("SearchGoalFourStepLeftTurnY").Value),
                                       SearchGoalFourStepLeftTurnZ = Convert.ToDouble(query.Attribute("SearchGoalFourStepLeftTurnZ").Value),
                                       SearchGoalFourStepLeftTurnA = Convert.ToInt32(query.Attribute("SearchGoalFourStepLeftTurnA").Value),
                                       SearchGoalFourStepLeftTurnT = Convert.ToDouble(query.Attribute("SearchGoalFourStepLeftTurnT").Value),

                                   };

            var searchGoal = searchGoalConfig.Single();

            GoalStopAndSearchRange.Min = searchGoal.GoalStopAndSearchRangeMin;
            GoalStopAndSearchRange.Max = searchGoal.GoalStopAndSearchRangeMax;
            GoalWalkAndSearchRange.Min = searchGoal.GoalWalkAndSearchRangeMin;
            GoalWalkAndSearchRange.Max = searchGoal.GoalWalkAndSearchRangeMax;
            PerseptionPresionGoalSearch = searchGoal.PerseptionPresion;
            IntervalGoalSearch = searchGoal.IntervalGoalSearch;
            SearchGoalFourStepLeftTurn[0] = searchGoal.SearchGoalFourStepLeftTurnX;
            SearchGoalFourStepLeftTurn[1] = searchGoal.SearchGoalFourStepLeftTurnY;
            SearchGoalFourStepLeftTurn[2] = searchGoal.SearchGoalFourStepLeftTurnZ;
            SearchGoalFourStepLeftTurn[3] = searchGoal.SearchGoalFourStepLeftTurnA;
            SearchGoalFourStepLeftTurn[4] = searchGoal.SearchGoalFourStepLeftTurnT;
            #endregion

            #region TurnBall
            var turnBallConfig = from query in xmlDoc.Descendants("TurnBall")
                                 select new
                                 {
                                     SightBoundaryRangeMin = Convert.ToDouble(query.Attribute("SightBoundaryRangeMin").Value),
                                     SightBoundaryRangeMax = Convert.ToDouble(query.Attribute("SightBoundaryRangeMax").Value),
                                     TurnPresion = Convert.ToDouble(query.Attribute("TurnPresion").Value),
                                     TurnPerseptionPresion = Convert.ToDouble(query.Attribute("TurnPerseptionPresion").Value),

                                     FourStepLeftTurnX = Convert.ToDouble(query.Attribute("FourStepLeftTurnX").Value),
                                     FourStepLeftTurnY = Convert.ToDouble(query.Attribute("FourStepLeftTurnY").Value),
                                     FourStepLeftTurnZ = Convert.ToDouble(query.Attribute("FourStepLeftTurnZ").Value),
                                     FourStepLeftTurnA = Convert.ToDouble(query.Attribute("FourStepLeftTurnA").Value),
                                     FourStepLeftTurnT = Convert.ToDouble(query.Attribute("FourStepLeftTurnT").Value),

                                     FourStepRightTurnX = Convert.ToDouble(query.Attribute("FourStepRightTurnX").Value),
                                     FourStepRightTurnY = Convert.ToDouble(query.Attribute("FourStepRightTurnY").Value),
                                     FourStepRightTurnZ = Convert.ToDouble(query.Attribute("FourStepRightTurnZ").Value),
                                     FourStepRightTurnA = Convert.ToDouble(query.Attribute("FourStepRightTurnA").Value),
                                     FourStepRightTurnT = Convert.ToDouble(query.Attribute("FourStepRightTurnT").Value),

                                     FourStepBackWardX = Convert.ToDouble(query.Attribute("FourStepBackWardX").Value),
                                     FourStepBackWardY = Convert.ToDouble(query.Attribute("FourStepBackWardY").Value),
                                     FourStepBackWardZ = Convert.ToDouble(query.Attribute("FourStepBackWardZ").Value),
                                     FourStepBackWardA = Convert.ToDouble(query.Attribute("FourStepBackWardA").Value),
                                     FourStepBackWardT = Convert.ToDouble(query.Attribute("FourStepBackWardT").Value),

                                     PerseptionPresionAim = Convert.ToDouble(query.Attribute("PerseptionPresionAim").Value),
                                 };

            var turnBall = turnBallConfig.Single();
            SightBoundaryRange.Min = turnBall.SightBoundaryRangeMin;
            SightBoundaryRange.Max = turnBall.SightBoundaryRangeMax;
            TurnPresion = turnBall.TurnPresion;
            PerseptionPresionTurn = turnBall.TurnPerseptionPresion;
            FourStepLeftTurn[0] = turnBall.FourStepLeftTurnX;
            FourStepLeftTurn[1] = turnBall.FourStepLeftTurnY;
            FourStepLeftTurn[2] = turnBall.FourStepLeftTurnZ;
            FourStepLeftTurn[3] = turnBall.FourStepLeftTurnA;
            FourStepLeftTurn[4] = turnBall.FourStepLeftTurnT;
            FourStepRightTurn[0] = turnBall.FourStepRightTurnX;
            FourStepRightTurn[1] = turnBall.FourStepRightTurnY;
            FourStepRightTurn[2] = turnBall.FourStepRightTurnZ;
            FourStepRightTurn[3] = turnBall.FourStepRightTurnA;
            FourStepRightTurn[4] = turnBall.FourStepRightTurnT;
            FourStepBackWard[0] = turnBall.FourStepBackWardX;
            FourStepBackWard[1] = turnBall.FourStepBackWardY;
            FourStepBackWard[2] = turnBall.FourStepBackWardZ;
            FourStepBackWard[3] = turnBall.FourStepBackWardA;
            FourStepBackWard[4] = turnBall.FourStepBackWardT;
            AimPerseptionPresion = turnBall.PerseptionPresionAim;

            #endregion

            #region AimAndKick
            var aimAndKickConfig = from query in xmlDoc.Descendants("AimAndKick")
                                   select new
                                   {
                                       LittleFourStepForwardX = Convert.ToDouble(query.Attribute("LittleFourStepForwardX").Value),
                                       LittleFourStepForwardY = Convert.ToDouble(query.Attribute("LittleFourStepForwardY").Value),
                                       LittleFourStepForwardZ = Convert.ToDouble(query.Attribute("LittleFourStepForwardZ").Value),
                                       LittleFourStepForwardA = Convert.ToDouble(query.Attribute("LittleFourStepForwardA").Value),
                                       LittleFourStepForwardT = Convert.ToDouble(query.Attribute("LittleFourStepForwardT").Value),

                                       FourStepLeftTurnX = Convert.ToDouble(query.Attribute("LittleFourStepLeftSideX").Value),
                                       FourStepLeftTurnY = Convert.ToDouble(query.Attribute("LittleFourStepLeftSideY").Value),

                                       FourStepLeftTurnZ = Convert.ToDouble(query.Attribute("LittleFourStepLeftSideZ").Value),
                                       FourStepLeftTurnA = Convert.ToDouble(query.Attribute("LittleFourStepLeftSideA").Value),
                                       FourStepLeftTurnT = Convert.ToDouble(query.Attribute("LittleFourStepLeftSideT").Value),

                                       FourStepRightTurnX = Convert.ToDouble(query.Attribute("LittleFourStepRightSideX").Value),
                                       FourStepRightTurnY = Convert.ToDouble(query.Attribute("LittleFourStepRightSideY").Value),
                                       FourStepRightTurnZ = Convert.ToDouble(query.Attribute("LittleFourStepRightSideZ").Value),
                                       FourStepRightTurnA = Convert.ToDouble(query.Attribute("LittleFourStepRightSideA").Value),
                                       FourStepRightTurnT = Convert.ToDouble(query.Attribute("LittleFourStepRightSideT").Value),

                                       FourStepBackWardX = Convert.ToDouble(query.Attribute("LittleFourStepBackWardX").Value),
                                       FourStepBackWardY = Convert.ToDouble(query.Attribute("LittleFourStepBackWardY").Value),
                                       FourStepBackWardZ = Convert.ToDouble(query.Attribute("LittleFourStepBackWardZ").Value),
                                       FourStepBackWardA = Convert.ToDouble(query.Attribute("LittleFourStepBackWardA").Value),
                                       FourStepBackWardT = Convert.ToDouble(query.Attribute("LittleFourStepBackWardT").Value),


                                       RightOrLeftBoundar = Convert.ToDouble(query.Attribute("RightOrLeftBoundar").Value),
                                       SleepBeforeMotionPlay = Convert.ToInt32(query.Attribute("SleepBeforeMotionPlay").Value),
                                       RightKickIndex = Convert.ToInt32(query.Attribute("RightKickIndex").Value),
                                       LeftKickIndex = Convert.ToInt32(query.Attribute("LeftKickIndex").Value),
                                       BallYposMin = Convert.ToInt32(query.Attribute("BallYposMin").Value),
                                       BallYposMax = Convert.ToInt32(query.Attribute("BallYposMax").Value),
                                       BallXposLeftLegMin = Convert.ToInt32(query.Attribute("BallXposLeftLegMin").Value),
                                       BallXposLeftLegMax = Convert.ToInt32(query.Attribute("BallXposLeftLegMax").Value),
                                       BallXposRightLegMin = Convert.ToInt32(query.Attribute("BallXposRightLegMin").Value),
                                       BallXposRightLegMax = Convert.ToInt32(query.Attribute("BallXposRightLegMax").Value),
                                   };

            var aimAndKick = aimAndKickConfig.Single();
            LittleFourStepForward[0] = aimAndKick.LittleFourStepForwardX;
            LittleFourStepForward[1] = aimAndKick.LittleFourStepForwardY;
            LittleFourStepForward[2] = aimAndKick.LittleFourStepForwardZ;
            LittleFourStepForward[3] = aimAndKick.LittleFourStepForwardA;
            LittleFourStepForward[4] = aimAndKick.LittleFourStepForwardT;

            LittleFourStepLeftSide[0] = aimAndKick.FourStepLeftTurnX;
            LittleFourStepLeftSide[1] = aimAndKick.FourStepLeftTurnY;
            LittleFourStepLeftSide[2] = aimAndKick.FourStepLeftTurnZ;
            LittleFourStepLeftSide[3] = aimAndKick.FourStepLeftTurnA;
            LittleFourStepLeftSide[4] = aimAndKick.FourStepLeftTurnT;

            LittleFourStepRightSide[0] = aimAndKick.FourStepRightTurnX;
            LittleFourStepRightSide[1] = aimAndKick.FourStepRightTurnY;
            LittleFourStepRightSide[2] = aimAndKick.FourStepRightTurnZ;
            LittleFourStepRightSide[3] = aimAndKick.FourStepRightTurnA;
            LittleFourStepRightSide[4] = aimAndKick.FourStepRightTurnT;

            LittleFourStepBackWard[0] = aimAndKick.FourStepBackWardX;
            LittleFourStepBackWard[1] = aimAndKick.FourStepBackWardY;
            LittleFourStepBackWard[2] = aimAndKick.FourStepBackWardZ;
            LittleFourStepBackWard[3] = aimAndKick.FourStepBackWardA;
            LittleFourStepBackWard[4] = aimAndKick.FourStepBackWardT;

            RightOrLeftBoundar = aimAndKick.RightOrLeftBoundar;
            SleepBeforeMotionPlay = aimAndKick.SleepBeforeMotionPlay;
            RightKickMotionIndex = aimAndKick.RightKickIndex;
            LeftKickMotionIndex = aimAndKick.LeftKickIndex;
            BallYposLeg.Min = aimAndKick.BallYposMin;
            BallYposLeg.Max = aimAndKick.BallYposMax;
            BallXposLeftLeg.Min = aimAndKick.BallXposLeftLegMin;
            BallXposLeftLeg.Max = aimAndKick.BallXposLeftLegMax;
            BallXposRightLeg.Min = aimAndKick.BallXposRightLegMin;
            BallXposRightLeg.Max = aimAndKick.BallXposRightLegMax;

            #endregion

            #region WalkToBallAwardsGoal
            var walkToBallAwardsGoalConfig = from query in xmlDoc.Descendants("WalkToBallAwardsGoal")
                                             select new
                                             {
                                                 BallLocationXReangeMin = Convert.ToDouble(query.Attribute("BallLocationXReangeMin").Value),
                                                 BallLocationXReangeMax = Convert.ToDouble(query.Attribute("BallLocationXReangeMax").Value),
                                                 RightWalkSettingsX = Convert.ToDouble(query.Attribute("RightWalkSettingsX").Value),
                                                 RightWalkSettingsY = Convert.ToDouble(query.Attribute("RightWalkSettingsY").Value),
                                                 RightWalkSettingsA = Convert.ToDouble(query.Attribute("RightWalkSettingsA").Value),
                                                 RightWalkSettingsP = Convert.ToInt32(query.Attribute("RightWalkSettingsP").Value),
                                                 LeftWalkSettingsX = Convert.ToDouble(query.Attribute("LeftWalkSettingsX").Value),
                                                 LeftWalkSettingsY = Convert.ToDouble(query.Attribute("LeftWalkSettingsY").Value),
                                                 LeftWalkSettingsA = Convert.ToDouble(query.Attribute("LeftWalkSettingsA").Value),
                                                 LeftWalkSettingsP = Convert.ToInt32(query.Attribute("LeftWalkSettingsP").Value),
                                                 WalkTime = Convert.ToInt32(query.Attribute("WalkTime").Value),

                                             };

            var walkToBallAwardsGoal = walkToBallAwardsGoalConfig.Single();
            BallLocationXReange.Min = walkToBallAwardsGoal.BallLocationXReangeMin;
            BallLocationXReange.Max = walkToBallAwardsGoal.BallLocationXReangeMax;
            RightWalkSettings[0] = walkToBallAwardsGoal.RightWalkSettingsX;
            RightWalkSettings[1] = walkToBallAwardsGoal.RightWalkSettingsY;
            RightWalkSettings[2] = walkToBallAwardsGoal.RightWalkSettingsA;
            RightWalkSettings[3] = walkToBallAwardsGoal.RightWalkSettingsP;
            LeftWalkSettings[0] = walkToBallAwardsGoal.LeftWalkSettingsX;
            LeftWalkSettings[1] = walkToBallAwardsGoal.LeftWalkSettingsY;
            LeftWalkSettings[2] = walkToBallAwardsGoal.LeftWalkSettingsA;
            LeftWalkSettings[3] = walkToBallAwardsGoal.LeftWalkSettingsP;
            WalkTime = walkToBallAwardsGoal.WalkTime;

            #endregion

            #region Test
            var testConfig = from query in xmlDoc.Descendants("Test")
                             select new
                             {
                                 TiltPos = Convert.ToInt32(query.Attribute("TiltPos").Value),
                                 PanLeftPos = Convert.ToInt32(query.Attribute("PanLeftPos").Value),
                                 PanRightPos = Convert.ToInt32(query.Attribute("PanRightPos").Value),
                                 Interval = Convert.ToInt32(query.Attribute("Interval").Value),
                                 TurnGain = Convert.ToInt32(query.Attribute("TurnGain").Value),
                             };

            var test = testConfig.Single();
            TiltPos = test.TiltPos;
            PanLeftPos = test.PanLeftPos;
            PanRightPos = test.PanRightPos;
            Interval = test.Interval;
            TurnGain = test.TurnGain;

            #endregion

            #region Settings
            var settingsConfig = from query in xmlDoc.Descendants("Settings")
                                 select new
                                 {
                                     IsGoalie = Convert.ToBoolean(query.Attribute("IsGoalie").Value),
                                     CommunicationEnabled = Convert.ToBoolean(query.Attribute("CommunicationEnabled").Value),
                                     GameControllerEnabled = Convert.ToBoolean(query.Attribute("GameControllerEnabled").Value),
                                     AttackModeIsKick = Convert.ToBoolean(query.Attribute("AttackModeIsKick").Value),
                                     RivalGoalIsBlue = Convert.ToBoolean(query.Attribute("RivalGoalIsBlue").Value),

                                 };

            var settings = settingsConfig.Single();
            GameControllerEnabled = settings.GameControllerEnabled;
            AttackModeIsKick = settings.AttackModeIsKick;
            RivalGoalIsBlue = settings.RivalGoalIsBlue;
            isGoalie = settings.IsGoalie;
            CommunicationEnabled = settings.CommunicationEnabled;
            #endregion
        }



        public void SaveConfig(string path)
        {
            var xmlElem = XElement.Load(path);

            #region SearchBall


            var configs = (from data in xmlElem.Descendants("SearchBall")
                           select data);
            var config = configs.Single();
            config.SetAttributeValue("BallStopAndSearchRangeMin", BallStopAndSearchRange.Min);
            config.SetAttributeValue("BallStopAndSearchRangeMax", BallStopAndSearchRange.Max);
            config.SetAttributeValue("BallWalkAndSearchRangeMin", BallWalkAndSearchRange.Min);
            config.SetAttributeValue("BallWalkAndSearchRangeMax", BallWalkAndSearchRange.Max);
            config.SetAttributeValue("BallTurnAndSearchRangeMin", BallTurnAndSearchRange.Min);
            config.SetAttributeValue("BallTurnAndSearchRangeMax", BallTurnAndSearchRange.Max);
            config.SetAttributeValue("BallSecWalkAndSearchRangeMin", BallSecWalkAndSearchRange.Min);
            config.SetAttributeValue("BallSecWalkAndSearchRangeMax", BallSecWalkAndSearchRange.Max);
            config.SetAttributeValue("LittleWalkRate", LittleWalkRate);
            config.SetAttributeValue("BallLostTimeToSearch", BallLostTimeToSearch);

            #endregion

            #region WalkToBall
            var configsWalkToBall = (from data in xmlElem.Descendants("WalkToBall")
                                     select data);
            var configWalkToBall = configsWalkToBall.Single();

            configWalkToBall.SetAttributeValue("CommunicationDistance", CommunicationDistance);
            configWalkToBall.SetAttributeValue("BallStopTiltBounderMin", BallStopTiltBounder.Min);
            configWalkToBall.SetAttributeValue("BallStopTiltBounderMax", BallStopTiltBounder.Max);

            configWalkToBall.SetAttributeValue("StandAndTurnBounderMin", StandAndTurnBounder.Min);
            configWalkToBall.SetAttributeValue("StandAndTurnBounderMax", StandAndTurnBounder.Max);

            configWalkToBall.SetAttributeValue("TurnHeadDirectionMin", TurnHeadDirection.Min);
            configWalkToBall.SetAttributeValue("TurnHeadDirectionMax", TurnHeadDirection.Max);

            configWalkToBall.SetAttributeValue("PerseptionPresionWalkToBall", PerseptionPresionWalkToBall);
            #endregion

            #region SearchGoal

            var configsSearchGoal = (from data in xmlElem.Descendants("SearchGoal")
                                     select data);
            var configSearchGoal = configsSearchGoal.Single();

            configSearchGoal.SetAttributeValue("GoalStopAndSearchRangeMin", GoalStopAndSearchRange.Min);
            configSearchGoal.SetAttributeValue("GoalStopAndSearchRangeMax", GoalStopAndSearchRange.Max);

            configSearchGoal.SetAttributeValue("GoalWalkAndSearchRangeMin", GoalWalkAndSearchRange.Min);
            configSearchGoal.SetAttributeValue("GoalWalkAndSearchRangeMax", GoalWalkAndSearchRange.Max);

            configSearchGoal.SetAttributeValue("PerseptionPresion", PerseptionPresionGoalSearch);
            configSearchGoal.SetAttributeValue("IntervalGoalSearch", IntervalGoalSearch);

            configSearchGoal.SetAttributeValue("SearchGoalFourStepLeftTurnX", SearchGoalFourStepLeftTurn[0]);
            configSearchGoal.SetAttributeValue("SearchGoalFourStepLeftTurnY", SearchGoalFourStepLeftTurn[1]);

            configSearchGoal.SetAttributeValue("SearchGoalFourStepLeftTurnZ", SearchGoalFourStepLeftTurn[2]);
            configSearchGoal.SetAttributeValue("SearchGoalFourStepLeftTurnA", SearchGoalFourStepLeftTurn[3]);

            configSearchGoal.SetAttributeValue("SearchGoalFourStepLeftTurnT", SearchGoalFourStepLeftTurn[4]);

            #endregion

            #region TurnBall
            var configsTurnBall = (from data in xmlElem.Descendants("TurnBall")
                                   select data);
            var configTurnBall = configsTurnBall.Single();

            configTurnBall.SetAttributeValue("SightBoundaryRangeMin", SightBoundaryRange.Min);
            configTurnBall.SetAttributeValue("SightBoundaryRangeMax", SightBoundaryRange.Max);

            configTurnBall.SetAttributeValue("TurnPresion", TurnPresion);
            configTurnBall.SetAttributeValue("TurnPerseptionPresion", PerseptionPresionTurn);

            configTurnBall.SetAttributeValue("FourStepLeftTurnX", FourStepLeftTurn[0]);
            configTurnBall.SetAttributeValue("FourStepLeftTurnY", FourStepLeftTurn[1]);

            configTurnBall.SetAttributeValue("FourStepLeftTurnZ", FourStepLeftTurn[2]);
            configTurnBall.SetAttributeValue("FourStepLeftTurnA", FourStepLeftTurn[3]);

            configTurnBall.SetAttributeValue("FourStepLeftTurnT", FourStepLeftTurn[4]);

            configTurnBall.SetAttributeValue("FourStepRightTurnX", FourStepRightTurn[0]);

            configTurnBall.SetAttributeValue("FourStepRightTurnY", FourStepRightTurn[1]);
            configTurnBall.SetAttributeValue("FourStepRightTurnZ", FourStepRightTurn[2]);

            configTurnBall.SetAttributeValue("FourStepRightTurnA", FourStepRightTurn[3]);
            configTurnBall.SetAttributeValue("FourStepRightTurnT", FourStepRightTurn[4]);

            configTurnBall.SetAttributeValue("FourStepBackWardX", FourStepBackWard[0]);
            configTurnBall.SetAttributeValue("FourStepBackWardY", FourStepBackWard[1]);

            configTurnBall.SetAttributeValue("FourStepBackWardZ", FourStepBackWard[2]);
            configTurnBall.SetAttributeValue("FourStepBackWardA", FourStepBackWard[3]);
            configTurnBall.SetAttributeValue("FourStepBackWardT", FourStepBackWard[4]);
            configTurnBall.SetAttributeValue("PerseptionPresionAim", AimPerseptionPresion);

            #endregion

            #region AimAndKick

            var configsAimAndKick = (from data in xmlElem.Descendants("AimAndKick")
                                     select data);
            var configAimAndKick = configsAimAndKick.Single();

            configAimAndKick.SetAttributeValue("LittleFourStepForwardX", LittleFourStepForward[0]);
            configAimAndKick.SetAttributeValue("LittleFourStepForwardY", LittleFourStepForward[1]);
            configAimAndKick.SetAttributeValue("LittleFourStepForwardZ", LittleFourStepForward[2]);
            configAimAndKick.SetAttributeValue("LittleFourStepForwardA", LittleFourStepForward[3]);
            configAimAndKick.SetAttributeValue("LittleFourStepForwardT", LittleFourStepForward[4]);

            configAimAndKick.SetAttributeValue("LittleFourStepLeftSideX", LittleFourStepLeftSide[0]);
            configAimAndKick.SetAttributeValue("LittleFourStepLeftSideY", LittleFourStepLeftSide[1]);
            configAimAndKick.SetAttributeValue("LittleFourStepLeftSideZ", LittleFourStepLeftSide[2]);
            configAimAndKick.SetAttributeValue("LittleFourStepLeftSideA", LittleFourStepLeftSide[3]);
            configAimAndKick.SetAttributeValue("LittleFourStepLeftSideT", LittleFourStepLeftSide[4]);

            configAimAndKick.SetAttributeValue("LittleFourStepRightSideX", LittleFourStepRightSide[0]);
            configAimAndKick.SetAttributeValue("LittleFourStepRightSideY", LittleFourStepRightSide[1]);
            configAimAndKick.SetAttributeValue("LittleFourStepRightSideZ", LittleFourStepRightSide[2]);
            configAimAndKick.SetAttributeValue("LittleFourStepRightSideA", LittleFourStepRightSide[3]);
            configAimAndKick.SetAttributeValue("LittleFourStepRightSideT", LittleFourStepRightSide[4]);

            configAimAndKick.SetAttributeValue("LittleFourStepBackWardX", LittleFourStepBackWard[0]);
            configAimAndKick.SetAttributeValue("LittleFourStepBackWardY", LittleFourStepBackWard[1]);
            configAimAndKick.SetAttributeValue("LittleFourStepBackWardZ", LittleFourStepBackWard[2]);
            configAimAndKick.SetAttributeValue("LittleFourStepBackWardA", LittleFourStepBackWard[3]);
            configAimAndKick.SetAttributeValue("LittleFourStepBackWardT", LittleFourStepBackWard[4]);

            configAimAndKick.SetAttributeValue("RightOrLeftBoundar", RightOrLeftBoundar);
            configAimAndKick.SetAttributeValue("SleepBeforeMotionPlay", SleepBeforeMotionPlay);
            configAimAndKick.SetAttributeValue("RightKickIndex", RightKickMotionIndex);
            configAimAndKick.SetAttributeValue("LeftKickIndex", LeftKickMotionIndex);
            configAimAndKick.SetAttributeValue("BallYposMin", BallYposLeg.Min);

            configAimAndKick.SetAttributeValue("BallYposMax", BallYposLeg.Max);
            configAimAndKick.SetAttributeValue("BallXposLeftLegMin", BallXposLeftLeg.Min);
            configAimAndKick.SetAttributeValue("BallXposLeftLegMax", BallXposLeftLeg.Max);
            configAimAndKick.SetAttributeValue("BallXposRightLegMin", BallXposRightLeg.Min);
            configAimAndKick.SetAttributeValue("BallXposRightLegMax", BallXposRightLeg.Max);




            #endregion

            #region WalkToBallAwardsGoal

            var configsWalkToBallAwardsGoal = (from data in xmlElem.Descendants("WalkToBallAwardsGoal")
                                               select data);
            var configWalkToBallAwardsGoal = configsWalkToBallAwardsGoal.Single();

            configWalkToBallAwardsGoal.SetAttributeValue("BallLocationXReangeMin", SightBoundaryRange.Min);
            configWalkToBallAwardsGoal.SetAttributeValue("BallLocationXReangeMax", SightBoundaryRange.Max);

            configWalkToBallAwardsGoal.SetAttributeValue("RightWalkSettingsX", RightWalkSettings[0]);
            configWalkToBallAwardsGoal.SetAttributeValue("RightWalkSettingsY", RightWalkSettings[1]);


            configWalkToBallAwardsGoal.SetAttributeValue("RightWalkSettingsA", RightWalkSettings[2]);
            configWalkToBallAwardsGoal.SetAttributeValue("RightWalkSettingsP", RightWalkSettings[3]);

            configWalkToBallAwardsGoal.SetAttributeValue("LeftWalkSettingsX", LeftWalkSettings[0]);

            configWalkToBallAwardsGoal.SetAttributeValue("LeftWalkSettingsY", LeftWalkSettings[1]);

            configWalkToBallAwardsGoal.SetAttributeValue("LeftWalkSettingsA", LeftWalkSettings[2]);

            configWalkToBallAwardsGoal.SetAttributeValue("LeftWalkSettingsP", LeftWalkSettings[3]);

            configWalkToBallAwardsGoal.SetAttributeValue("WalkTime", WalkTime);


            #endregion

            #region Test


            var configsTest = (from data in xmlElem.Descendants("Test")
                               select data);
            var configTest = configsTest.Single();
            configTest.SetAttributeValue("TiltPos", TiltPos);
            configTest.SetAttributeValue("PanLeftPos", PanLeftPos);
            configTest.SetAttributeValue("PanRightPos", PanRightPos);
            configTest.SetAttributeValue("Interval", Interval);
            configTest.SetAttributeValue("TurnGain", TurnGain);
            #endregion

            #region Settings

            var configsSettings = (from data in xmlElem.Descendants("Settings")
                                   select data);
            var configSettings = configsSettings.Single();
            configSettings.SetAttributeValue("GameControllerEnabled", GameControllerEnabled);
            configSettings.SetAttributeValue("AttackModeIsKick", AttackModeIsKick);
            configSettings.SetAttributeValue("RivalGoalIsBlue", RivalGoalIsBlue);
            configSettings.SetAttributeValue("IsGoalie", isGoalie);
            configSettings.SetAttributeValue("CommunicationEnabled", CommunicationEnabled);
            #endregion

            xmlElem.Save(path);
        }
        #endregion
    }
}
