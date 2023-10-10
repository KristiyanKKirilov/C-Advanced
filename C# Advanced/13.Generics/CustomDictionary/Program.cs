using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomDictionary<int, int> custom = new CustomDictionary<int, int>();
            custom.Add(1, 2);
            custom.Add(2, 3);
            Console.WriteLine(custom[2]);
        }
    }
}
