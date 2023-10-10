using System;

namespace RecuriveSumOfArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] items = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(SumOfElements(items, 0)); 
        }
        static int SumOfElements(int[] elements, int index)
        {
            int sum = 0;
            if(index == elements.Length - 1)
            {
                return elements[index];
            }
            int indexPlus1 = SumOfElements(elements, index + 1);
            return elements[index] + indexPlus1;
        }
    }
}