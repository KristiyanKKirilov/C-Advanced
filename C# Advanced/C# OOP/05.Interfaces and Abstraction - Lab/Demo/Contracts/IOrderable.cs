using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Contracts
{
    public interface IOrderable
    {
        public void TakeOrder(string order);
    }
}
