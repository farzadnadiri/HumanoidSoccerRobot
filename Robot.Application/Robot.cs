using System.Drawing;
using Robot.Behavior;
using Robot.Environment;
using Robot.IO;
using Robot.Locomotion;
using Robot.Locomotion.TrajectoryWalk;
using Robot.Network;
using Robot.Utils;
using Robot.Config;
using Robot.Vision;
using Robot.Vision.HeadControl;
using Robot.Vision.ImageProcessing;

namespace Robot.Application
{
    public class Robot
    {
        // public  Logger Log;

        public WalkManager WalkManager;

        public Head Head;

        public Body Body;

        public Vision.Vision Vision;

        public ImageProcess ImageProcess;

        public Capture Capture;


        public Model Model;

        public Communication Communication;
        public RobotProperties RobotProperties;


        public VisionLab VisionLab;


        public Search Search;

        public Tracker Tracker;


        public ConfigurationManager ConfigurationManager;


        public DynamixelBus MotorBus;


        public MotionLab MotionEditor;

        public MotionManager MotionManager;

        public FourStepWalkEngine FourStepWalkEngine;

        public TrajectoryWalkEngine TrajectoryWalking;

        public readonly DCM DCM;

        public static GameController GameController
        {
            get;
            set;
        }

        public static BehaviorControl BehaviorControl
        {
            set;
            get;
        }


        public static Range<int> PanRange;
        public static Range<int> TiltRange;

        public Controll ControllUnit;

        public Robot()
        {
            PanRange = new Range<int>(100, 1000);
            TiltRange = new Range<int>(250, 500);

            MotorBus = new DynamixelBus("COM4", 1);
            MotorBus.Open();

            Body = new Body(MotorBus, "Config/Body.xml");

            Body.HomogenizeSpeeds();
 
            var _standStyle = new Step(Body.Joints.Count, 1);
            _standStyle.Load("Config/StandStyle.xml");

            Body.SetStandStyle(_standStyle.Angels);

            Head = new Head(MotorBus, 41, Model.Rx24F, 40, Model.Rx24F, PanRange, TiltRange);
            ControllUnit = new Controll("Config/Controll.xml");
            //ControllUnit = new Controll("COM7", 1, 25);


            MotionManager = new MotionManager(Body);
            FourStepWalkEngine = new FourStepWalkEngine(Body, ControllUnit);
            TrajectoryWalking = new TrajectoryWalkEngine(Body, ControllUnit, "Config/TrajectoryWalk.xml");

            TrajectoryWalking.WalkOffset.Load("Config/WalkOffset.xml");


            RobotProperties = new RobotProperties();

            Vision = new Vision.Vision();

            ImageProcess = new ImageProcess(Vision, Head);
            Capture = new Capture(ImageProcess);
            Communication = new Communication();
            Tracker = new Tracker(Head, Capture, Vision, RobotProperties, Communication);
            Search = new Search(Head);
            VisionLab = new VisionLab(ImageProcess, Capture, Vision, Head, Search, Tracker);
            ConfigurationManager = new ConfigurationManager();
            GameController = new GameController();
            Head.Pan.AutoFlush = Head.Tilt.AutoFlush = true; //todo ok this
            Head.Pan.Slop = Head.Tilt.Slop = 128;
            Head.Pan.AutoFlush = Head.Tilt.AutoFlush = false;
            DCM = new DCM(MotorBus, 5);
            DCM.AddRange(Body.Joints);
            DCM.Add(Head.Pan);
            DCM.Add(Head.Tilt);

            DCM.Enable = true;
            MotionManager.Load("Config/motions.xml");

            ControllUnit.Start();

            WalkManager = new WalkManager("Config/WalkManager.xml", TrajectoryWalking, ControllUnit, MotionManager, Head, Body, Search, Tracker);
            WalkManager.StartFSM();
            MotionEditor = new MotionLab(MotorBus, Body, MotionManager, FourStepWalkEngine, TrajectoryWalking, ControllUnit, WalkManager);
            BehaviorControl = new BehaviorControl(WalkManager, Head, Tracker, Search, Vision, ImageProcess, Capture, GameController, MotionManager, Communication, ControllUnit);

        }
    }
}
