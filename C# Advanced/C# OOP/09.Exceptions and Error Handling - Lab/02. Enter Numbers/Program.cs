using System;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 1;
            int max = 100;
            ReadNumbers(min, max);
        }
        static void ReadNumbers(int start, int end)
        {
            List<int> numbers = new();

            while (numbers.Count != 10)
            {
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int number))
                    {
                        throw new ArgumentException("Invalid Number!");

                    }
                    else if (number >= end || number <= start)
                    {
                        throw new ArgumentException($"Your number is not in range {start} - 100!");

                    }
                    numbers.Add(number);
                    start = number;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}