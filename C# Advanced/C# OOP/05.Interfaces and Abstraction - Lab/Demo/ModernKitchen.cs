using Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ModernKitchen : IOrderable
    {
        public void TakeOrder(string order)
        {
            Console.WriteLine($"Preparing {order}");
            Console.WriteLine("New method preparing");
        }
    }
}
