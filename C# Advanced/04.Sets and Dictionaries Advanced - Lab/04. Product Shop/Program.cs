using System;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while ((command = Console.ReadLine())!= "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = input[0];
                string commodity = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                if (!shops[shop].ContainsKey(commodity))
                {
                    shops[shop].Add(commodity, price);
                }
                shops[shop][commodity] = price;
            }
            foreach (var(shop, commodities) in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop}->");

                foreach (var (commodity, price) in commodities)
                {
                    Console.WriteLine($"Product: {commodity}, Price: {price}");
                }
            }
        }
    }
}