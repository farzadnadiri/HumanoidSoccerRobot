
using Robot.Environment;
using Robot.Utils;
using Robot.Vision.ImageProcessing;

namespace Robot.Vision.HeadControl
{
    public class Search
    {
        private Thread _searchThread;
        private delegate void SearchMethodDelegate();
        private SearchMethodDelegate _lookAround;

        public int PanMin { set; get; }
        public int PanMax { set; get; }
        public bool Enable
        {
            get;
            set;
        }

        public int Interval
        {
            get;
            set;
        }
        public int MovingUnit
        {
            get;
            set;
        }
        public int PanMinGoal
        {
            get;
            set;
        }
        public int PanMaxGoal
        {
            get;
            set;
        }

        public int DownTilt
        {
            get;
            set;
        }
        public int MiddleTilt
        {
            get;
            set;
        }
        public int UpTilt
        {
            get;
            set;
        }

        public SightDirectionEnum SightDirection
        {
            get
            {
                if (_head.Tilt.Position == DownTilt)
                {
                    return SightDirectionEnum.Down;
                }

                if (_head.Tilt.Position == MiddleTilt)
                {
                    return SightDirectionEnum.Middle;
                }

                if (_head.Tilt.Position == UpTilt)
                {
                    return SightDirectionEnum.Up;
                }
                return SightDirectionEnum.None;
            }
            set
            {
                if (value == SightDirectionEnum.Down)
                {
                    _head.Tilt.Position = DownTilt;
                }
                else if (value == SightDirectionEnum.Middle)
                {
                    _head.Tilt.Position = MiddleTilt;
                }
                else if (value == SightDirectionEnum.Up)
                {
                    _head.Tilt.Position = UpTilt;
                }
            }
        }

        public MovingDirection Direction
        {
            get
            {
                if (MovingUnit < 0)
                {
                    return MovingDirection.LeftToRight;
                }
                return MovingDirection.RightToLeft;
            }
            set
            {
                if (value == MovingDirection.RightToLeft)
                {
                    MovingUnit = System.Math.Abs(MovingUnit);
                    //  _head.Pan.Position = PanMinGoal;

                }
                if (value == MovingDirection.LeftToRight)
                {
                    MovingUnit = -1 * System.Math.Abs(MovingUnit);
                    // _head.Pan.Position = PanMaxGoal;
                }
            }
        }

        public enum MovingDirection
        {
            RightToLeft,
            LeftToRight
        }

        public enum SightDirectionEnum
        {
            None,
            Up,
            Middle,
            Down
        }

        public enum SearchMethod
        {
            Around,
            Far
        }

        private void SearchThreadFunction()
        {

            _lookAround();

        }

        public void Start()
        {



            DownSpeed = 225;
            DownInterval = 30;

            MiddleSpeed = 175;
            MiddleInterval = 50;

            UpSpeed = 120;
            UpInterval = 60;

            _searchThread.Interval = DownInterval;
            SetupHead();
            Enable = true;
            counter = 0;
            _searchThread.Start();
        }

        public void Stop()
        {
            _searchThread.Stop(true, false);
            Enable = false;
            counter = 0;

        }

        private int counter;
        private readonly Head _head;
        public Search(Head head)
        {

            _head = head;
            _searchThread = new Thread(SearchThreadFunction);
            UpTilt = 490;
            MiddleTilt = 400;
            DownTilt = 230;
            PanMin = 110;
            PanMax = 950;
          
            MovingUnit = 10;

            SetupHead();


        }

        private void SetupHead()
        {
           _head.Tilt.Speed = 120;
            _head.Pan.Slop = 128;
            _head.Tilt.Slop = 128;
            _head.Pan.Margin = 1;
            _head.Tilt.Margin = 1;
        }

        public void AroundScan()
        {

            if (counter > 3)
            {
                DownSpeed = 225;
                DownInterval = 30;

                MiddleSpeed = 175;
                MiddleInterval = 50;

                UpSpeed = 120;
                UpInterval = 60;

            }
            else
            {
                DownSpeed = 225;
                DownInterval = 30;

                MiddleSpeed = 175;
                MiddleInterval = 50;

                UpSpeed = 120;
                UpInterval = 60;
            }


            _head.Pan.Speed =  DownSpeed;
            Interval = DownInterval;

            Scan(MovingDirection.LeftToRight, SightDirectionEnum.Down);

            _head.Pan.Speed =  MiddleSpeed;
            Interval = MiddleInterval;

            Scan(MovingDirection.RightToLeft, SightDirectionEnum.Middle);


            _head.Pan.Speed = UpSpeed;
            Interval = UpInterval;

            Scan(MovingDirection.LeftToRight, SightDirectionEnum.Up);
            Scan(MovingDirection.RightToLeft, SightDirectionEnum.Up);


            _head.Pan.Speed = MiddleSpeed;
            Interval = MiddleInterval;

            Scan(MovingDirection.LeftToRight, SightDirectionEnum.Middle);


            _head.Pan.Speed =  DownSpeed;
            Interval = DownInterval;

            Scan(MovingDirection.RightToLeft, SightDirectionEnum.Down);

            counter++;
        }


        public int DownSpeed = 450;
        public int DownInterval = 15;

        public int MiddleSpeed = 350;
        public int MiddleInterval = 25;

        public int UpSpeed = 250;
        public int UpInterval = 30;




        public void FarScan()
        {
            if (counter < 1)
            {
                _head.Pan.Speed = _head.Tilt.Speed = 120;
                Interval = 50;
            }
            else if (counter < 3)
            {
                _head.Pan.Speed = _head.Tilt.Speed = 80;
                Interval = 100;
            }
            else
            {
                counter = 0;
            }

            Scan(MovingDirection.LeftToRight, SightDirectionEnum.Up);

            Scan(MovingDirection.RightToLeft, SightDirectionEnum.Up);
            counter++;
        }

        private void Scan(MovingDirection direction, SightDirectionEnum sight)
        {
            if (Enable)
            {
                SightDirection = sight;
                Direction = direction;
            }
            else { return; }

            _head.Pan.Position = Direction == MovingDirection.RightToLeft ? PanMin : PanMax;
            while ((_head.Pan.Position >= PanMin) && (_head.Pan.Position <= PanMax))
            {
                _head.Pan.Position += MovingUnit;
                _searchThread.Sleep(Interval);

            }

        }

        public void SelectSearchMethod(SearchMethod selectedMethod)
        {
            switch (selectedMethod)
            {
                case SearchMethod.Around:
                    _lookAround = AroundScan;
                    break;
                case SearchMethod.Far:
                    _lookAround = FarScan;
                    break;
            }
        }
    }
}
