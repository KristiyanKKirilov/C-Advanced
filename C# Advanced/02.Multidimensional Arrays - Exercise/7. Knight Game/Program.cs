using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[size, size];

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            for (int row = 0; row < size; row++)
            {
                string figures = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    chessBoard[row, col] = figures[col];
                }
            }
            int knightsRemoved = 0;

            while (true)
            {
                int mostAttacking = 0;
                int rowAtMaxAttacked = 0;
                int colAtMaxAttacked = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (chessBoard[row, col] == 'K')
                        {
                            int currentAttacking = CountAttackedKnights(row, col, size, chessBoard);

                            if (mostAttacking < currentAttacking)
                            {
                                mostAttacking = currentAttacking;
                                rowAtMaxAttacked = row;
                                colAtMaxAttacked = col;
                            }
                        }
                    }
                }

                if (mostAttacking == 0)
                {
                    break;
                }
                else
                {
                    chessBoard[rowAtMaxAttacked, colAtMaxAttacked] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);

        }
        static int CountAttackedKnights(int row, int col, int size, char[,] chessBoard)
        {
            int attackedKnights = 0;
            //up and left
            if (isValid(row - 2, col - 1, size))
            {
                if (chessBoard[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //up and right
            if (isValid(row - 2, col + 1, size))
            {
                if (chessBoard[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //left and up
            if (isValid(row - 1, col - 2, size))
            {
                if (chessBoard[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //left and down
            if (isValid(row + 1, col - 2, size))
            {
                if (chessBoard[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //down and left
            if (isValid(row + 2, col - 1, size))
            {
                if (chessBoard[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //down and right
            if (isValid(row + 2, col + 1, size))
            {
                if (chessBoard[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }
            //right and up
            if (isValid(row - 1, col + 2, size))
            {
                if (chessBoard[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            //right and down
            if (isValid(row + 1, col + 2, size))
            {
                if (chessBoard[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }
        static bool isValid(int row, int col, int size)
        {
            return
                row >= 0
                && row < size
                && col >= 0
                && col < size;
        }
    }
}