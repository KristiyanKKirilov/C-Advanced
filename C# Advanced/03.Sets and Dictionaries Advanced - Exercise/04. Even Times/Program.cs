using System;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            
            for (int i = 0; i < n; i++)
            {

                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);

                }
                numbers[number]++; 

            }

            Console.WriteLine(numbers.Single(x=>x.Value % 2 == 0).Key);

        }
    }
}