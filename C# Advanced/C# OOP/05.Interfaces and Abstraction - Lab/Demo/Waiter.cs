using Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Waiter : IOrderable
    {
        private IOrderable kitchen;

        public Waiter(IOrderable kitchen)
        {
            this.kitchen = kitchen;
        }
        public void TakeOrder(string order)
        {
            Console.WriteLine("Assuming order");
            kitchen.TakeOrder(order);  
        }
    }
}
