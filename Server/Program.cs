using System;
using System.Threading;

namespace Server
{
    class Program
    {
        private const string IPAdress = "192.168.1.67";
        private const Int32 Port = 13000;

        static void Main(string[] args)
        {
            Thread t = new Thread(delegate ()
            {
                Server server = new Server(IPAdress, Port);
            });

            t.Start();
        }
    }
}