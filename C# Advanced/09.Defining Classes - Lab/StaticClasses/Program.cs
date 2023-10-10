using System;

namespace StaticClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter.Color = ConsoleColor.Green;
            ConsolePrinter.WriteLine("Hello, World!");
            
        }
    }
}