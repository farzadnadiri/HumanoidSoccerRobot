using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Robot.Network.SenderListener;
using Robot.Utils;

namespace Robot.Network
{
    public class Communication
    {

        public int TeamMateDistance {
            set {_receivedLog.Add(value); }
            get
            {
                if (TimeToLive.ElapsedMilliseconds < 1200 && _receivedLog.Count > 3)
                {
                  
                        return ((_receivedLog[_receivedLog.Count - 1] + _receivedLog[_receivedLog.Count - 2] +
                                 _receivedLog[_receivedLog.Count - 3])/3);
                
                }
                return -1;
            }
        }
        private readonly List<int> _receivedLog;

        public int MyDistance {set; get; }

        public Stopwatch TimeToLive;
      
        public int Interval { get; set; }
        public int SendPort { get; set; }
        public int RecievePort { get; set; }
        public IPAddress TeamMateIpAddress { get; set; }
        private readonly UdpSenderListener _listener;
        private readonly IPEndPoint _ipEndPoint;

        public Communication()
        {
            _receivedLog = new List<int>();
            TeamMateDistance = -1;
            _listener = new UdpSenderListener();
            LoadConfig("Config/Config.xml");
            _ipEndPoint = new IPEndPoint(TeamMateIpAddress, SendPort);
            _listener.DataReceived += OnReceived;
            TimeToLive=new Stopwatch();
            _sendData=new Thread(SendMyDistance);
            MyDistance = -1;
        }

        private void SendMyDistance()
        {
            _listener.SendData("*QHeader*" + MyDistance.ToString(CultureInfo.InvariantCulture) + "*QTailer", _ipEndPoint);
        }

        private readonly Thread _sendData;

        public void Start()
        {
            _listener.StartListening(RecievePort, Interval);
            TimeToLive.Start();
            _sendData.Start();
        }

        public void Stop()
        {
            _listener.StopListening();
            _sendData.Stop();
        }
        private void OnReceived(IPAddress address, byte[] data)
        {
            if (Equals(address, TeamMateIpAddress))
            {

                var stringData = System.Text.Encoding.UTF8.GetString(data).Split('*');
                if (stringData[1] == "QHeader" && stringData[3] == "QTailer")
                {
                    try
                    {
                        TeamMateDistance = Convert.ToInt32(stringData[2]);
                    }
                    catch
                    {
                        TeamMateDistance = -1;
                    }
                }
                TimeToLive.Restart();
 
            }
            else
            {
                TeamMateDistance = -1;
            }
        }

        private void LoadConfig(string path)
        {
            var xmlDoc = XDocument.Load(path);
            var querys = from query in xmlDoc.Descendants("Communication")
                         select new
                         {

                             Interval = Convert.ToInt32(query.Attribute("Interval").Value),
                             SendPort = Convert.ToInt32(query.Attribute("SendPort").Value),
                             RecivePort = Convert.ToInt32(query.Attribute("RecivePort").Value),
                             TeamMateIp = (query.Attribute("TeamMateIp").Value),

                         };
            var data = querys.Single();
            TeamMateIpAddress = IPAddress.Parse(data.TeamMateIp);
            SendPort = data.SendPort;
            RecievePort = data.RecivePort;
            Interval = data.Interval;

        }
    }
}
