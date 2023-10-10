using System;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<int>, List<string>> split = (names, condition) =>
            {
                List<string> lastedNames = new List<string>();

                foreach (var name in names)
                {
                    if (condition(name.Length))
                    {
                        lastedNames.Add(name);
                    }
                }
                return lastedNames;
            };

            int condition = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names = split(names, nameLength => nameLength <= condition);

            Console.WriteLine(string.Join(Environment.NewLine, names));
                
        }
    }
}