using System;

namespace Experimenting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cols = 0;

            while (true)
            {
                Console.SetCursorPosition(20 + cols, 5);
                Console.WriteLine('K');
                Console.SetCursorPosition(20 + cols, 6);
                Console.WriteLine('I');
                Console.SetCursorPosition(20 + cols, 7);
                Console.WriteLine('K');
                Console.SetCursorPosition(20 + cols, 8);
                Console.WriteLine('O');
                Thread.Sleep(150);
                Console.Clear();
                cols++;
            }
        }
    }
}