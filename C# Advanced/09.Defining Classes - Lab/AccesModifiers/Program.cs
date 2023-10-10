using System;

namespace AccesModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shoe shoe = new()
            {
                Model = "New"
            };

            shoe.BuyShoe();
        }
    }
    public class Shoe
    {
        public string Model { get; set; }

        private int Size = 40;  

        public void BuyShoe()
        {
            Console.WriteLine("Buying");
            PrintShoe();
        }
        private void PrintShoe()
        {
            Console.WriteLine($"{Model} - {Size}");
        }
    }
}