using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ThreadExamples
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;


            Console.WriteLine("Press any key to exit...\n");
            Console.ReadKey();
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Current Time:");
            Console.WriteLine(DateTime.Now);
        }
    }
}
