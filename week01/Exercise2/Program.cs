using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for the grade percentage 
        Console.Write("What is your grade percentage?");
        string answer = Console.ReadLine();

        int x = int.Parse(answer);
        string letter = "";
        string sign = "";



        // Figure out the grade percentage 
        if (x >= 90)
        {
            letter = "A";
        }
        else if (x >= 80)
        {
            letter = "B";
        }
        else if (x >= 70)
        {
            letter = "C";
        }
        else if (x >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        int lastDigit = x % 10;

        //Determin the sign
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit <= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Handle exception cases (A+, F+, F-)
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }


        // Display the letter grade
        Console.WriteLine($" Your letter grade is {letter}{sign}");

        if (x >= 70)
        {
            Console.WriteLine($"Congradulations you have passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, Please try the course again!");
        }


    }
}