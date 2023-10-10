using System;

namespace _6.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandInfo = command[0];
                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                bool isValid = true;

                if (row >= jaggedArray.Length || row < 0)
                {
                    isValid = false;
                }
                else
                {
                    if (column >= jaggedArray[row].Length || column < 0)
                    {
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (commandInfo == "add")
                    {
                        jaggedArray[row][column] += value;
                    }
                    else if (commandInfo == "subtract")
                    {
                        jaggedArray[row][column] -= value;
                    }

                }
                 input = Console.ReadLine().ToLower();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    
                    
                        Console.Write($"{jaggedArray[row][col]} ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}