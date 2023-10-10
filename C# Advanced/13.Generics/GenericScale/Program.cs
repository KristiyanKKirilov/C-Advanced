using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EqualityScale<int> numbers = new EqualityScale<int>(7, 5);
            Console.WriteLine(numbers.AreEqual()); 

        }
    }
}
