using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contracts
{
    public interface IProductDatabase
    {

        public void AddProduct(Product product);


        public bool RemoveProduct(Product product);

        public IEnumerable<Product> GetAll();

        public void Save();
    }
}
 