using System;

namespace Factorial_recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(10, 0));

        }
        static int Factorial(int n, int depth)
        {
            Console.WriteLine($"{new string(' ', depth * 3)}Calculating: {n}!");
            if(n == 1)
            {
                return 1;
            }
            int minusOne = Factorial(n - 1, depth + 1);
            Console.WriteLine($"{new string(' ', depth * 3)}{n} * {n-1}! = {n*minusOne}");
            return n * minusOne;
        }
    }
}