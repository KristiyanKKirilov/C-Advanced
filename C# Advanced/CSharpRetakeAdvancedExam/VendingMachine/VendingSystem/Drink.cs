﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendingSystem
{
    public class Drink
    {
		private string name;
		private decimal price;
		private int volume;

        public Drink(string name, decimal price, int volume)
        {
            Name = name;
            Price = price; 
            Volume = volume;
        }
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        public override string ToString()
        {
            return $"Name: {Name}, Price: ${Price}, Volume: {Volume} ml";
        }
    }
}
