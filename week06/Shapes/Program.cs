using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual shapes
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square Color: {square.GetColor()}");
        Console.WriteLine($"Square Area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}");
        Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");

        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle Color: {circle.GetColor()}");
        Console.WriteLine($"Circle Area: {circle.GetArea()}");

        Console.WriteLine("\n--- Polymorphism Example ---");

        // Create a list of shapes
        List<Shape> shapes = new List<Shape>
        {
            new Square("Yellow", 2.5),
            new Rectangle("Purple", 3, 7),
            new Circle("Orange", 4)
        };

        // Iterate using polymorphism
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} shape area: {shape.GetArea():F2}");
        }
    }
}
