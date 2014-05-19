using System;
using MonoTorrent.Client;
using System.Collections;
using System.Text;

namespace MonoTorrent.CovertChannel
{
    public static class CovertChannel
    {


        //public static string targetPeerId{ get; set; }
        public static BitArray MessageBits{ get; set; }
        public static string ReceivedMessage{ get; set; }

        public static bool SentDone { get; set; }
        //public static Map<

        private static int nextIndex = 0;

        /// <summary>
        /// Gets the next bit of the message
        /// </summary>
        /// <returns>0 or 1 for the next bit</returns>
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

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[bits.Length / 8];
            bits.CopyTo(ret, 0);
            return ret;
        }

        public static string EncodeMessage(string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            BitArray bits = new System.Collections.BitArray(bytes);
            MessageBits = bits;

            return ToBitString(bits);
        }

        public static string DecodeMessage()
        {
            char[] charArray = ReceivedMessage.ToCharArray();
            Array.Reverse(charArray);
            string message = new string(charArray);

            int numOfBytes = message.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int p = 0; p < numOfBytes; p++)
            {
                bytes[p] = Convert.ToByte(message.Substring(8 * p, 8), 2);
            }
            Array.Reverse(bytes, 0, bytes.Length);
            BitArray b = new BitArray(bytes);

            return Encoding.ASCII.GetString(BitArrayToByteArray(b));

        }
    }
}

