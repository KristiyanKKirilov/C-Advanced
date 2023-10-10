using System;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = n => Min(n);

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(min(numbers));
        }
        static int Min(int[] numbers)
        {
            int minValue = int.MaxValue;

            foreach (var number in numbers)
            {
                if(number < minValue)
                {
                    minValue = number;
                }
            }

            return minValue;
        }

    }
}