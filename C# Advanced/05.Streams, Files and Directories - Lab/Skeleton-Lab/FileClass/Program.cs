using System;

namespace FileClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"me", "you", "he" };

            File.WriteAllLines("../../../text.txt", names);
        }
    }
}