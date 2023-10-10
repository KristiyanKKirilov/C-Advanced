using System;

namespace Func
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Aggregate(1, 10, (x, y) => x + y));
            int[] array = Enumerable.Range(0, 20).ToArray();

            Select(array, n => n + 1);
            Select(array, n => n / 2);

        }

        static long Aggregate(long start, long end, Func<long, long, long> op)
        {
            long result = start;

            for (long i = start + 1; i <= end; i++)
            {
                result = op(result, i);
            }

            return result;
        }

        static int[] Select(int[] arr, Func<int, int> operation)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = operation(arr[i]);
            }

            return arr;
        }
        
    }
}