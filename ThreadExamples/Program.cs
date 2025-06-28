namespace ThreadExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EncryptorDecrypt encryptor = new EncryptorDecrypt();

            Console.WriteLine("Enter file paths separated by ',' :");
            string input = Console.ReadLine();
            string[] filePaths = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Encrypt (e) or Decrypt (d)?");
            string cypherType = Console.ReadLine();

            List<(Thread thread, string path)> threads = new List<(Thread, string)>();

            foreach (var rawPath in filePaths)
            {
                string path = rawPath.Trim();

                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Error: empty path");
                    continue;
                }

                Console.WriteLine($"Enter priority for {path} (Lowest, BelowNormal, Normal, AboveNormal, Highest):");
                string priorityInput = Console.ReadLine();

                Thread thread = new Thread(() =>
                {
                    switch (cypherType)
                    {
                        case "e":
                            encryptor.EncryptFile(path);
                            break;
                        case "d":
                            encryptor.DecryptFile(path);
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                });

                if (Enum.TryParse(priorityInput, out ThreadPriority priority))
                {
                    thread.Priority = priority;
                }
                else
                {
                    Console.WriteLine("Invalid priority. Using Normal.");
                    thread.Priority = ThreadPriority.Normal;
                }

                threads.Add((thread, path));
            }

            foreach (var (thread, _) in threads)
            {
                thread.Start();
            }

            foreach (var (thread, _) in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All operations completed. Press Enter to exit.");
            Console.ReadKey();
        }
    }
}
