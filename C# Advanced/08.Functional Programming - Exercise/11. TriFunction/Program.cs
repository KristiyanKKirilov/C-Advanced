using System;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<string, int, bool> isEqualOrLarger = (name, n) =>
            {
                return Sum(name) >= n;
            };

            int numberToGet = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            foreach (var name in names)
            {
                if(isEqualOrLarger(name, numberToGet))
                {
                    Console.WriteLine(name);
                    break;
                }
                
            }
        }

        static int Sum(string name)
        {
            int sum = 0;
            foreach (char character in name)
            {
                sum += (int)character;
            }
            return sum;
        }
    }
}