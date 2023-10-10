using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = ArrayCreator.Create(5, 6);
            int[] numbers1 =  ArrayCreator.Create(3, 4);
            
           
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(string.Join(" ", numbers1));

        }
    }
}
