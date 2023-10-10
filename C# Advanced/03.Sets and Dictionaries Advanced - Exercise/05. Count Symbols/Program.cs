using System;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (!occurences.ContainsKey(symbol))
                {
                    occurences.Add(symbol, 0);
                }

                occurences[symbol]++;
            }

            foreach (var (symbol, count) in occurences)
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}