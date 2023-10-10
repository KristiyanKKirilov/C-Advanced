using Store.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Fakes
{
    public class FakeProductDatabase : IProductDatabase
    {
        public int saveMethodCalls = 0;
        public Product AddedProduct { get; set; }
        public void AddProduct(Product product)
        {
            AddedProduct = product;
        }

        public IEnumerable<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product() { Name = "Test", Id  = 1},
                new Product() { Name = "Test2", Id  = 2}
            };
        }

        public bool RemoveProduct(Product product)
        {
            return true;
        }

        public void Save()
        {
            saveMethodCalls++;
        }
    }
}
