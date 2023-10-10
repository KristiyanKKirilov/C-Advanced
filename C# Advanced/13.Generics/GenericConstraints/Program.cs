using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConstraints
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            CompareTwoElements(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        }
        static void CompareTwoElements<T>(T firstElement, T secondElement) where T : IComparable<T>
        {
            if (firstElement.CompareTo(secondElement) < 0)
            {
                ShowResult(firstElement, secondElement);
                Console.WriteLine("Second is bigger");
            }
            else if (firstElement.CompareTo(secondElement) == 0)
            {
                ShowResult(firstElement, secondElement);
                Console.WriteLine("Equal");
            }
            else
            {
                ShowResult(firstElement, secondElement);
                Console.WriteLine("First is bigger");
            }

        }
        static void ShowResult<T>(T firstElement, T secondElement) where T : IComparable<T>
        {
            int result = firstElement.CompareTo(secondElement);
            Console.WriteLine(result);
        }
    }
}
