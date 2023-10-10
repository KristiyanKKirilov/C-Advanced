using System;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new();
            HashSet<int> secondSet = new();
            HashSet<int> finalNumbers = new();
             int[] numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstSetLength = numbers[0];
            int secondSetLength = numbers[1];

            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            //foreach (var number in firstSet)
            //{
            //    if (secondSet.Contains(number))
            //    {
            //        finalNumbers.Add(number);                    
            //    }
            //}
            //Console.WriteLine(string.Join(" ", finalNumbers));
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet)); 

        }
    }
}