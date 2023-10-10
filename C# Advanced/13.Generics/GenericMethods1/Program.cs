using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods1
{
    internal class Program
    {
        public void Main(string[] args)
        {
            string name = GenericMethod("hary");
            Console.WriteLine(name);
        }
        public T GenericMethod<T>(T input)
        {
            return input;
        }
    }
}
