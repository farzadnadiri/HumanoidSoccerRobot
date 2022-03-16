using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Robot.Utils;
using System.Net.Sockets;

namespace Robot.Network.SenderListener
{
    public class UdpSenderListener : ISenderListener
    {
        public delegate void DataReceivedHandler(IPAddress address , byte[] data);
        public event DataReceivedHandler DataReceived;

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public Socket Socket { get; set; }

        private readonly object _locker;
        private int _port;
  
        private readonly Thread _listenThread;
    
        private UdpClient _listener;

        public UdpSenderListener()
        {
            Socket=new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _locker = new object();
     
            _listenThread = new Thread(Listen);
           
        }

        private void Listen()
        {
  
                IPEndPoint endPoint = null;
                var data = new byte[] {};
                try
                {
                   data = _listener.Receive(ref endPoint);
                }
                catch
                {

                }

            if (DataReceived == null || endPoint==null) return;
            DataReceived(endPoint.Address, data);
        }

        public bool SendData(string data, IPEndPoint endPoint)
        {
            return SendData(Encoding.ASCII.GetBytes(data), endPoint);
        }

        public bool SendData(string data, List<IPEndPoint> endPoints)
        {
            return endPoints.All(endPoint => SendData(data, endPoint));
        }

        public bool SendData(byte[] data, IPEndPoint endPoint)
        {
            lock (_locker)
            {
                try
                {
                    Socket.SendTo(data, endPoint);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SendData(byte[] data, List<IPEndPoint> endPoints)
        {
            return endPoints.All(endPoint => SendData(data, endPoint));
        }

       
        public bool StartListening(int port , int interval)
        {

            _port = port;

            try
            {
                _listener = new UdpClient(_port);
            }
            catch (SocketException exception)
            {

                return false;
            }

            _listenThread.Interval = interval;
            _listenThread.Start();
            return true;
            
        }

        public void StopListening()
        {
     
            _listenThread.Stop();
      
            if (_listener != null) _listener.Close();
        }

        protected virtual void OnDataReceived(IPAddress senderAdress, byte[] data)
        {
            var handler = DataReceived;
            if (handler != null) handler(senderAdress, data);
        }
 
    }
}
