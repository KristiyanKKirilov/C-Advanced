using System;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList(); ;
            Dictionary<double, int> timesOccured = new ();

            foreach (double number in numbers)
            {
                if (!timesOccured.ContainsKey(number))
                {
                    timesOccured.Add(number, 0);
                }
                timesOccured[number]++;
            }
            foreach (var (key, value) in timesOccured)
            {
                Console.WriteLine($"{key} - {value} times");
            }

        }

    }
}