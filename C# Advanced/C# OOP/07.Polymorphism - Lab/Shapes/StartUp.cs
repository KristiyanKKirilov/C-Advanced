using Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Circle circle = new(3);
            Console.WriteLine($"{circle.CalculateArea():f2}");
            Console.WriteLine(circle.Draw());
            Rectangle rectangle = new(3, 4);
            Console.WriteLine($"{rectangle.CalculateArea():F2}");
            Console.WriteLine(rectangle.Draw());
        }
    }
}