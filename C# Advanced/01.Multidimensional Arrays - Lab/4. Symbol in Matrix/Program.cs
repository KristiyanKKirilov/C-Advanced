using System;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string symbols = Console.ReadLine();

                char[] chars = symbols.ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            char searchedSymbol = char.Parse(Console.ReadLine());
            bool isContained = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == searchedSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isContained = true;
                        break;
                    }                                
                }               
            }
            if (!isContained) 
            {
                Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
            }
        }
    }
}