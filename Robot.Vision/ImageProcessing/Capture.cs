using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using System;

namespace Robot.Vision.ImageProcessing
{
    public class Capture
    {

        private Thread _captureThread;
        private readonly object _lock;

        private Image<Hsv, byte> _frame; 
        public Image<Hsv, byte> Frame {
            get
            {
                lock (_lock)
                {
                    return _frame;
                }
                  
            
            }
            set
            {
                lock (_lock)
                {

                    _frame = value;
                }
            }
        }

 


        public delegate void FrameCapturedHandler(Image<Hsv, byte> frame);
        public event FrameCapturedHandler FrameCaptured;

        private Point _frameCenter;
        public Point FrameCenter
        {
            get { return _frameCenter; }
        }

        public Emgu.CV.Capture Cam
        {
            set;
            get;
        }

        private bool _enable;
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        private int _frameHeight;
        public int FrameHeight
        {
            get { return _frameHeight; }
            set { _frameHeight = value; }
        }

        private int _frameWidth;
        public int FrameWidth
        {
            get { return _frameWidth; }
            set { _frameWidth = value; }
        }

        private int _deviceIndex;
        public int DeviceIndex
        {
            get { return _deviceIndex; }
            set { _deviceIndex = value; }
        }

        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        private readonly ImageProcess _imageProcess;
        public Capture(ImageProcess imageProcess)
        {
            _imageProcess = imageProcess;
            _lock = new object();
            LoadConfig(Config.Config.FilePath);
            _captureThread = new Thread(CaptureThreadFunction) { Priority = ThreadPriority.Highest };
             Cam = new Emgu.CV.Capture(_deviceIndex);
 
            SetResolution(Resolution.Vga);
            _frame = new Image<Hsv, byte>(_frameWidth, _frameHeight);
        }

        enum Resolution
        {

            Qvga,
            Vga,
            Svga,
            Hd,

        }


        private void SetResolution(Resolution resolution)
        {
            switch (resolution)
            {
                case Resolution.Qvga:
                    _frameWidth = 320;
                    _frameHeight = 240;
                    break;
                case Resolution.Vga:
                    _frameWidth = 640;
                    _frameHeight = 480;
                    break;
                case Resolution.Svga:
                    _frameWidth = 800;
                    _frameHeight = 600;
                    break;
                case Resolution.Hd:
                    _frameWidth = 960;
                    _frameHeight = 720;
                    break;
            }

            Cam.SetCaptureProperty(CapProp.FrameWidth, _frameWidth);
            Cam.SetCaptureProperty(CapProp.FrameHeight, _frameHeight);
            _frameCenter.X = _frameWidth / 2;
            _frameCenter.Y = _frameHeight / 2;
        }
        Stopwatch st = new Stopwatch();
      
        private void CaptureThreadFunction()
        {
            while (_enable)
            {
        
                try
                {

                 CvInvoke.CvtColor(Cam.QueryFrame(), Frame, ColorConversion.Bgr2Hsv);
             
                 _imageProcess.ProcessObject(Frame);
               
                if (_imageProcess.ProcessingMode == ImageProcess.Mode.Laboratory)
                {
                    _imageProcess.ProcessImage(Frame);
                }
                }
                catch
                {

                }
            Thread.Sleep(Interval);
            }
        }

        public void Start()
        {

            if (_enable)
            {
                return;
            }
            _enable = true;
            _captureThread = new Thread(CaptureThreadFunction);
            _captureThread.Start();

        }

        public void Stop()
        {
            if (_enable)
            {
                _enable = false;
            }

        }

        public void LoadConfig(string path)
        {
            var xmlDoc = XDocument.Load(path);
            var querys = from query in xmlDoc.Descendants("Capture")
                         select new
                         {
                             frameWidth = Convert.ToInt32(query.Attribute("FrameWidth").Value),
                             frameHeight = Convert.ToInt32(query.Attribute("FrameHeight").Value),
                             deviceIndex = Convert.ToInt32(query.Attribute("DeviceIndex").Value),
                             threadInterval = Convert.ToInt32(query.Attribute("ThreadInterval").Value)
                         };

            var data = querys.Single();
            _frameWidth = data.frameWidth;
            _frameHeight = data.frameHeight;
            _deviceIndex = data.deviceIndex;
            _interval = data.threadInterval;
        }

        public void SaveConfig(string path)
        {
            var xmlElem = XElement.Load(path);

            var configs = (from data in xmlElem.Descendants("Capture")
                           select data);
            var config = configs.Single();
            config.SetAttributeValue("FrameWidth", _frameWidth);
            config.SetAttributeValue("FrameHeight", _frameHeight);
            config.SetAttributeValue("DeviceIndex", _deviceIndex);
            config.SetAttributeValue("ThreadInterval", _interval);
            xmlElem.Save(path);
        }

    }
}
