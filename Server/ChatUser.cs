using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class ChatUser
    {
        private IPAddress ip;

        public ChatUser(TcpClient tcpClient)
        {
            ip = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
        }

        public string Ip => ip.ToString();
    }
}
