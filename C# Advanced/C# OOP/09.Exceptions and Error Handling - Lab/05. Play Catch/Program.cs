using System;
using System.Security;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int countOfExceptions = 0;

            while(countOfExceptions < 3)
            {
                string[] currentInput = Console.ReadLine().Split();
                string command = currentInput[0];
                try
                {
                    switch (command)
                    {
                        case "Replace":
                            int firstIndex = int.Parse(currentInput[1]);
                            int secondIndex = int.Parse(currentInput[2]);
                            numbers[firstIndex] = secondIndex;

                            break;                        
                        case "Print":
                            int startIndex = int.Parse(currentInput[1]);
                            int endIndex = int.Parse(currentInput[2]);
                            List<int> print = new();
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                print.Add(numbers[i]);
                            }
                            Console.WriteLine(string.Join(", ", print).TrimEnd());
                            break;
                        case "Show":
                            int index = int.Parse(currentInput[1]);
                            Console.WriteLine(numbers[index]);
                            break;

                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("The index does not exist!");
                    countOfExceptions++;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    countOfExceptions++;
                }

            }
            Console.WriteLine(string.Join(", ", numbers).TrimEnd());
        }
    }
}