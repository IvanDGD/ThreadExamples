using System;
using System.Threading;

namespace ChildApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            //Thread threadWithLambda = new Thread(() =>
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        Console.WriteLine("Child process is running");
            //        Thread.Sleep(500);
            //    }
            //});
            //threadWithLambda.Start();
            //threadWithLambda.Join();

            // #2
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Before choose");
            //    Thread.Sleep(300);
            //}
            //Console.WriteLine("Enter your choose, you have only 10 seconds");
            //Thread.Sleep(10000);
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("After choose");
            //    Thread.Sleep(300);
            //}

            // #3
            //if (args.Length != 3)
            //{
            //    Console.WriteLine("Invalid arguments. Usage: <num1> <num2> <operation>");
            //}
            //int num1 = Int32.Parse(args[0]);
            //int num2 = Int32.Parse(args[1]);

            //string op = args[2];
            //int result = 0;
            //bool success = true;

            //switch (op)
            //{
            //    case "+":
            //        result = num1 + num2;
            //        break;
            //    case "-":
            //        result = num1 - num2;
            //        break;
            //    case "*":
            //        result = num1 * num2;
            //        break;
            //    case "/":
            //        if (num2 == 0)
            //        {
            //            Console.WriteLine("Division by zero!");
            //            break;
            //        }
            //        result = num1 / num2;
            //        break;
            //    default:
            //        Console.WriteLine("Unknown operation.");
            //        break;
            //}

            //Console.WriteLine($"{num1} {op} {num2} = {result}");        }

            // #4
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments. Usage: <filePath> <word>");
            }

            string filePath = args[0];
            string searchWord = args[1];

            string content = File.ReadAllText(filePath);
            int count = 0;
            char[] separators = { ' ', '\t', '\r', '\n', '.', ',', ';', '!', '?', ':', '-', '(', ')', '[', ']', '{', '}', '\"', '\'' };
            string[] words = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (string.Equals(word, searchWord, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }

            Console.WriteLine($"{count} times.");
        }
    }
}
