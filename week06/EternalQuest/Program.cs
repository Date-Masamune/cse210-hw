/*
Exceeding Requirements(Creativity):
-Added a lightweight Leveling system:
  • Every 500 points increases your Level.
  • The menu shows Level and points needed to reach the next Level.
  • A “Level Up” message appears when you cross a threshold.
using System;
*/

namespace GoalTracker
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var manager = new GoalManager();
            manager.RunMenu();
        }
    }
}
