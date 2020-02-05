using System;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Program
    {
        
        private const string serverIp = "192.168.1.67";
        private const Int32 serverPort = 13000;

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                Client client = new Client(serverIp, serverPort);
            }).Start();
        } 
    }
}
