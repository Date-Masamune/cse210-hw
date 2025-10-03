using System;
using System.Threading;

namespace MindfulnessApp
{
    abstract class Activity
    {
        protected string Name { get; }
        protected string Description { get; }
        protected int DurationSeconds { get; private set; }
        private DateTime _startedAt;

        protected Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---\n{Description}\n");
            DurationSeconds = AskForDuration();
            _startedAt = DateTime.Now;

            Console.Write("\nGet ready ");
            ShowSpinner(3);
            Console.Clear();
        }

        public void End()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(2);
            Console.WriteLine($"\nYou completed the {Name} for {DurationSeconds} seconds.");
            Console.Write("Returning to menu ");
            ShowSpinner(2);

            ActivityLogger.Log(Name, DurationSeconds, _startedAt, DateTime.Now);
        }

        public abstract void Run();

        protected static void ShowSpinner(int seconds)
        {
            var frames = new[] { "|", "/", "-", "\\" };
            var until = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < until)
            {
                Console.Write(frames[i++ % frames.Length]);
                Thread.Sleep(120);
                Console.Write("\b");
            }
        }

        protected static void Countdown(int from)
        {
            for (int i = from; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        private static int AskForDuration()
        {
            while (true)
            {
                Console.Write("Enter duration (seconds): ");
                if (int.TryParse(Console.ReadLine(), out int s) && s > 0) return s;
                Console.WriteLine("Please enter a positive whole number.\n");
            }
        }
    }
}
