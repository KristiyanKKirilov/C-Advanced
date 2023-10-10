using System;

namespace Delegators
{
    internal class Program
    {
        public delegate int NewDelegator(double a, int b);
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            NewDelegator multiply = (a, b) => (int)a * b;
            NewDelegator sum = (a, b) => (int)a + b;


            Console.WriteLine(multiply(a, b));
            Console.WriteLine(sum(a, b));
        }
    }
}