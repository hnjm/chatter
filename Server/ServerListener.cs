using Serilog;
using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class ServerListener
    {
        private string serverIp;
        private Int32 serverPort;

        private TcpListener tcpListener = null;

        public ServerListener()
        {
            serverIp = GetLocalIPAddress();
            serverPort = 13000;
        }
        public ServerListener(string ip, Int32 port)
        {
            serverIp = ip;
            serverPort = port;
        }
        public void Run()
        {
            Log.Information("Starting server...");
            ConfigureListener();
            Listen();
        }

        public void ConfigureListener()
        {
            IPAddress localAddr = IPAddress.Parse(serverIp);
            tcpListener = new TcpListener(localAddr, serverPort);
        }
        private void Listen()
        {
            tcpListener.Start();
            Log.Information($"Listening on {serverIp}:{serverPort}");
            AcceptClients();
        }
        private void AcceptClients()
        {
            try
            {
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    ClientHandler.Add(client);
                }
            }
            catch (SocketException e)
            {
                Log.Error("SocketException: {0}", e);
                tcpListener.Stop();
            }  
        }
        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}