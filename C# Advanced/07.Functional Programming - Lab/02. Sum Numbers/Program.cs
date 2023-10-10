using System;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> count = CountNumbers;
            Func<int[], int> sum = SumNumbers;

            Console.WriteLine(count(numbers));
            Console.WriteLine(sum(numbers));
        }
               
        private static int CountNumbers(int[] numbers)
        {
            return numbers.Length;
        }

        private static int SumNumbers(int[] numbers)
        {
            return numbers.Sum();
        }
    }
}