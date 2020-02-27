using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public sealed class Chat
    {
        private static Chat instance = null;
        private Chat() { }

        public static Chat Instance
        {
            get
            {
                if (instance == null)
                    instance = new Chat();

                return instance;
            }
        }

        List<ChatRoom> rooms = new List<ChatRoom>();

        public void AddClientToRoom(TcpClient tcpClient)
        {
            ChatUser chatUser = new ChatUser(tcpClient);
            Log.Information("Client {0} connected to server", chatUser.Ip);
        }
    }
}
