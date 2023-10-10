using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    public static class ConsolePrinter
    {
        public static ConsoleColor Color { get; set; }

        static ConsolePrinter()
        {
            Color = ConsoleColor.Blue;
        }
        public static void WriteLine(string text)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
