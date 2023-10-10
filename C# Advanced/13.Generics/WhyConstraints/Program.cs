using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyConstraints
{
    public  class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1,6, 1, 0 ,9 , 2, 3, 4, 10, 7 };
            Sorter<int> sorter = new Sorter<int>();
            sorter.Sort(numbers);
        }
        
    }
    public class Sorter<T> where T : IComparable<T>
    {
        public T[] Sort(T[] array)
        {
            
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;

                for (int j = i; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) == -1)
                    {
                        minIndex = j;
                    }
                }
                T first = array[i];
                array[i] = array[minIndex];
                array[minIndex] = first;
            }
            return array;
        }
    }
}
