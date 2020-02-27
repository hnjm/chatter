using Serilog;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    internal class Server
    {
        private const string serverIp = "192.168.1.67";
        private const Int32 serverPort = 13000;

        private TcpListener tcpListener = null;
        private Chat chat = null;

        public Server()
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

            Log.Information($"Loading chat...");
            chat = Chat.Instance;

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
                    Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Log.Error("SocketException: {0}", e);
                tcpListener.Stop();
            }
        }

        private void HandleClient(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            chat.AddClientToRoom(client);
        }
    }
}