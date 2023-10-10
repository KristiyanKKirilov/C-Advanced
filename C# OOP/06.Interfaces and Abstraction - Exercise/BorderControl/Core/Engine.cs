using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private List<IBuyer> buyers;
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            buyers = new();
            this.reader = reader;
            this.writer = writer;

        }
        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                IBuyer buyer;

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string date = tokens[3];
                    DateTime birthdate = DateTime.ParseExact(date, @"dd/MM/yyyy", CultureInfo.InvariantCulture);

                    buyer = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];
                    buyer = new Rebel(name, age, group);
                }
                buyers.Add(buyer);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == input);
                if (buyer is null)
                {
                    continue;
                }
                buyer.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));

        }
    }
}
