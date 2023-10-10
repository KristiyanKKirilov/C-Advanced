using System;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] drinkTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] numberTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomTuple<string, string> nameAdresss = new($"{nameTokens[0]} {nameTokens[1]}", nameTokens[2]);
            CustomTuple<string, int> drinking = new(drinkTokens[0], int.Parse(drinkTokens[1]));
            CustomTuple<int, double> numbers = new(int.Parse(numberTokens[0]), double.Parse(numberTokens[1]));

            Console.WriteLine(nameAdresss.ToString());
            Console.WriteLine(drinking.ToString());
            Console.WriteLine(numbers.ToString());
        }
    }
}