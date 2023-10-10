using System;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> sortedElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //for (int j = 0; j < elements.Length; j++)
                //{
                //    sortedElements.Add(elements[j]);
                //}
                sortedElements.UnionWith(elements);
            }

            Console.WriteLine(string.Join(' ', sortedElements));

        }
    }
}