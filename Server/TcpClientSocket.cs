using Serilog;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server.Clients
{
    public class TcpClientThread : ISocketClient
    {
        private readonly TcpClient _tcpClient;
        private readonly NetworkStream clientStream;

        public TcpClientThread(TcpClient client)
        {
            _tcpClient = client;
            clientStream = _tcpClient.GetStream();
            Thread t = new Thread(HandleClient);
            t.Start();
        }

        private void HandleClient(object obj)
        {
            string reply;

            while (true)
            {
                reply = Receive();
                ClientHandler.Broadcast(reply, IpAddress());
            }
        }
        private string Receive()
        {
            const short bytesSize = 256;
            byte[] data = new byte[bytesSize];
            Int32 dataLength = clientStream.Read(data, 0, data.Length);

            Log.Information($"{IpAddress()}: {data.BytesToString(dataLength)}");
            return data.BytesToString(dataLength);
        }
        public string IpAddress()
        {
            return ((IPEndPoint)_tcpClient.Client.RemoteEndPoint).Address.ToString();
        }
        public NetworkStream GetStream()
        {
            return clientStream;
        }
    }
}