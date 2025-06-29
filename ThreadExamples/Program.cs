using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExamples
{
    internal class Program
    {
        static int processedFiles = 0;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter path to directory:");
            string directoryPath = Console.ReadLine();

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist.");
                return;
            }

            string[] files = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                Console.WriteLine("No .txt files found.");
                return;
            }

            int totalFiles = files.Length;
            int filesPerPercent = 10;
            int barLength = 50;

            Stopwatch stopwatch = Stopwatch.StartNew();

            List<Task> tasks = new List<Task>();

            foreach (string file in files)
            {
                tasks.Add(ProcessFileAsync(file, totalFiles, filesPerPercent, barLength));
            }

            await Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Processed {totalFiles} files in {stopwatch.Elapsed.TotalMilliseconds:F3} ms.");
        }

        static async Task ProcessFileAsync(string filePath, int totalFiles, int filesPerPercent, int barLength)
        {
            Console.WriteLine($"Started encrypting: {filePath}");

            EncryptorDecrypt encryptor = new EncryptorDecrypt();

            byte[] originalData = File.ReadAllBytes(filePath);
            byte[] encryptedData = encryptor.EncryptBytes(originalData);

            await File.WriteAllBytesAsync(filePath, encryptedData);

            Console.WriteLine($"Encryption done: {filePath}");

            int done = System.Threading.Interlocked.Increment(ref processedFiles);

            if (done % filesPerPercent == 0 || done == totalFiles)
            {
                DrawProgressBar(done, totalFiles, barLength);
            }
        }

        static void DrawProgressBar(int done, int total, int barLength)
        {
            double percent = (double)done / total;
            int filled = (int)(percent * barLength);

            StringBuilder bar = new StringBuilder();
            bar.Append('[');
            bar.Append(new string('#', filled));
            bar.Append(new string('.', barLength - filled));
            bar.Append(']');
            bar.Append($" {percent * 100:F1}% ({done}/{total})");

            try
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;

                if (top > 0)
                    Console.SetCursorPosition(0, top - 1);

                Console.Write(bar.ToString().PadRight(Console.WindowWidth - 1));

                Console.SetCursorPosition(left, top);
            }
            catch
            {
                Console.WriteLine(bar.ToString());
            }
        }
    }
}
