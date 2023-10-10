using System; 

namespace _01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            try
            {
                IsInvalid(num);
                Console.WriteLine(Math.Sqrt(num));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
        public static void IsInvalid(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
        }
    }
}