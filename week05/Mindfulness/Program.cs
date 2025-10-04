using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Activities");
                Console.WriteLine("1) Breathing");
                Console.WriteLine("2) Reflecting");
                Console.WriteLine("3) Listing");
                Console.WriteLine("4) Quit");
                Console.Write("\nChoose an option: ");
                var choice = Console.ReadLine();

                Activity activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectingActivity(),
                    "3" => new ListingActivity(),
                    "4" => null,
                    _ => null
                };

                if (choice == "4") break;
                if (activity == null) continue;

                activity.Start();
                activity.Run();
                activity.End();
            }

            Console.WriteLine("\nGoodbye!\n");
        }
    }
}
