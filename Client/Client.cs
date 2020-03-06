using System;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Client
    {
        private static TcpClient client = null;
        private static NetworkStream stream = null;

        public Client(string serverIp, int serverPort)
        {
            client = new TcpClient(serverIp, serverPort);
            stream = client.GetStream();
            string message;
            Thread t = new Thread(HandleClient);
            t.Start();
            while (true)
            {
                message = Console.ReadLine();
                SendMessage(message);
            }
        }
        private static void SendMessage(String message)
        {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        private void HandleClient()
        {
            while(true)
            {
                ReceiveMessage();
            }
        }

        private static string ReceiveMessage() {
            Byte[] data = new Byte[256];
            Int32 bytes = stream.Read(data, 0, data.Length);
            string response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine(response);
            return response;
        }
    }
}
