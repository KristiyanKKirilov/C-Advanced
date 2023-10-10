using System;

namespace _02._Delivery_Boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            char[,] field = new char[rows, cols];
            bool isOut = false;
            bool isDelivered = false;
            int isCollected = 0;

            int deliveryBoyRow = 0;
            int deliveryBoyCol = 0;
            int firstPositionRow = 0;
            int firstPositionCol = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'B')
                    {
                        deliveryBoyRow = row;
                        deliveryBoyCol = col;
                        firstPositionRow = row;
                        firstPositionCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                isCollected = 0;
                switch (command)
                {

                    case "left":
                        if (!IsInMap(field, deliveryBoyRow, deliveryBoyCol - 1))
                        {
                            isOut = true;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol - 1] == 'A')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('P', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('P', '.');
                            }
                            isDelivered = true;
                            deliveryBoyCol--;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol - 1] == '*')
                        {
                            field[deliveryBoyRow, deliveryBoyCol] = 'B';
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol - 1] == 'P')
                        {
                            (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('R', '.');
                            isCollected++;
                            deliveryBoyCol--;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol - 1] == '-')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('B', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('B', '.');
                            }
                            deliveryBoyCol--;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol - 1] == '.')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('B', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow, deliveryBoyCol - 1], field[deliveryBoyRow, deliveryBoyCol]) = ('B', '.');
                            }
                            deliveryBoyCol--;
                        }

                        break;
                    case "right":
                        if (!IsInMap(field, deliveryBoyRow, deliveryBoyCol + 1))
                        {
                            isOut = true;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol + 1] == 'A')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('P', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('P', '.');
                            }
                            isDelivered = true;
                            deliveryBoyCol++;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol + 1] == '*')
                        {

                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol + 1] == 'P')
                        {
                            (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('R', '.');
                            isCollected++;
                            deliveryBoyCol++;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol + 1] == '-')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('.', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('.', '.');
                            }
                            deliveryBoyCol++;
                        }
                        else if (field[deliveryBoyRow, deliveryBoyCol + 1] == '.')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('.', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow, deliveryBoyCol + 1], field[deliveryBoyRow, deliveryBoyCol]) = ('.', '.');
                            }
                            deliveryBoyCol++;
                        }
                        break;
                    case "up":
                        if (!IsInMap(field, deliveryBoyRow - 1, deliveryBoyCol))
                        {
                            isOut = true;
                        }
                        else if (field[deliveryBoyRow - 1, deliveryBoyCol] == 'A')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow - 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('P', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow - 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('P', '.');
                            }
                            isDelivered = true;
                            deliveryBoyRow--;
                        }
                        else if (field[deliveryBoyRow - 1, deliveryBoyCol] == '*')
                        {

                        }
                        else if (field[deliveryBoyRow - 1, deliveryBoyCol] == 'P')
                        {
                            (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('R', '.');
                            isCollected++;
                            deliveryBoyRow--;
                        }
                        else if (field[deliveryBoyRow - 1, deliveryBoyCol] == '-')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow - 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow - 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', '.');
                            }
                            deliveryBoyRow--;
                        }
                        else if (field[deliveryBoyRow - 1, deliveryBoyCol] == '.')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow - 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow - 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', '.');
                            }
                            deliveryBoyRow--;
                        }
                        break;
                    case "down":
                        if (!IsInMap(field, deliveryBoyRow + 1, deliveryBoyCol))
                        {
                            isOut = true;
                        }
                        else if (field[deliveryBoyRow + 1, deliveryBoyCol] == 'A')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('P', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('P', '.');
                            }
                            isDelivered = true;
                            deliveryBoyRow++;
                        }
                        else if (field[deliveryBoyRow + 1, deliveryBoyCol] == '*')
                        {

                        }
                        else if (field[deliveryBoyRow + 1, deliveryBoyCol] == 'P')
                        {
                            (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('R', '.');
                            isCollected++;
                            deliveryBoyRow++;
                        }
                        else if (field[deliveryBoyRow + 1, deliveryBoyCol] == '-')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', '.');
                            }
                            deliveryBoyRow++;
                        }
                        else if (field[deliveryBoyRow + 1, deliveryBoyCol] == '.')
                        {
                            if (field[deliveryBoyRow, deliveryBoyCol] == 'R')
                            {
                                (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', 'R');
                            }
                            else
                            {
                                (field[deliveryBoyRow + 1, deliveryBoyCol], field[deliveryBoyRow, deliveryBoyCol]) = ('.', '.');
                            }
                            deliveryBoyRow++;
                        }
                        break;
                }
                if (isOut)
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    break;
                }
                else if (isDelivered)
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                else if (isCollected == 1)
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
            }
            Print(field, firstPositionRow, firstPositionCol, isOut);

        }
        static bool IsInMap(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }

        static void Print(char[,] field, int firstPositionRow, int firstPositionCol, bool isOut)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {

                    if (row == firstPositionRow && col == firstPositionCol)
                    {
                        if (isOut)
                        {
                            field[row, col] = ' ';
                        }
                        else
                        {
                            field[row, col] = 'B';
                        }                       
                    }
                    if (field[row, col] == ' ')
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write($"{field[row, col]} ".TrimEnd());
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}