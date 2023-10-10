using System;

namespace Paramss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print("isa", "musa");
        }
        static void Print(params string[] names)
        {
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}