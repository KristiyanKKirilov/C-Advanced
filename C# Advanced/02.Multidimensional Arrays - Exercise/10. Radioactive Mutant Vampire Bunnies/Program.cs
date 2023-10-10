using System;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] playground = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    playground[row, col] = data[col];

                    if (data[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        playground[playerRow, playerCol] = '.';
                    }
                }
            }

            string directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                int playerOldRow = playerRow;
                int playerOldCol = playerCol;

                switch (direction)
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;

                }
                playground = SpreadBunnies(rows, cols, playground);
               

                if (playerRow < 0 || playerRow >= rows
                     || playerCol < 0 || playerCol >= cols)
                {
                    PrintMatrix(playground);
                    Console.WriteLine($"won: {playerOldRow} {playerOldCol}");
                    break;
                }

                if (playground[playerRow, playerCol] == 'B')
                {
                    PrintMatrix(playground);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }

            }
        }

        static char[,] SpreadBunnies(int rows, int cols, char[,] playground)
        {
            char[,] newPlayground = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newPlayground[row, col] = playground[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (playground[row, col] == 'B')
                    {
                        if (row > 0)//up 
                        {
                            newPlayground[row - 1, col] = 'B';
                        }
                        if (row < rows - 1)//down
                        {
                            newPlayground[row + 1, col] = 'B';
                        }
                        if (col > 0)//left
                        {
                            newPlayground[row, col - 1] = 'B';
                        }
                        if (col < cols - 1)//right
                        {
                            newPlayground[row, col + 1] = 'B';
                        }
                    }
                }
            }
            return newPlayground;
        }
        static void PrintMatrix(char[,] playground)
        {

            for (int row = 0; row < playground.GetLength(0); row++)
            {
                for (int col = 0; col < playground.GetLength(1); col++)
                { 
                    Console.Write(playground[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}