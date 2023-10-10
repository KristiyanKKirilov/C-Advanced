using System;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 4, 5, 12, 54, 56, 67 };
            int index = list.IndexOf(12);
            Console.WriteLine(index);
            Console.WriteLine();
            int newIndex = BinarySearch(list, 54, 0, list.Count);
            Console.WriteLine(newIndex);
        }
        static int BinarySearch(List<int> list, int number, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            if((start+ end) / 2 == list.Count)
            {
                return -1;
            }

            int middle = (start + end) / 2;
            if (list[middle] == number)
            {
                return middle;
            }
            if (list[middle] > number)
            {
                return BinarySearch(list, number, start, middle - 1);
            }
            else 
            {
                return BinarySearch(list, number, middle + 1, end);
            }
            
        }
    }
}