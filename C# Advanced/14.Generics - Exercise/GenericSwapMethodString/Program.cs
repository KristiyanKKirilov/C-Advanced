using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> items= new ();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                items.Add(input);
            }
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(items, numbers[0], numbers[1]);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}"); 
            }
        }

        static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {            
            (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);           
        }

       
    }
}