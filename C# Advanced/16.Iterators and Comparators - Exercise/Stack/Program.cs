using System;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                char[] separators = new char[] { ' ', ',' };
                string[] tokens = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                switch (command)
                {
                    case "Push":
                        int[] items = tokens.Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        stack.Push(items);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

        }
    }
}