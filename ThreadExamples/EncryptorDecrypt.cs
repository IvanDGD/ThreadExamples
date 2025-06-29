using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExamples
{    
    internal class EncryptorDecrypt
    {
        private int shift;

        public EncryptorDecrypt()
        {
            shift = -5;
        }

        public byte[] EncryptBytes(byte[] buffer)
        {
            byte[] result = new byte[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {
                result[i] = (byte)((buffer[i] + shift + 256) % 256);
            }

            return result;
        }
    }
}
