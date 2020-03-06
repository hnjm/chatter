using System;
using System.Text;

namespace Server
{
    public static class Parser
    {
        public static byte[] StringToBytes(this String str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static string BytesToString(this Byte[] bytes, Int32 dataLength)
        {
            return Encoding.ASCII.GetString(bytes, 0, dataLength);
        }
    }
}
