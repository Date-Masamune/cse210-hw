using System;

class Program
{
    static void Main()
    {
        string keepPlaying = "yes";

        while (keepPlaying.ToLower() == "yes")
        {
            Random rng = new Random();
            int magicNumber = rng.Next(1, 101); // 1..100 inclusive
            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Please enter a whole number.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber) Console.WriteLine("Higher");
                else if (guess > magicNumber) Console.WriteLine("Lower");
                else Console.WriteLine("You guessed it!");
            }

            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.Write("Do you want to continue? ");
            keepPlaying = Console.ReadLine();
        }
    }
}
