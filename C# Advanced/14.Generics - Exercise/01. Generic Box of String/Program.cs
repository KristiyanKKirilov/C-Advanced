using System;
using BoxOfInteger;

namespace BoxOfInteger;

internal class Program
{
    static void Main(string[] args)
    {
        Box<int> box = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());
            box.Add(input);

        }
        Console.WriteLine(box.ToString()); 
    }
}