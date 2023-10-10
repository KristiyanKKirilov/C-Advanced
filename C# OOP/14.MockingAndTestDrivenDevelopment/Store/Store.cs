using Store.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Store
    {
        private IProductDatabase database;

        public Store(IProductDatabase database)
        {
            this.database = database;
        } 
        public List<Product> GetAllProducts()
        {
            return database.GetAll().ToList();
        }

        public string VisualizeAllProducts()
        {
            StringBuilder sb = new();

            foreach (Product product in database.GetAll())
            {
                sb.AppendLine($"{product.Id} - {product.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public void AddProduct(Product product)
        {
            database.AddProduct(product);
            database.Save();
        }
    }
}
