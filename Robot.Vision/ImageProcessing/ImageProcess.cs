using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Emgu.CV.Util;
using Robot.Environment;
using Robot.Environment.Color;
using Robot.Locomotion;
using Robot.Vision.Detectors;
using Robot.Utils;

namespace Robot.Vision.ImageProcessing
{
    public class ImageProcess
    {

        private float _sizeX;
        private float _sizeY;

        private Hsv _ballCircleColor;

        private  VectorOfVectorOfPoint _contour;

        public ColorPicker GrabedColor = new ColorPicker();
        public ColorSpace GrabedColorSpace = new ColorSpace();

        public delegate void GrayImageProcessedHandler(Image<Gray, byte> frame);
        public event GrayImageProcessedHandler GrayImageProcessed;

        public delegate void ImageProcessorFunctionDelegate(Image<Hsv, byte> frame);
        public ImageProcessorFunctionDelegate ProcessImage;
        public ImageProcessorFunctionDelegate ProcessObject;
        public event ImageProcessorFunctionDelegate OutputFrameProcessed;
        public event ImageProcessorFunctionDelegate AnalyzeFrameProcessed;

        public int SplitIndex;
        public int[] BallCircleColor = new int[3];
        public int[] GoalCircleColor = new int[3];
        public int[] CenterRectangleColor = new int[3];
        public int BallErodeValue, GoalErodeValue, FieldErodeValue, BallDilateValue, GoalDilateValue, FieldDilateValue;

        public VectorOfMat ballHist = new VectorOfMat();
        
        public Image<Gray, byte> ObjectMask { get; set; }

        public Image<Gray, byte> GoalMask { get; set; }
        public Image<Gray, byte> FieldMask { get; set; }


        private int _minBallPixels;
        public int MinBallPixels
        {
            get { return _minBallPixels; }
            set { _minBallPixels = value; }
        }

        private int _minGoalPixels;
        public int MinGoalPixels
        {
            get { return _minGoalPixels; }
            set { _minGoalPixels = value; }
        }

        private int _minFieldPixels;
        public int MinFieldPixels
        {
            get { return _minFieldPixels; }
            set { _minFieldPixels = value; }
        }

        private float _fps;
        public int Fps
        {
            get { return Convert.ToInt32(_fps); }

        }
        public enum ImageProcessingFunctions
        {
            GrabedReal,
            GrabedBlackRed,
            Field,
            Masked,
            Hue,
            Saturation,
            Value
        }
        public enum ProcessedObjectFunction
        {
            Real,
            ContourBall,
            ContourGoal
        }
        public enum Mode
        {
            Laboratory,
            Play
        }

        public Mode ProcessingMode
        {
            set;
            get;
        }

        private readonly Vision _vision;
        private readonly Head _head;

        readonly List<Image<Gray, byte>> _sampleList = new List<Image<Gray, byte>>();
        public ImageProcess(Vision vision, Head head)
        {

            _vision = vision;
            _head = head;

            LoadConfig(Config.Config.FilePath, "Config/Behavior.xml");
            _ballCircleColor = new Hsv(BallCircleColor[0], BallCircleColor[1], BallCircleColor[2]);

            SelectProsessedObjectFunction(ProcessedObjectFunction.ContourBall);
            ProcessingMode = Mode.Play;
            SelectProsessedObjectFunction(ProcessedObjectFunction.Real);
            SelectImageProcessingFunction(ImageProcessingFunctions.Masked);
            _contour = new VectorOfVectorOfPoint();
        }



        public void SelectProsessedObjectFunction(ProcessedObjectFunction function)
        {
            if (function == ProcessedObjectFunction.ContourBall)
            {
                _vision.Ball.IsDetected = false;
                _vision.Ball.LostTime = 0;
                _vision.Goal.IsDetected = false;
                _vision.Goal.LostTime = 0;
                ProcessObject = ContourBallScan;

            }

            else if (function == ProcessedObjectFunction.ContourGoal)
            {
                _vision.Ball.IsDetected = false;
                _vision.Ball.LostTime = 0;
                _vision.Goal.IsDetected = false;
                _vision.Goal.LostTime = 0;
                ProcessObject = ContourGoalScan;

            }
            else if (function == ProcessedObjectFunction.Real)
            {
                _vision.Ball.IsDetected = false;
                _vision.Ball.LostTime = 0;
                _vision.Goal.IsDetected = false;
                _vision.Goal.LostTime = 0;
                ProcessObject = Real;

            }

        }

        public void SelectImageProcessingFunction(ImageProcessingFunctions function)
        {

            if (function == ImageProcessingFunctions.Masked)
            {
                ProcessImage = GrabedMasked;

            }
            else if (function == ImageProcessingFunctions.Hue)
            {
                SplitIndex = 0;
                ProcessImage = SplitMode;

            }
            else if (function == ImageProcessingFunctions.Saturation)
            {
                SplitIndex = 1;
                ProcessImage = SplitMode;

            }
            else if (function == ImageProcessingFunctions.Value)
            {
                SplitIndex = 2;
                ProcessImage = SplitMode;
            }

        }

        public bool onfildOff;


        public Range<int> goalRange = new Range<int>(0, 0);
        public bool IsInColorRange(int h, int s, int v)
        {
            return (h >= _vision.Field.Color.ColorList.Min.Hue && h <= _vision.Field.Color.ColorList.Max.Hue) && (s >= _vision.Field.Color.ColorList.Min.Satuation && s <= _vision.Field.Color.ColorList.Max.Satuation) && (v >= _vision.Field.Color.ColorList.Min.Value && v <= _vision.Field.Color.ColorList.Max.Value);
        }

        public int minThersh = 40;
        public int maxThersh = 100;
        public int kos = 0;





        public CircleF? BallDetection(Image<Hsv, byte> img, Image<Gray, byte> ballMask, Image<Gray, byte> ballMask2, Image<Gray, byte> fieldMask, VectorOfPoint field)
        {



            ballMask._Erode(2*BallErodeValue);
            ballMask._Dilate(2*BallDilateValue);
            ballMask._Erode(2*GoalErodeValue);
            ballMask._Dilate(2*GoalDilateValue);

            ballMask2._Erode(BallErodeValue);
            ballMask2._Dilate(BallDilateValue);
            ballMask2._Erode(GoalErodeValue);
            ballMask2._Dilate(GoalDilateValue);


          var   ballMask3 = ballMask.And(ballMask2);


                CvInvoke.FindContours(ballMask3, _contour, new Mat(), RetrType.External, ChainApproxMethod.ChainApproxNone);
          


            var ballList = new List<VectorOfPoint>();

         

            for (int i = 0; i < _contour.Size; i++)
            {
                ballList.Add(_contour[i]);
            }


            ballList = ballList.OrderByDescending(p => CvInvoke.ContourArea(p)).ToList();

            foreach (var ball in ballList)
            {
       

                   var rect= CvInvoke.MinAreaRect(ball);
                    rect.Angle = 0;
                    _sizeX = 2 * rect.Size.Width;
                    _sizeY = 2 * rect.Size.Height;

                    var x = Convert.ToInt32(rect.Center.X - rect.Size.Width / 2);
                    var y = Convert.ToInt32(rect.Center.Y - rect.Size.Height / 2);

                    if (x < 0)
                    {
                        x = 3;
                    }
                    if (y < 0)
                    {
                        y = 3;
                    }
                    var p = new Point(x, y);

                    var w = Convert.ToInt32(rect.Size.Width);
                    var h = Convert.ToInt32(rect.Size.Height);
                    var s = new Size(w, h);

                    ballMask.ROI = new Rectangle(p, s);
                    ballMask2.ROI = new Rectangle(p, s);


                    var _outerRect = new RotatedRect(rect.Center, new SizeF(_sizeX, _sizeY), rect.Angle);

                    double ballNonZeroPixels = ballMask.CountNonzero()[0];
                    double allBallPixels = rect.Size.Width * rect.Size.Height;

                    double ballNonZeroPixels2 = ballMask2.CountNonzero()[0];
                    double allBallPixels2 = rect.Size.Width * rect.Size.Height;

              var fieldBox=new Rectangle(new Point((int)_outerRect.Center.X - (int)_outerRect.Size.Width / 2, (int)_outerRect.Center.Y - (int)_outerRect.Size.Height/2), new Size((int)_outerRect.Size.Width, (int)_outerRect.Size.Height));

                fieldMask.ROI = fieldBox;

                    var nonZeroPixel = fieldMask.CountNonzero()[0];


                    const float onFieldPercent = 20;
                    const float isBallPercent = 50;
                    const float isBallPercent2 = 50;


               //     var onfield = (nonZeroPixel / (float)ballNonZeroPixels) * 100;
                    var isBall = (ballNonZeroPixels / (float)allBallPixels) * 100;
                    var isBall2 = (ballNonZeroPixels2 / (float)allBallPixels2) * 100;

                    double widthHeightRatio = rect.Size.Width / rect.Size.Height;

                    if (isBall >= isBallPercent && isBall2 >= isBallPercent2 && (widthHeightRatio < 1.3 && widthHeightRatio > 0.7))
                    {



                       // var point = new Point(Convert.ToInt32(rect.Center.X),
                       //     Convert.ToInt32(rect.Center.Y - (rect.Size.Height / 2)));

                      //  var ch = CvInvoke.PointPolygonTest(field, point, true); 

                        var _Onfield = 0;
                        
                        var inside = FieldDetector.InsideField(field,
                            new Point(Convert.ToInt32(_outerRect.Center.X),
                                Convert.ToInt32(_outerRect.Center.Y)));
                        if (inside)
                        {
                            _Onfield++;
                        }

                        var insideTopLeft = FieldDetector.InsideField(field,
                            new Point(Convert.ToInt32(_outerRect.Center.X - _outerRect.Size.Width / 2),
                                Convert.ToInt32(_outerRect.Center.Y - _outerRect.Size.Height / 2)));

                        if (insideTopLeft)
                        {
                            _Onfield++;
                        }
                        var insideTopRight = FieldDetector.InsideField(field,
                           new Point(Convert.ToInt32(_outerRect.Center.X + _outerRect.Size.Width / 2),
                               Convert.ToInt32(_outerRect.Center.Y - _outerRect.Size.Height / 2)));
                        if (insideTopRight)
                        {
                            _Onfield++;
                        }
                        var insideBottomRight = FieldDetector.InsideField(field,
                        new Point(Convert.ToInt32(_outerRect.Center.X + _outerRect.Size.Width / 2),
                            Convert.ToInt32(_outerRect.Center.Y + _outerRect.Size.Height / 2)));
                        if (insideBottomRight)
                        {
                            _Onfield++;
                        }
                        var insideBottomLeft = FieldDetector.InsideField(field,
                     new Point(Convert.ToInt32(_outerRect.Center.X - _outerRect.Size.Width / 2),
                         Convert.ToInt32(_outerRect.Center.Y + _outerRect.Size.Height / 2)));

                        if (insideBottomLeft)
                        {
                            _Onfield++;
                        }



                        if ( _Onfield>2 || _head.Tilt.Angle<-50)
                        {
                            var abs = System.Math.Abs(_head.Tilt.Angle);
                            if (abs < 30)
                            {
                                abs = 30;
                            }



                            if (rect.Size.Width > abs)
                            {
                                var circle = new CircleF
                                {
                                    Center = rect.Center,
                                    Radius = rect.Size.Width / 2
                                };

                               
                              img.Draw(new Rectangle(new Point((int)_outerRect.Center.X - (int)_outerRect.Size.Width / 2, (int)_outerRect.Center.Y - (int)_outerRect.Size.Height/2), new Size((int)_outerRect.Size.Width, (int)_outerRect.Size.Height)),new Hsv(50,255,255),2);

                                return circle;
                            }
                      
                        }


                    

                }

              
            }

            return null;


        }

        public int SwitchBoundary = -20;

        public void ContourBallScan(Image<Hsv, byte> frame)
        {


            ObjectMask =
             frame.InRange(
                 new Hsv(_vision.Ball.Color.ColorList.Min.Hue, _vision.Ball.Color.ColorList.Min.Satuation,
                         _vision.Ball.Color.ColorList.Min.Value),
                 new Hsv(_vision.Ball.Color.ColorList.Max.Hue, _vision.Ball.Color.ColorList.Max.Satuation,
                         _vision.Ball.Color.ColorList.Max.Value));


            GoalMask =
            frame.InRange(
                new Hsv(_vision.Ball.Color2.ColorList.Min.Hue, _vision.Ball.Color2.ColorList.Min.Satuation,
                        _vision.Ball.Color2.ColorList.Min.Value),
                new Hsv(_vision.Ball.Color2.ColorList.Max.Hue, _vision.Ball.Color2.ColorList.Max.Satuation,
                        _vision.Ball.Color2.ColorList.Max.Value));





            FieldMask =
            frame.InRange(
                new Hsv(_vision.Field.Color.ColorList.Min.Hue, _vision.Field.Color.ColorList.Min.Satuation,
                        _vision.Field.Color.ColorList.Min.Value),
                new Hsv(_vision.Field.Color.ColorList.Max.Hue, _vision.Field.Color.ColorList.Max.Satuation,
                        _vision.Field.Color.ColorList.Max.Value));
            FieldMask._Erode(FieldErodeValue);
            FieldMask._Dilate(FieldDilateValue);



            var fieldPoints = FieldDetector.GetPoints(FieldMask);




       

            CircleF? detectedBall;
       // _head.Tilt.Angle < SwitchBoundary
            if (false)
            {
                detectedBall = CircleDetection(ObjectMask, GoalMask, FieldMask, fieldPoints);
            }
            else
            {
                detectedBall = BallDetection(frame,ObjectMask, GoalMask, FieldMask, fieldPoints);
            }

            if (detectedBall == null)
            {
                _vision.Ball.IsDetected = false;
                _vision.Ball.LostTime++;
                _vision.Ball.FoundTime = 0;
            }
            else
            {
                _vision.Ball.Size = Convert.ToInt32(System.Math.PI * detectedBall.Value.Radius * detectedBall.Value.Radius);
                _vision.Ball.Location.X = Convert.ToInt32(detectedBall.Value.Center.X);
                _vision.Ball.Location.Y = Convert.ToInt32(detectedBall.Value.Center.Y);
                _vision.Ball.LostTime = 0;
                _vision.Ball.IsDetected = true;
                _vision.Ball.FoundTime++;
                if (ProcessingMode == Mode.Laboratory)
                {
                    var ballDrawHsv = new Hsv(20, 255, 255);
                    frame.Draw(detectedBall.Value, ballDrawHsv, 2);
                    frame.Draw(new CircleF(detectedBall.Value.Center, 2), ballDrawHsv, 3);
                }
            }

            if (ProcessingMode == Mode.Laboratory)
            {



                frame.DrawPolyline(fieldPoints.ToArray(), true, new Hsv(10, 255, 255), 1);

                OutputFrameProcessed(frame);

            }
        }


        public int HoghMax = 100;
        public int HoghMin = 40;
        public int Thersh = 2;
        public int MinRadius = 60;
        public int MaxRadius = 400;

        private CircleF? CircleDetection(Image<Gray, byte> ballMask, Image<Gray, byte> ballMask2, Image<Gray, byte> fieldMask, VectorOfPoint field)
        {

            ballMask._Erode(BallErodeValue);
            ballMask._Dilate(BallDilateValue);
            ballMask._Erode(GoalErodeValue);
            ballMask._Dilate(GoalDilateValue);

            ballMask2._Erode(BallErodeValue);
            ballMask2._Dilate(BallDilateValue);
            ballMask2._Erode(GoalErodeValue);
            ballMask2._Dilate(GoalDilateValue);


            ballMask._SmoothGaussian(9);

            var houghResult = ballMask2.HoughCircles(new Gray(HoghMax), new Gray(HoghMin), Thersh, ballMask.Height / 4, MinRadius, MaxRadius)[0];

            var circles = houghResult.OrderByDescending(d => d.Radius).ToList();

            foreach (var circleF in circles)
            {
                
                var diameter = Convert.ToInt32(2 * circleF.Radius);

                var rectangleStartPoint = new Point(Convert.ToInt32(circleF.Center.X - circleF.Radius),
                    Convert.ToInt32(circleF.Center.Y - circleF.Radius));
                var rect =
                    new Rectangle(rectangleStartPoint
                    , new Size(diameter, diameter));

                var y = rect.Y - rect.Height / 2;
                if (y < 0)
                {
                    y = 3;
                }
                var p = new Point(rect.X, y);


                var inField = FieldDetector.InsideField(field, p);


                var _Onfield = 0;

                var inside = FieldDetector.InsideField(field,
                    new Point(Convert.ToInt32(rect.X+rect.Width/2),
                        Convert.ToInt32(rect.Y+rect.Height/2)));
                if (inside)
                {
                    _Onfield++;
                }

                var insideTopLeft = FieldDetector.InsideField(field,
                    new Point(Convert.ToInt32(rect.X),
                        Convert.ToInt32(rect.Y)));

                if (insideTopLeft)
                {
                    _Onfield++;
                }
                var insideTopRight = FieldDetector.InsideField(field,
                   new Point(Convert.ToInt32(rect.X +rect.Size.Width),
                       Convert.ToInt32(rect.Y )));
                if (insideTopRight)
                {
                    _Onfield++;
                }
                var insideBottomRight = FieldDetector.InsideField(field,
                new Point(Convert.ToInt32(rect.X + rect.Width),
                    Convert.ToInt32(rect.Y + rect.Height)));
                if (insideBottomRight)
                {
                    _Onfield++;
                }
                var insideBottomLeft = FieldDetector.InsideField(field,
             new Point(Convert.ToInt32(rect.X ),
                 Convert.ToInt32(rect.Y + rect.Height)));

                if (insideBottomLeft)
                {
                    _Onfield++;
                }




                ballMask.ROI = rect;
                ballMask2.ROI = rect;

                double whitePixels = ballMask.CountNonzero()[0];
                double allPixels = diameter * diameter;

                double total = whitePixels / allPixels;
                double percent = total * 100;
                const int ballPercent = 50;


                double whitePixels2 = ballMask2.CountNonzero()[0];
                double allPixels2 = diameter * diameter;

                double total2 = whitePixels2 / allPixels2;
                double percent2 = total2 * 100;
                const int ballPercent2 = 50;


                if (percent > ballPercent && percent2 > ballPercent2)
                {
             
                    if (true)
                    {
                        return circleF;
                    }
                }
            }
            return null;

        }






        public bool GoalCompleteDetected { get; set; }

  


        public void ContourGoalScan(Image<Hsv, byte> frame)
        {
            
        }


        public void Real(Image<Hsv, byte> frame)
        {

            if (ProcessingMode == Mode.Laboratory)
            {
                OutputFrameProcessed(frame);
            }
        }

        public void GrabedMasked(Image<Hsv, byte> frame)
        {
            ObjectMask =
               frame.InRange(
                   new Hsv(GrabedColor.Min.Hue, GrabedColor.Min.Satuation,
                           GrabedColor.Min.Value),
                   new Hsv(GrabedColor.Max.Hue, GrabedColor.Max.Satuation,
                           GrabedColor.Max.Value));
            ObjectMask._Erode(BallErodeValue);
            ObjectMask._Dilate(BallDilateValue);
            ObjectMask._Erode(GoalErodeValue);
            ObjectMask._Dilate(GoalDilateValue);

            if (ProcessingMode == Mode.Laboratory)
            {
                GrayImageProcessed(ObjectMask);
            }
        }


        public void SplitMode(Image<Hsv, byte> frame)
        {
            var channels = frame.Split();



            if (ProcessingMode == Mode.Laboratory)
            {
                switch (SplitIndex)
                {
                    case 0:
                        GrayImageProcessed(
                            channels[SplitIndex].InRange(new Gray(GrabedColor.Min.Hue), new Gray(GrabedColor.Max.Hue)));
                        break;
                    case 1:
                        GrayImageProcessed(channels[SplitIndex].InRange(new Gray(GrabedColor.Min.Satuation), new Gray(GrabedColor.Max.Satuation)));
                        break;
                    case 2:
                        GrayImageProcessed(channels[SplitIndex].InRange(new Gray(GrabedColor.Min.Value), new Gray(GrabedColor.Max.Value)));
                        break;
                }
            }
        }

        public bool GoalIsBlue = false;
        public void LoadConfig(string path, string path2)
        {
            var xmlDoc = XDocument.Load(path);
            var querys = from query in xmlDoc.Descendants("ImageProcessing")
                         select new
                         {

                             BallErodeValue = Convert.ToInt32(query.Attribute("BallErodeValue").Value),
                             FieldErodeValue = Convert.ToInt32(query.Attribute("FieldErodeValue").Value),
                             GoalErodeValue = Convert.ToInt32(query.Attribute("GoalErodeValue").Value),
                             BallDilateValue = Convert.ToInt32(query.Attribute("BallDilateValue").Value),
                             GoalDilateValue = Convert.ToInt32(query.Attribute("GoalDilateValue").Value),
                             FieldDilateValue = Convert.ToInt32(query.Attribute("FieldDilateValue").Value),
                             minBallPixels = Convert.ToInt32(query.Attribute("MinBallPixels").Value),
                             minFieldPixels = Convert.ToInt32(query.Attribute("MinFieldPixels").Value),
                             minGoalPixels = Convert.ToInt32(query.Attribute("MinGoalPixels").Value),
                             ballCircleColors_H = Convert.ToInt32(query.Element("BallCircleColor").Attribute("H").Value),
                             ballCircleColors_S = Convert.ToInt32(query.Element("BallCircleColor").Attribute("S").Value),
                             ballCircleColors_V = Convert.ToInt32(query.Element("BallCircleColor").Attribute("V").Value),
                             goalCircleColor_H = Convert.ToInt32(query.Element("GoalCircleColor").Attribute("H").Value),
                             goalCircleColor_S = Convert.ToInt32(query.Element("GoalCircleColor").Attribute("S").Value),
                             goalCircleColor_V = Convert.ToInt32(query.Element("GoalCircleColor").Attribute("V").Value),
                             centerRectangleColor_H = Convert.ToInt32(query.Element("CenterRectangleColor").Attribute("H").Value),
                             centerRectangleColor_S = Convert.ToInt32(query.Element("CenterRectangleColor").Attribute("S").Value),
                             centerRectangleColor_V = Convert.ToInt32(query.Element("CenterRectangleColor").Attribute("V").Value)
                         };

            var data = querys.Single();
            _minBallPixels = data.minBallPixels;
            _minFieldPixels = data.minFieldPixels;
            _minGoalPixels = data.minGoalPixels;

            BallErodeValue = data.BallErodeValue;
            GoalErodeValue = data.GoalErodeValue;
            FieldErodeValue = data.FieldErodeValue;
            BallDilateValue = data.BallDilateValue;
            GoalDilateValue = data.GoalDilateValue;
            FieldDilateValue = data.FieldDilateValue;


            BallCircleColor[0] = data.ballCircleColors_H;
            BallCircleColor[1] = data.ballCircleColors_S;
            BallCircleColor[2] = data.ballCircleColors_V;
            GoalCircleColor[0] = data.goalCircleColor_H;
            GoalCircleColor[1] = data.goalCircleColor_S;
            GoalCircleColor[2] = data.goalCircleColor_V;
            CenterRectangleColor[0] = data.centerRectangleColor_H;
            CenterRectangleColor[1] = data.centerRectangleColor_S;
            CenterRectangleColor[2] = data.centerRectangleColor_V;


            var xmlDocS = XDocument.Load(path2);
            var querysS = from query in xmlDocS.Descendants("Settings")
                          select new
                          {
                              RivalGoalIsBlue = Convert.ToBoolean(query.Attribute("RivalGoalIsBlue").Value),

                          };
            var dataS = querysS.Single();
            GoalIsBlue = dataS.RivalGoalIsBlue;
            if (dataS.RivalGoalIsBlue)
            {

                goalRange.Min = -1000;
                goalRange.Max = 45;
            }
            else
            {
                goalRange.Min = 135;
                goalRange.Max = 1000;
            }
        }







    }
}
