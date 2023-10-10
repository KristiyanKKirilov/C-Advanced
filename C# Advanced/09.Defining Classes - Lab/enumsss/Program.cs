using System;
using System.Security.Cryptography;

namespace enumsss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directions.left);
            Console.WriteLine((int)Directions.left);
            Console.WriteLine((Directions)43);
            foreach (var item in Enum.GetValues(typeof (Directions)))
            {
                Console.WriteLine(item);
            }
            
        }
         
    }
}