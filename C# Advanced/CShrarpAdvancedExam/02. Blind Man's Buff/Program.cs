using System;

namespace BlindMansBuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int columns = rowsCols[1];

            char[,] field = new char[rows, columns];

            int playerRow = 0;
            int playerCol = 0;  
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string command;
            int movesMade = 0;
            int opponentsTouched = 0;
            while ((command = Console.ReadLine()) != "Finish")
            {
                switch (command)
                {
                    case "left":
                        if (!IsNextPostionValid(field, playerRow, playerCol - 1))
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow, playerCol - 1] == '-')
                        {
                            movesMade++;
                            (field[playerRow, playerCol - 1], field[playerRow, playerCol]) = ('B', '-');
                            playerCol--;
                        }
                        else if (field[playerRow, playerCol - 1] == 'O')
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if(field[playerRow, playerCol - 1] == 'P')
                        {
                            movesMade++;
                            opponentsTouched++;
                            (field[playerRow, playerCol - 1], field[playerRow, playerCol]) = ('B', '-');
                            playerCol--;

                                                   
                        }
                        break;
                    case "right":
                        if (!IsNextPostionValid(field, playerRow, playerCol + 1))
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow, playerCol + 1] == '-')
                        {
                            movesMade++;
                            (field[playerRow, playerCol + 1], field[playerRow, playerCol]) = ('B', '-');
                            playerCol++;
                        }
                        else if (field[playerRow, playerCol + 1] == 'O')
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow, playerCol + 1] == 'P')
                        {
                            movesMade++;
                            opponentsTouched++;
                            (field[playerRow, playerCol + 1], field[playerRow, playerCol]) = ('B', '-');
                            playerCol++;

                                                    
                        }
                        break;
                    case "up":
                        if (!IsNextPostionValid(field, playerRow - 1, playerCol))
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow - 1, playerCol] == '-')
                        {
                            movesMade++;
                            (field[playerRow - 1, playerCol], field[playerRow, playerCol]) = ('B', '-');
                            playerRow--;
                        }
                        else if (field[playerRow - 1, playerCol] == 'O')
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow - 1, playerCol] == 'P')
                        {
                            movesMade++;
                            opponentsTouched++;
                            (field[playerRow - 1, playerCol], field[playerRow, playerCol]) = ('B', '-');
                            playerRow--;

                                                     
                        }
                        break;
                    case "down":
                        if (!IsNextPostionValid(field, playerRow + 1, playerCol))
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow + 1, playerCol] == '-')
                        {
                            movesMade++;
                            (field[playerRow + 1, playerCol], field[playerRow, playerCol]) = ('B', '-');
                            playerRow++;
                        }
                        else if (field[playerRow + 1, playerCol] == 'O')
                        {
                            field[playerRow, playerCol] = 'B';
                        }
                        else if (field[playerRow + 1, playerCol] == 'P')
                        {
                            movesMade++;
                            opponentsTouched++;
                            (field[playerRow + 1, playerCol], field[playerRow, playerCol]) = ('B', '-');
                            playerRow++;

                            
                        }
                        break;
                        

                }
                if (opponentsTouched == 3)
                {                    
                    break;
                }
            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {movesMade}");

        }
        static bool IsNextPostionValid(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
    }
}