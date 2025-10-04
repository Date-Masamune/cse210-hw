using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class ReflectingActivity : Activity
    {
        private static readonly string[] Prompts =
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly string[] Questions =
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private readonly Random _rand = new Random();

        public ReflectingActivity()
          : base(
              "Reflecting Activity",
              "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
            )
        { }

        public override void Run()
        {
            string prompt = Prompts[_rand.Next(Prompts.Length)];
            Console.WriteLine($"> {prompt}\n");
            Console.Write("When you have something in mind, press Enter to continue...");
            Console.ReadLine();
            Console.WriteLine("\nConsider each of the following questions:");
            Console.WriteLine("(You'll have a few seconds after each one.)\n");

            var end = DateTime.Now.AddSeconds(DurationSeconds);

            var bag = new List<string>(Questions);
            Shuffle(bag);

            int idx = 0;
            while (DateTime.Now < end)
            {
                Console.Write($"- {bag[idx]} ");
                ShowSpinner(8);
                Console.WriteLine();

                idx++;
                if (idx >= bag.Count)
                {
                    Shuffle(bag);
                    idx = 0;
                }
            }
        }

        private void Shuffle(List<string> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
