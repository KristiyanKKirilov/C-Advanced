using System;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];
            int firstSum = 0;
            int secondSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }


            for (int i = 0; i < n; i++)
            {
                firstSum += matrix[i, i];
                secondSum += matrix[n - i - 1, i];

            }
            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}