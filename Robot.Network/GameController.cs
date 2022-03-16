using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Robot.Network.SenderListener;

namespace Robot.Network
{
    public  class GameController
    {
        public delegate void StatusCheangedHandler(GameControllerStatus status);
        public  event StatusCheangedHandler GameStatusCheanged;

        public delegate void SecondaryStateCheangedHandler(TsecondaryState state);
        public  event SecondaryStateCheangedHandler SecoundaryStateCheanged;

        public delegate void StartingModeCheangedHandler(TstartingMode mode);
        public  event StartingModeCheangedHandler StartingModeCheanged;

       protected virtual  void OnStartingModeCheanged(TstartingMode mode)
        {
            var handler = StartingModeCheanged;
            if (handler != null) handler(mode);
        }


        public delegate void HalfTimeCheangedHandler(ThalfTime half);
        public  event HalfTimeCheangedHandler HalfTimeCheanged;

        public delegate void RivalGoalCheangedHandler(GoalColor color);
        public  event RivalGoalCheangedHandler RivalGoalCheanged;

        public delegate void IsWeCyanCheangedHandler(bool isWeCyan);
        public  event IsWeCyanCheangedHandler IsWeCyanCheanged;

        public delegate void GameTimeCheangedHandler(TimeSpan time);
        public  event GameTimeCheangedHandler GameTimeCheanged;

        public delegate void ResultCheangedHandler(int result);
        public  event ResultCheangedHandler RivalResultCheanged;
        public  event ResultCheangedHandler OurResultCheanged;

        private static string _gameControllerIp;
        private static GameControllerStatus _gameStatus;
        private static TstartingMode _startingMode;
        private static TsecondaryState _secondaryState;
        private static GoalColor _rivalGoal;
        private static ThalfTime _halfTime;
        private static TimeSpan _gameTime;
        private static bool _isWeCyan;
        private static int _tx, _mx, _sx, _ourTeamNumber, _senderPort, _ourResult, _rivalResult, _interval;
        private static UdpSenderListener _listener;

        public  int OurResult
        {
            get
            {
                return _ourResult;
            }
            set
            {
                if (value != _ourResult)
                {
                    if (OurResultCheanged != null)
                    OurResultCheanged(value);
                }
                _ourResult = value;
            }
        }

        public  int RivalResult
        {
            get
            {
                return _rivalResult;
            }
            set
            {
                if (value != _rivalResult)
                {
                    if (RivalResultCheanged != null)
                    RivalResultCheanged(value);
                }
                _rivalResult = value;
            }
        }

        public  bool IsWeCyan
        {
            get
            {
                return _isWeCyan;
            }
            set
            {
                if (value != _isWeCyan)
                {
                    if (IsWeCyanCheanged != null)
                    IsWeCyanCheanged(value);
                }
                _isWeCyan = value;
            }
        }

        public  TstartingMode StartingMode
        {
            get
            {
                return _startingMode;
            }
            set
            {
                if (value != _startingMode)
                {
                    if (StartingModeCheanged != null)
                    StartingModeCheanged(value);
                }
                _startingMode = value;
            }
        }

        public  ThalfTime HalfTime
        {
            get
            {
                return _halfTime;
            }
            set
            {
                if (value != _halfTime)
                {
                    if (HalfTimeCheanged != null)
                    HalfTimeCheanged(value);
                }
                _halfTime = value;
            }
        }


        public  TsecondaryState SecondaryState
        {
            get
            {
                return _secondaryState;
            }
            set
            {
                if (value != _secondaryState)
                {
                    if (SecoundaryStateCheanged != null)
                    SecoundaryStateCheanged(value);
                }
                _secondaryState = value;
            }
        }
        public  GoalColor RivalGoal
        {
            get
            {
                return _rivalGoal;
            }
            set
            {
                if (value != _rivalGoal)
                {
                    if (RivalGoalCheanged != null)
                    RivalGoalCheanged(value);
                }
                _rivalGoal = value;
            }
        }

        public  GameControllerStatus GameStatus
        {
            get
            {
                return _gameStatus;
            }
            set
            {
                if (value != _gameStatus)
                {
                    if (GameStatusCheanged != null)
                    GameStatusCheanged(value);
                }
                _gameStatus = value;
            }
        }

        public  TimeSpan GameTime
        {
            get
            {
                return _gameTime;
            }
            set
            {
                if (value != _gameTime)
                {
                    if (GameTimeCheanged != null)
                    GameTimeCheanged(value);
                }
                _gameTime = value;
            }
        }


        public static int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
        public static string GameControllerIp
        {
            get { return _gameControllerIp; }
            set { _gameControllerIp = value; }
        }
        public static int SenderPort
        {
            get { return _senderPort; }
            set { _senderPort = value; }
        }
        public static int OurTeamNumber
        {
            get { return _ourTeamNumber; }
            set { _ourTeamNumber = value; }
        }



        public enum GameControllerStatus
        {
            Initialize,
            Ready,
            Set,
            Play,
            Finish
        }

        public enum GoalColor
        {
            Blue,
            Yellow
        }

        public enum ThalfTime
        {
            SecondHalf,
            FirstHalf
        }
        public enum TsecondaryState
        {
            Normal,
            PenaltyShoot,
            OverTime
        }
        public enum TstartingMode
        {
            CyanKickOff,
            MagentaKickOff,
            DropBall
        }

         public GameController()
        {
            _listener = new UdpSenderListener();
            LoadConfig("Config/Config.xml");
            _listener.StartListening(SenderPort,Interval);
            _listener.DataReceived += OnReceived;
             GameStatus=GameControllerStatus.Initialize;
        }

        private  void OnReceived(IPAddress sender, byte[] data)
        {
            if ((!Equals(sender, IPAddress.Parse(_gameControllerIp))) ||
                (data[0] != 82 || data[1] != 71 || data[2] != 109 || data[3] != 101) ||
                (data[20] != _ourTeamNumber && data[68] != _ourTeamNumber)) return;

            if (data[20] != OurTeamNumber)
            {
                RivalGoal = (GoalColor)data[22];
                IsWeCyan = false;
                OurResult = data[71];
                RivalResult = data[23];

                GameStatus = (GameControllerStatus)data[9];
                StartingMode = (TstartingMode)data[11];
                SecondaryState = (TsecondaryState)data[12];
                HalfTime = (ThalfTime)data[10];
                _tx = ((data[16] + (data[17] * 255)));
                _mx = (_tx / 60);
                _sx = (_tx - (_mx * 60));
                GameTime = new TimeSpan(0, _mx, _sx);
                }

            else 
            {
                RivalGoal = (GoalColor)data[70];
                IsWeCyan = true;
                OurResult = data[23];
                RivalResult = data[71];

                GameStatus = (GameControllerStatus)data[9];
                StartingMode = (TstartingMode)data[11];
                SecondaryState = (TsecondaryState)data[12];
                HalfTime = (ThalfTime)data[10];
                _tx = ((data[16] + (data[17] * 255)));
                _mx = (_tx / 60);
                _sx = (_tx - (_mx * 60));
                GameTime = new TimeSpan(0, _mx, _sx);
               }

        }

        public static void Start()
        {
        
            _listener.StartListening(_senderPort, _interval);
        }

        public static void Stop()
        {
            _listener.StopListening();
        }

        public void LoadConfig(string path)
        {
            var xmlDoc = XDocument.Load(path);
            var querys = from query in xmlDoc.Descendants("GameController")
                select new
                {
                    OurTeamNumber = Convert.ToInt32(query.Attribute("OurTeamNumber").Value),
                    Interval = Convert.ToInt32(query.Attribute("Interval").Value),
                    SenderPort = Convert.ToInt32(query.Attribute("SenderPort").Value),
                    SenderIp = (query.Attribute("SenderIp").Value),

                };
            var data = querys.Single();
            GameControllerIp = data.SenderIp;
            OurTeamNumber = data.OurTeamNumber;
            SenderPort = data.SenderPort;
            Interval = data.Interval;
        }
    }
}
