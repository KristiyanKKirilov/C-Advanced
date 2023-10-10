using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrowing
{
    public class Dice
    {
        public int Side { get; set; }

        public void Roll()
        {
            Console.WriteLine($"Dice {Side} was rolled");
        }
    }
}
