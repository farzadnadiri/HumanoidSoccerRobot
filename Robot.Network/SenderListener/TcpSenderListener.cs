using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Robot.Network.SenderListener 
{
    class TcpSenderListener :ISenderListener
    {
        #region reg
        /*
        private readonly IPEndPoint _endPoint;
        private readonly Socket _tcpSocket;
        private readonly TcpClient _tcpClient;

        public TcpSenderListener(string ip , int port)
        {
           _endPoint=new IPEndPoint(IPAddress.Parse(ip),port);
           _tcpClient=new TcpClient(_endPoint);
           _tcpSocket = _tcpClient.Client;
        }

        public void Receive(byte[] buffer, int offset, int size, int timeout)
        {
            var startTickCount = Environment.TickCount;
            var received = 0; 
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    received += _tcpSocket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        Thread.Sleep(30);
                    }
                    else
                        throw;
                }
            } while (received < size);
        }

        public  void Send( byte[] buffer, int offset, int size, int timeout)
        {
            var startTickCount = Environment.TickCount;
            var sent = 0; 
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try
                {
                    sent += _tcpSocket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        Thread.Sleep(30);
                    }
                    else
                        throw;
                }
            } while (sent < size);
        }

        */
        #endregion

        public Socket Socket { get; set; }
        public bool SendData(string data, IPEndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public bool SendData(string data, List<IPEndPoint> endPoint)
        {
            throw new NotImplementedException();
        }

        public bool SendData(byte[] data, IPEndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public bool SendData(byte[] data, List<IPEndPoint> endPoint)
        {
            throw new NotImplementedException();
        }

        public bool StartListening(int port, int interval)
        {
            throw new NotImplementedException();
        }

        public void StopListening()
        {
            throw new NotImplementedException();
        }
    }
}
