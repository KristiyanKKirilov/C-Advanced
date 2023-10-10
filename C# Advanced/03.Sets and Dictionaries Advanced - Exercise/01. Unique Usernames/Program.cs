using System;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }
            foreach (string item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}