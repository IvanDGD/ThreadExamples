using System;
using System.Diagnostics;

namespace ParentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            //Process process = new Process();
            //process.StartInfo.FileName = "C:\\Users\\user\\Desktop\\VisualStudio2022\\ThreadExamples\\ChildApp\\bin\\Debug\\net8.0\\ChildApp.exe";

            //process.Start();
            //process.WaitForExit();

            //Console.WriteLine($"Child exited with code: {process.ExitCode}");

            // #2
            //Process process = new Process();
            //process.StartInfo.FileName = "C:\\Users\\user\\Desktop\\VisualStudio2022\\ThreadExamples\\ChildApp\\bin\\Debug\\net8.0\\ChildApp.exe";

            //process.Start();

            //Console.WriteLine("Enter action: 1 — wait, 2 — kill");
            //string input = Console.ReadLine();

            //if (input == "1")
            //{
            //    process.WaitForExit();
            //    Console.WriteLine($"Child exited with code: {process.ExitCode}");
            //}
            //else if (input == "2")
            //{
            //    process.Kill();
            //    Console.WriteLine("Child process was killed.");
            //}
            //else
            //{
            //    Console.WriteLine("Unknown option.");
            //}

            // #3
            //Console.Write("Enter first number: ");
            //int num1 = Int32.Parse(Console.ReadLine());

            //Console.Write("Enter second number: ");
            //int num2 = Int32.Parse(Console.ReadLine());

            //Console.Write("Enter operation (+, -, *, /): ");
            //string operation = Console.ReadLine();

            //Process process = new Process();
            //process.StartInfo.FileName = "C:\\Users\\user\\Desktop\\VisualStudio2022\\ThreadExamples\\ChildApp\\bin\\Debug\\net8.0\\ChildApp.exe"; 
            //process.StartInfo.Arguments = $"{num1} {num2} {operation}";

            //process.Start();
            //process.WaitForExit();

            //Console.WriteLine($"Child exited with code: {process.ExitCode}");

            // #4
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            Console.Write("Enter word to search: ");
            string word = Console.ReadLine();

            Process process = new Process();
            process.StartInfo.FileName = "C:\\Users\\user\\Desktop\\VisualStudio2022\\ThreadExamples\\ChildApp\\bin\\Debug\\net8.0\\ChildApp.exe";
            process.StartInfo.Arguments = $"\"{filePath}\" {word}";

            process.Start();
            process.WaitForExit();

            Console.WriteLine($"Child exited with code: {process.ExitCode}");
        }
    }
}
