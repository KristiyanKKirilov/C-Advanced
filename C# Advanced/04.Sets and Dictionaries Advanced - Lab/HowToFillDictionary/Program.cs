using System;

namespace How_To_Fill_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> countryInfo = new Dictionary<string, Dictionary<string, int>>
            {
                { "BG",
                    new Dictionary<string, int>
                    {
                        { "Sofia", 1_213_212 },
                        { "Varna", 213_212 },
                        { "Rousse", 111_212 },
                    }
                },
                {"UK",
                    new Dictionary<string, int>
                    {
                        {"London", 3_212_211 },
                        { "Manchester", 1_213_212 },
                    }

                },

            };
            foreach (var (country, towns) in countryInfo)
            {
                Console.WriteLine($"Country: {country}");
                foreach (var (townName, population) in towns)
                {
                    Console.WriteLine($"Town {townName} -> Population {population}");
                }
            }

        }
    }
}