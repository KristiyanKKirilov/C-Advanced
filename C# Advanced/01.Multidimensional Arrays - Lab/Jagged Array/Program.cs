using System;

namespace Jagged_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse) .ToArray();

            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if(jaggedArray[row][col] < 9)
                    {
                        Console.Write($" {jaggedArray[row][col]} ");
                    }
                    else
                    {
                        Console.Write($"{jaggedArray[row][col]} ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}