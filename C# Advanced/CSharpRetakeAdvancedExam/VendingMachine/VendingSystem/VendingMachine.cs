using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
		private int buttonCapacity;
		private List<Drink> drinks;
        public VendingMachine(int buttonCapacity)
        {           
            ButtonCapacity = buttonCapacity;
            Drinks = new();
        }

		public int ButtonCapacity
        {
			get { return buttonCapacity; }
			set { buttonCapacity = value; }
		}
        public List<Drink> Drinks
        {
            get { return drinks; }
            set { drinks = value; }
        }
        public int GetCount { get => Count(); }

        private int Count()
        {
            if(Drinks.Count == 0)
            {
                return 0;
            }
            return Drinks.Count;
        }
        public void AddDrink(Drink drink)
        {
            if(ButtonCapacity > Drinks.Count)
            {
                Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name)
        {
            Drink drink = Drinks.FirstOrDefault(d => d.Name == name);
            if(drink is null)
            {
                return false;
            }
            Drinks.Remove(drink);

            return true;    
        }
        public Drink GetLongest()
        {
            int maxVolume = int.MinValue;
            foreach (var currentDrink in Drinks)
            {
                if(currentDrink.Volume > maxVolume)
                {
                    maxVolume = currentDrink.Volume;
                }
            }

            Drink drink = Drinks.FirstOrDefault(d => d.Volume == maxVolume);
            return drink;
        }
        public Drink GetCheapest()
        {
            decimal minPrice = int.MaxValue;
            foreach (var currentDrink in Drinks)
            {
                if (currentDrink.Price < minPrice)
                {
                    minPrice = currentDrink.Price;
                }
            }

            Drink drink = Drinks.FirstOrDefault(d => d.Price == minPrice);
            return drink;
        }
        public string BuyDrink(string name)
        {
            Drink drink = Drinks.FirstOrDefault(d => d.Name == name);
            return drink.ToString();
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("Drinks available:");

            sb.AppendLine(string.Join(Environment.NewLine, Drinks));

            return sb.ToString().TrimEnd();
        }
    }
}
