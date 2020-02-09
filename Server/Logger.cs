using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    static class Logger
    {
        public static void Write(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} - Server - {message}");
        }
        public static void Write(TcpClient client, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} - {((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()} - {message}");
        }
    }
}
