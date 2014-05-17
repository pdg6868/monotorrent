using System;
using MonoTorrent.Client;
using System.Collections;
using System.Text;

namespace MonoTorrent.CovertChannel
{
    public static class CovertChannel
    {

        //public static string Message{ get; set; }
        public static string targetPeerId{ get; set; }
        public static BitArray MessageBits{ get; set; }
        public static string RecievedMessage{ get; set; }
        //public static Map<

        private static int nextIndex = 0;

        public static int getNextBit(){
            if (nextIndex == MessageBits.Length) {
                return -1;
            }
            bool next = MessageBits.Get (nextIndex);
            if (next) {
                return 1;
            }
            return 0;
        }

        public static void incrementNextBit(){
            nextIndex++;
        }

        public static string ToBitString(this BitArray bits)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < bits.Count; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static string GetBits(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.ASCII.GetBytes(input))
            {
                sb.Append(Convert.ToString(b, 2));
            }
            return sb.ToString();
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[bits.Length / 8];
            bits.CopyTo(ret, 0);
            return ret;
        }
    }
}

