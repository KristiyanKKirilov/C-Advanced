using System;

namespace DiceThrowing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice d6 = new() 
            { 
                Side = 6
            };

            d6.Roll();

            Dice d1 = new()
            {
                Side = 1
            };

            d1.Roll();
        }
    }
   
}