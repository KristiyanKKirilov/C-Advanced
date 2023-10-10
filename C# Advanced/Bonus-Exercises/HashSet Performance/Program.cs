using System;
using System.Diagnostics;

namespace HashSet_Performance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HashsetFunctions set = new HashsetFunctions();

            
            
            int n = 50_000;
            int operations = 50_000;

            ListPerformance(n, operations);
            //ListPerformanceDelete(n, operations);
            HashSetPerformance(n, operations);
            //HashSetPerformanceDelete(n, operations);
            HashSetPerformanceMine(n, operations);
        }
        static void ListPerformance(int n, int operations)
        {
            //List<int> list = new List<int>(Enumerable.Range(0, n));
            List<string> list = new List<string>(Enumerable.Range(0, n).Select(x=>x.ToString()));

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < operations; i++)
            {
                list.Contains(i.ToString());
            }
            Console.WriteLine($"List time needed: {watch.ElapsedMilliseconds}ms");
        }
        static void HashSetPerformance(int n, int operations)
        {
            HashSet<string> set = new HashSet<string>(Enumerable.Range(0, n).Select(x=>x.ToString()));

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < operations; i++)
            {
                set.Contains(i.ToString());
            }
            Console.WriteLine($"Hashset time needed: {watch.ElapsedMilliseconds}ms");
        }
        static void HashSetPerformanceMine(int n, int operations)
        {
            HashsetFunctions set = new HashsetFunctions (Enumerable.Range(0, n).Select(x => x.ToString()));

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < operations; i++)
            {
                set.Contains(i.ToString());
            }
            Console.WriteLine($"Mine Hashset time needed: {watch.ElapsedMilliseconds}ms");
        }
        static void HashSetPerformanceDelete(int n, int operations)
        {
            HashSet<int> set = new HashSet<int>(Enumerable.Range(0, n));

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < operations; i++)
            {
                set.Remove(i);
            }
            Console.WriteLine($"Hashset time needed to remove: {watch.ElapsedMilliseconds}ms");
        }
        static void ListPerformanceDelete(int n, int operations)
        {
            List<int> list = new List<int>(Enumerable.Range(0, n));

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < operations; i++)
            {
                list.Remove(i);
            }
            Console.WriteLine($"List time needed to remove: {watch.ElapsedMilliseconds}ms");
        }
    }
    public class HashsetFunctions
    {
        private List<string>[] array;
        private float capacity = 0;
        public HashsetFunctions(int capacity = 8)
        {
            array = new List<string>[capacity];
        }
        public HashsetFunctions(IEnumerable<string> initial)
        {
            array = new List<string>[initial.Count()];

            foreach (var item in initial)
            {
                Add(item);
            }
        }

        public void Add(string element)
        {
            int index = HashFunction(element);

            if (array[index] == null)
            {
                array[index] = new List<string>();
            }

            array[index].Add(element);
            capacity++;

            if (capacity / array.Length > 0.60)
            {
                //Console.WriteLine($"Capacity is {capacity / array.Length} resizing");
                Resize();
            }

        }

        private void Resize()
        {
            capacity = 0;
            List<string>[] oldArray = array;
            array = new List<string>[array.Length * 2];

            foreach (var list in oldArray)
            {
                if (list == null)
                {
                    continue;
                }
                foreach (var item in list)
                {
                    Add(item);
                }
            }
        }

        public bool Contains(string element)
        {
            int index = HashFunction(element);

            if (array[index] == null)
            {
                return false;
            }

            return array[index].Contains(element);
        }

        private int HashFunction(string element)
        {
            //int sum = 0;

            //for (int i = 0; i < element.Length; i++)
            //{
            //    sum += element[i];
            //}
            return Math.Abs(element.GetHashCode()) % array.Length;
        }
    }
}