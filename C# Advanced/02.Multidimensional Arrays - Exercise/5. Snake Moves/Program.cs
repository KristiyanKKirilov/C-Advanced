using System;
using System.Linq;
using System.Threading;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            string word = Console.ReadLine();
            int currentIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                
                if (row % 2 == 0)
                {                   
                    for (int col = 0; col < cols; col++)
                    {
                        if(currentIndex == word.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row, col] = word[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentIndex == word.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row, col] = word[currentIndex];
                        currentIndex++;
                    }
                }                
            }

            PrintMatrix(matrix);
            
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Thread.Sleep(200);
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}