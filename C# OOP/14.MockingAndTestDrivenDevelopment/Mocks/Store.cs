using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocks
{
    public class Store
    {
        public Store(IProductDatabase db) 
        {
            Console.WriteLine(db);
        }

    }
}
