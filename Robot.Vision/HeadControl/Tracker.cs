using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Xml.Linq;
using System.Linq;
using Robot.Environment;
using System.Collections.Generic;
using Robot.Network;
using Robot.Vision.ImageProcessing;

namespace Robot.Vision.HeadControl
{
    public class Tracker
    {
        #region Private Variables

        private const double DynamixelPerDegree = 3.41;
   
        private Thread _ballTrackerThread;
        private bool _enable;
        private int _staticTrackPanMoveUnit;
        private int _staticTrackTiltMoveUnit;
        private int _staticTrackPanSpeed;
        private int _staticTrackTiltSpeed;
        private double _cameraHorizontalAngel;
        private double _cameraVerticalAngle;
        private int _speedCoefficient;
        private float _squareSide;
        private int _minDistanceOfCenterFrame;
        private int _interval;
        private int _camLensAndActuator;
        private int _panMovingDelta;
        private int _tiltMovingDelta;
        private int _trackPanSpeed;
        private int _trackTiltSpeed;
        private Point _objectLocation;
        #endregion

        #region Properties

        private int _distance;
        public int Distance 
        {

            set {_distance = value;}
            get { return _distance; }
        }

        public float SquareSide
        {
            get { return _squareSide; }
            set { _squareSide = value; }
        }
        public int CamLensAndActuator
        {
            get { return _camLensAndActuator; }
            set { _camLensAndActuator = value; }
        }
        public int MinDistanceOfCenterFrame
        {
            get { return _minDistanceOfCenterFrame; }
            set { _minDistanceOfCenterFrame = value; }
        }

        public int SpeedCoefficient
        {
            get { return _speedCoefficient; }
            set { _speedCoefficient = value; }
        }

        public double CameraVerticalAngle
        {
            get { return _cameraVerticalAngle; }
            set { _cameraVerticalAngle = value; }
        }

        public double CameraHorizontalAngel
        {
            get { return _cameraHorizontalAngel; }
            set { _cameraHorizontalAngel = value; }
        }
        public int StaticTrackPanSpeed
        {
            get { return _staticTrackPanSpeed; }
            set { _staticTrackPanSpeed = value; }
        }
        public int StaticTrackTiltSpeed
        {
            get { return _staticTrackTiltSpeed; }
            set { _staticTrackTiltSpeed = value; }
        }
        public int StaticTrackPanMoveUnit
        {
            get { return _staticTrackPanMoveUnit; }
            set { _staticTrackPanMoveUnit = value; }
        }

        public int StaticTrackTiltMoveUnit
        {
            get { return _staticTrackTiltMoveUnit; }
            set { _staticTrackTiltMoveUnit = value; }
        }

        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
        #endregion

        #region Constructors

        private readonly Head _head;
        private readonly Capture _capture;
        private readonly Vision _vision;


        public Tracker(Head head, Capture capture, Vision vision, RobotProperties robotProperties , Communication communication)
        {
 
            _head = head;
            _capture = capture;
            _vision = vision;
            _ballTrackerThread = new Thread(TrackThreadFunction) { Priority = ThreadPriority.Highest };
            LoadConfig("Config/Config.xml");
            SetupHead();
         
            TiltSpeedCon = 18;
            PanSpeedCon = 30;
            _vision.Ball.Distance=Distance = 10000;
        }

        private void SetupHead()
        {
            _head.Pan.Position = _head.Tilt.Position = 512;
            _head.Pan.Speed = _head.Tilt.Speed = 400;
            _head.Pan.Slop = 128;
            _head.Tilt.Slop = 128;
            _head.Pan.Margin = 1;
            _head.Tilt.Margin = 1;
        }
        #endregion

        #region Track Functions

        public double PanSpeedCon ;
        public double TiltSpeedCon ;
        public double PanPosCon = 0.15;
        public double TiltPosCon = 0.15;

        private void FixOnCenterSemiDynamic()
        {
           
            _panMovingDelta =(int) Math.Round(PanPosCon*Math.Round((Math.Abs(_objectLocation.X - _capture.FrameCenter.X) / _cameraHorizontalAngel)));
            _tiltMovingDelta =(int)Math.Round(TiltPosCon*Math.Round(((Math.Abs(_objectLocation.Y - _capture.FrameCenter.Y)/_cameraVerticalAngle))));

            _trackPanSpeed =(int) Math.Round(_panMovingDelta * PanSpeedCon);
            _trackTiltSpeed =(int)Math.Round( _tiltMovingDelta * TiltSpeedCon);
           
            _head.Pan.Speed = _trackPanSpeed<50 ? 50 : _trackPanSpeed;
            _head.Tilt.Speed = _trackTiltSpeed < 50 ? 50 : _trackTiltSpeed;
            MovePanTilt();
       
        }

        private void FixOnCenterStatic()
        {
            _head.Pan.Speed = _staticTrackPanSpeed;
            _head.Tilt.Speed = _staticTrackTiltSpeed;
            _panMovingDelta = _staticTrackPanMoveUnit;
            _tiltMovingDelta = _staticTrackTiltMoveUnit;
            MovePanTilt();
        }

        private void FixOnCenterDynamic()
        {

            _panMovingDelta = (int)((Math.Abs(_objectLocation.X - _capture.FrameCenter.X) / _cameraHorizontalAngel) * DynamixelPerDegree);
            _tiltMovingDelta = (int)((Math.Abs(_objectLocation.Y - _capture.FrameCenter.Y) / _cameraVerticalAngle) * DynamixelPerDegree);
            _head.Pan.Speed = _panMovingDelta * _speedCoefficient;
            _head.Tilt.Speed = _tiltMovingDelta * _speedCoefficient;
            if (_vision.Ball.IsDetected)
                MovePanTilt();
        }

        #endregion

        #region Object Track Functions

        private void TrackBall()
        {

            if (!IsInFrameCenterSquare(_vision.Ball.Location))
            {
               
                if (_vision.Ball.IsDetected)
                    _objectLocation = _vision.Ball.Location;
                if (_vision.Ball.LostTime < 10)
                   FixOnCenterSemiDynamic();
                else
                {
                    _vision.Ball.Distance = Distance = _head.Tilt.Position;
                }

            }
            else
            {
                _vision.Ball.Distance = Distance = _head.Tilt.Position;
         
               
            }

        }






        #endregion

        #region Utility Functions

        private void MovePanTilt()
        {
        //var s=new Stopwatch();
        //    s.Start();
            if (_objectLocation.X > _capture.FrameCenter.X)
            {
                
                _head.Pan.Angle -= _panMovingDelta;
             
            }

            else if (_objectLocation.X < _capture.FrameCenter.X)
            {
                _head.Pan.Angle += _panMovingDelta;
            }

         if (_objectLocation.Y < _capture.FrameCenter.Y)
            {   
                _head.Tilt.Angle += _tiltMovingDelta;
            }
            else if (_objectLocation.Y > _capture.FrameCenter.Y)
            {
                _head.Tilt.Angle -= _tiltMovingDelta;
            }
          //Console.WriteLine(s.ElapsedMilliseconds);
        }


        public bool IsInFrameCenterSquare(Point location)
        {
            return (
                       (location.X > _capture.FrameCenter.X - SquareSide) &&
                       (location.X < _capture.FrameCenter.X + SquareSide) &&
                       (location.Y > _capture.FrameCenter.Y - SquareSide) &&
                       (location.Y < _capture.FrameCenter.Y + SquareSide)
                   );
        }
        #endregion

        #region Enumerators

        #endregion



        #region Thread Managment Functions

        private void TrackThreadFunction()
        {
            while (_enable)
            {
                TrackBall();
               Thread.Sleep(_interval);            }
        }

        public void Start()
        {

            if (_enable) { return; }
        
            _ballTrackerThread = new Thread(TrackThreadFunction);
            _enable = true;
  
            _ballTrackerThread.Start();
        }

        public void Stop()
        {
            if (_enable)
            {
                _enable = false;
            }
        }

        #endregion

        #region Configuration Functions

        public void LoadConfig(string path)
        {
            XDocument xmlDoc = XDocument.Load(path);
            var querys = from query in xmlDoc.Descendants("BallTracker")
                         select new
                         {
                             panUnit = Convert.ToInt32(query.Attribute("StaticPanMoveUnit").Value),
                             tiltUnit = Convert.ToInt32(query.Attribute("StaticTiltMoveUnit").Value),
                             squareside = Convert.ToInt32(query.Attribute("SquareSide").Value),
                             trackInterval = Convert.ToInt32(query.Attribute("TrackBallinterval").Value),
                             horizontalAngel = Convert.ToDouble(query.Attribute("CameraHorizontalAngel").Value),
                             verticalAngle = Convert.ToDouble(query.Attribute("CameraVerticalAngle").Value),
                             coefficient = Convert.ToInt32(query.Attribute("SpeedCoefficient").Value),
                             distance = Convert.ToInt32(query.Attribute("MinDistanceOfCenterFrame").Value),
                             staticPanSpeed = Convert.ToInt32(query.Attribute("StaticPanSpeed").Value),
                             staticTiltSpeed = Convert.ToInt32(query.Attribute("StaticTiltSpeed").Value),
                             camLensAndActuator = Convert.ToInt32(query.Attribute("CamLensAndActuator").Value),
                         };
            var data = querys.Single();
            _staticTrackPanMoveUnit = data.panUnit;
            _staticTrackTiltMoveUnit = data.tiltUnit;
            _squareSide = data.squareside;
            Interval = data.trackInterval;
            _cameraHorizontalAngel = data.horizontalAngel;
            _cameraVerticalAngle = data.verticalAngle;
            _speedCoefficient = data.coefficient;
            _minDistanceOfCenterFrame = data.distance;
            _staticTrackPanSpeed = data.staticPanSpeed;
            _staticTrackTiltSpeed = data.staticTiltSpeed;
            _camLensAndActuator = data.camLensAndActuator;
        }

        public void SaveConfig(string path)
        {
            XElement xmlElem = XElement.Load(path);

            IEnumerable<XElement> configs = (from data in xmlElem.Descendants("BallTracker")
                                             select data);
            var config = configs.Single();
            config.SetAttributeValue("StaticPanMoveUnit", _staticTrackPanMoveUnit);
            config.SetAttributeValue("StaticTiltMoveUnit", _staticTrackTiltMoveUnit);
            config.SetAttributeValue("SquareSide", _squareSide);
            config.SetAttributeValue("TrackBallinterval", _interval);
            config.SetAttributeValue("CameraHorizontalAngel", _cameraHorizontalAngel);
            config.SetAttributeValue("CameraVerticalAngle", _cameraVerticalAngle);
            config.SetAttributeValue("SpeedCoefficient", _speedCoefficient);
            config.SetAttributeValue("MinDistanceOfCenterFrame", _minDistanceOfCenterFrame);
            config.SetAttributeValue("StaticPanSpeed", _staticTrackPanSpeed);
            config.SetAttributeValue("StaticTiltSpeed", _staticTrackTiltSpeed);
            config.SetAttributeValue("CamLensAndActuator", _camLensAndActuator);
            xmlElem.Save(path);
        }
        #endregion

    }
}
