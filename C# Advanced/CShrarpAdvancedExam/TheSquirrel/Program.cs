namespace TheSquirrel
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int[,] field = new int[size, size];

            int squirrelRow = 0;
            int squirrelCol = 0;
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }
                }
            }
            int hazelnuts = 0;

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        if (!isValid(field, squirrelRow, squirrelCol - 1))
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow, squirrelCol - 1] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow, squirrelCol - 1] == 'h')
                        {
                            hazelnuts++;
                        }

                        (field[squirrelRow, squirrelCol - 1], field[squirrelRow, squirrelCol]) = ('s', '*');
                        squirrelCol--;

                        break;
                    case "right":
                        if (!isValid(field, squirrelRow, squirrelCol + 1))
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow, squirrelCol + 1] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow, squirrelCol + 1] == 'h')
                        {
                            hazelnuts++;
                        }

                        (field[squirrelRow, squirrelCol + 1], field[squirrelRow, squirrelCol]) = ('s', '*');
                        squirrelCol++;

                        break;
                    case "up":
                        if (!isValid(field, squirrelRow - 1, squirrelCol))
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow - 1, squirrelCol] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow - 1, squirrelCol] == 'h')
                        {
                            hazelnuts++;
                        }

                        (field[squirrelRow - 1, squirrelCol], field[squirrelRow, squirrelCol]) = ('s', '*');
                        squirrelRow--;

                        break;
                    case "down":
                        if (!isValid(field, squirrelRow + 1, squirrelCol))
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow + 1, squirrelCol] == 't')
                        {
                            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                            Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
                            Environment.Exit(0);
                        }
                        else if (field[squirrelRow + 1, squirrelCol] == 'h')
                        {
                            hazelnuts++;
                        }

                        (field[squirrelRow + 1, squirrelCol], field[squirrelRow, squirrelCol]) = ('s', '*');
                        squirrelRow++;

                        break;
                }
            }
            if(hazelnuts >= 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
            }
            else
            {
                Console.WriteLine("There are more hazelnuts to collect.");
                Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
            }
        }

        private static bool isValid(int[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }
    }
}