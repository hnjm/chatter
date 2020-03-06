using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Server.Clients;

namespace Server
{
    public sealed class ClientHandler
    { 
        private static List<TcpClientThread> clients = new List<TcpClientThread>();

        public static void Add(TcpClient client)
        {
            TcpClientThread clientSocket = new TcpClientThread(client);
            clients.Add(clientSocket);
        }
        public static void Broadcast(string message, string ip)
        {
            foreach (TcpClientThread client in clients)
            {
                if (client.IpAddress().Equals(ip)) continue;

                byte[] reply = message.StringToBytes();
                client.GetStream().Write(reply, 0, reply.Length);
                client.GetStream().Flush();
            }
        }
    }
}
