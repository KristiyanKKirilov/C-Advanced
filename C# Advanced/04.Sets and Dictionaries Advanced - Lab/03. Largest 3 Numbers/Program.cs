using System;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();  
            numbers = numbers.OrderByDescending(x=>x).ToList();

            if(numbers.Count < 3) 
            {
                Console.WriteLine(string.Join(" ", numbers));
                
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
                        
        }
    }
}