using System;

namespace _04._Add_VAT
{
    internal class Program

    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Func<List<double>, List<double>> vatPrices = PriceWithVat;

            foreach (double vatPrice in vatPrices(prices))
            {
                Console.WriteLine($"{vatPrice:f2}");
            }
            
        }

        static List<double> PriceWithVat(List<double> prices)
        {
            List<double> vatPrices = new List<double>();

            foreach (var price in prices)
            {
                vatPrices.Add(price * 1.2);
            }

            return vatPrices;
        }
    }
}