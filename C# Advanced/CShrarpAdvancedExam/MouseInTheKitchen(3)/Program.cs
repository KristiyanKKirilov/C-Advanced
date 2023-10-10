using System;

namespace MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            char[,] field = new char[rows, cols];

            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseExisting = 0;
            bool isTrapped = false;
            bool isOut = false;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }
                    if (field[row, col] == 'C')
                    {
                        cheeseExisting++;
                    }
                }
            }
            string command;
            int cheeseEaten = 0;
            while ((command = Console.ReadLine()) != "danger")
            {
                switch (command)
                {
                    case "left":
                        if (!IsNextPostionValid(field, mouseRow, mouseCol - 1))
                        {
                            field[mouseRow, mouseCol] = 'M';
                            isOut = true;
                        }
                        else if (field[mouseRow, mouseCol - 1] == '*')
                        {
                            (field[mouseRow, mouseCol - 1], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseCol--;
                        }
                        else if (field[mouseRow, mouseCol - 1] == '@')
                        {
                            field[mouseRow, mouseCol] = 'M';
                        }
                        else if (field[mouseRow, mouseCol - 1] == 'T')
                        {
                            (field[mouseRow, mouseCol - 1], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseCol--;
                            isTrapped = true;
                        }
                        else if (field[mouseRow, mouseCol - 1] == 'C')
                        {
                            (field[mouseRow, mouseCol - 1], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseCol--;
                            cheeseEaten++;
                        }
                        break;
                    case "right":
                        if (!IsNextPostionValid(field, mouseRow, mouseCol + 1))
                        {
                            field[mouseRow, mouseCol] = 'M';
                            isOut = true;
                        }
                        else if (field[mouseRow, mouseCol + 1] == '*')
                        {
                            (field[mouseRow, mouseCol + 1], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseCol++;
                        }
                        else if (field[mouseRow, mouseCol + 1] == '@')
                        {
                            field[mouseRow, mouseCol] = 'M';
                        }
                        else if (field[mouseRow, mouseCol + 1] == 'T')
                        {
                            (field[mouseRow, mouseCol + 1], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseCol++;
                            isTrapped = true;
                        }
                        else if (field[mouseRow, mouseCol - 1] == 'C')
                        {
                            (field[mouseRow, mouseCol + 1], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseCol++;
                            cheeseEaten++;
                        }
                        break;
                    case "up":
                        if (!IsNextPostionValid(field, mouseRow - 1, mouseCol))
                        {
                            field[mouseRow, mouseCol] = 'M';
                            isOut = true;
                        }
                        else if (field[mouseRow - 1, mouseCol] == '*')
                        {
                            (field[mouseRow - 1, mouseCol], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseRow--;
                        }
                        else if (field[mouseRow - 1, mouseCol] == '@')
                        {
                            field[mouseRow, mouseCol] = 'M';
                        }
                        else if (field[mouseRow - 1, mouseCol] == 'T')
                        {
                            (field[mouseRow - 1, mouseCol], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseRow--;
                            isTrapped = true;
                        }
                        else if (field[mouseRow - 1, mouseCol] == 'C')
                        {
                            (field[mouseRow - 1, mouseCol], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseRow--;
                            cheeseEaten++;
                        }
                        break;
                    case "down":
                        if (!IsNextPostionValid(field, mouseRow + 1, mouseCol))
                        {
                            field[mouseRow, mouseCol] = 'M';
                            isOut = true;
                        }
                        else if (field[mouseRow + 1, mouseCol] == '*')
                        {
                            (field[mouseRow + 1, mouseCol], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseRow++;
                        }
                        else if (field[mouseRow + 1, mouseCol] == '@')
                        {
                            field[mouseRow, mouseCol] = 'M';
                        }
                        else if (field[mouseRow + 1, mouseCol] == 'T')
                        {
                            (field[mouseRow + 1, mouseCol], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseRow++;
                            isTrapped = true;
                        }
                        else if (field[mouseRow + 1, mouseCol] == 'C')
                        {
                            (field[mouseRow + 1, mouseCol], field[mouseRow, mouseCol]) = ('M', '*');
                            mouseRow++;
                            cheeseEaten++;
                        }
                        break;


                }
                if (cheeseEaten == cheeseExisting)
                {
                    break;
                }
                if (isTrapped)
                {
                    break;
                }
                if (isOut)
                {
                    break;
                }
            }
            if (cheeseEaten == cheeseExisting)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");

            }
            else if (isTrapped)
            {
                Console.WriteLine("Mouse is trapped!");
                
            }
            else if (isOut)
            {
                Console.WriteLine("No more cheese for tonight!");                
            }
            else if (cheeseEaten < cheeseExisting)
            {
                Console.WriteLine("Mouse will come back later!");
            }
            PrintMatrix(field);

        }
        static bool IsNextPostionValid(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
        static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]} ".TrimEnd());
                }
                Console.WriteLine();
            }
        }
    }
}

