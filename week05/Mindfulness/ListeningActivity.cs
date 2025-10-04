using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private static readonly string[] Prompts =
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private readonly Random _rand = new Random();

        public ListingActivity()
          : base(
              "Listing Activity",
              "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
            )
        { }

        public override void Run()
        {
            string prompt = Prompts[_rand.Next(Prompts.Length)];
            Console.WriteLine($"> {prompt}\n");
            Console.Write("Get ready to begin listing in: ");
            Countdown(5);
            Console.WriteLine();

            var end = DateTime.Now.AddSeconds(DurationSeconds);
            var items = new List<string>();

            while (DateTime.Now < end)
            {
                var remaining = end - DateTime.Now;
                if (remaining <= TimeSpan.Zero) break;

                Console.Write("> ");
                string line = ReadLineWithTimeout(remaining);

                if (!string.IsNullOrWhiteSpace(line))
                {
                    items.Add(line.Trim());
                }
                else
                {
                    Thread.Sleep(50);
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} item(s).");
        }

        private static string ReadLineWithTimeout(TimeSpan timeout)
        {
            var readTask = Task.Run(Console.ReadLine);
            return readTask.Wait(timeout) ? (readTask.Result ?? string.Empty) : string.Empty;
        }
    }
}
