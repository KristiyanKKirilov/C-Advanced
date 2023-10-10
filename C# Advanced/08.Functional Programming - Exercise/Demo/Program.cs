using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[], Predicate<string>> calculate = (names, match) =>
            {
                
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
                
            };
            int condition = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);                
               

            calculate(names, n => n.Length <= condition);
            

        }
    }

}