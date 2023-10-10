using System;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, List<int>> listRange = (start, end) =>
            {
                List<int> numbers = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    numbers.Add(i);
                }
                return numbers;
            };

            int[] ranges = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string filterType = Console.ReadLine();            

            Func<string, int, bool> evenOrOdd = (condition, number) =>
            {
                switch (condition)
                {
                    case "even": return number % 2 == 0;
                    case "odd": return number % 2 != 0;
                    default:
                        return true;
                }
            };
            List<int> numbers = listRange(ranges[0], ranges[1]);

            foreach (var number in numbers)
            {
                if(evenOrOdd(filterType, number))
                {
                    Console.Write($"{number} ");
                }
            }
                     
        }

       

    }
}