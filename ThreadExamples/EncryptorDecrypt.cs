using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ThreadExamples
{
    internal class EncryptorDecrypt
    {
        private int shift;

        public EncryptorDecrypt()
        {
            shift = -5;
        }

        public void EncryptFile(string filePath)
        {
            ProcessFile(filePath, shift, "Encrypt end");
        }

        public void DecryptFile(string filePath)
        {
            ProcessFile(filePath, 256 - shift, "Decrypt end");
        }

        private void ProcessFile(string filepath, int shiftAmount, string doneMessage)
        {
            byte[] buffer = File.ReadAllBytes(filepath);
            byte[] result = new byte[buffer.Length];

            int lastReportedPercent = -1;

            for (int i = 0; i < buffer.Length; i++)
            {
                result[i] = (byte)((buffer[i] + shiftAmount) % 256);

                int percent = (int)((i + 1) * 100.0 / buffer.Length);

                if (percent != lastReportedPercent && percent % 5 == 0)
                {
                    lastReportedPercent = percent;
                    Console.WriteLine($"{filepath}: {percent}% done");
                    Thread.Sleep(500);
                }
            }

            File.WriteAllBytes(filepath, result);
            Console.WriteLine($"{doneMessage}: {filepath}");
        }
    }


}
