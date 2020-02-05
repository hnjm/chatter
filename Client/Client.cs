using System;
using System.Net.Sockets;

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
            sendMessage("Hello!");
            receiveMessage();
            client.Close();
        }
        private static void sendMessage(String message)
        {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        private static string receiveMessage() {
            Byte[] data = new Byte[256];
            String response = String.Empty;
            Int32 bytes = stream.Read(data, 0, data.Length);
            response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", response);
            return response;
        }
    }
}
