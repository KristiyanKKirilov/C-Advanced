using System;
using System.Collections;

namespace YieldReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IEnumerator<int> enumerator = Generate5Numers();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
            NumbersEnumerable nums = new NumbersEnumerable();
            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }
        }

        //static IEnumerator<int> Generate5Numers()
        //{
        //    yield return 5;
        //    Console.WriteLine('-');
        //    yield return 6;
        //    Console.WriteLine('-');
        //    yield return 7;
        //    Console.WriteLine('-');
        //    yield return 8;
        //    Console.WriteLine('-');
        //    yield return 9;
        //    Console.WriteLine('-');
        //    yield return 10;
        //}
    }
    class NumbersEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            Random random = new();
            for (int i = 0; i < 10; i++)
            {
                yield return random.Next();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}