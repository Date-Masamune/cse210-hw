using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        var numbers = new List<int>();
        int sum = 0;
        int? largest = null;

        while (true)
        {
            Console.Write("Enter number: ");
            string line = Console.ReadLine();

            if (!int.TryParse(line, out int n))
            {
                Console.WriteLine("Please enter a whole number.");
                continue;
            }

            if (n == 0) break;

            numbers.Add(n);
            sum += n;
            if (largest == null || n > largest) largest = n;
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}
