using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Robot.Utils;

namespace Robot.Network.SenderListener
{
    interface ISenderListener
    {

        /// <summary>
        /// the socket through which data will be sent
        /// </summary>
        Socket Socket { get; set; }

        /// <summary>
        /// send data to a host
        /// </summary>
        /// <param name="data">string must be send</param>
        /// <param name="endPoint">endpoint of receiver </param>
        /// <returns></returns>
        bool SendData(string data, IPEndPoint endPoint);

        /// <summary>
        /// send data to multi hosts
        /// </summary>
        /// <param name="data">string must be send</param>
        /// <param name="endPoint">endpoints of receivers</param>
        /// <returns></returns>
        bool SendData(string data, List<IPEndPoint> endPoint);

        /// <summary>
        /// send data to a host
        /// </summary>
        /// <param name="data">bytes must be send</param>
        /// <param name="endPoint">endpoint of receiver</param>
        /// <returns></returns>
        bool SendData(byte[] data, IPEndPoint endPoint);

        /// <summary>
        /// send data to multi hosts
        /// </summary>
        /// <param name="data">bytes must be send</param>
        /// <param name="endPoint">endpoints of receivers</param>
        /// <returns></returns>
        bool SendData(byte[] data, List<IPEndPoint> endPoint);

        /// <summary>
        /// Start listenning on listen port
        /// </summary>
        bool StartListening(int port , int interval);

        /// <summary>
        /// Stop listening on listen port
        /// </summary>
        void StopListening();


    }
}
