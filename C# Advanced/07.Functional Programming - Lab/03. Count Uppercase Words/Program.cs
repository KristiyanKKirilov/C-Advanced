using System;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sentences = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)                
                .ToList();                        

            foreach (var word in sentences)
            {
                Predicate<string> func = StartsWithUpper;

                if (func(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
        static bool StartsWithUpper(string word)
        {
            bool isTrue = word[0] >= 65 && word[0] <= 90;
            return isTrue;
        }
    }

}
