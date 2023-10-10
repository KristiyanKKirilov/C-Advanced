using Newtonsoft.Json;
using Store.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class ProductTextDatabase:IProductDatabase
    {
        private const string dbPath = @"E:\Visual Studio Projects\Soft Uni\C# OOP\14.MockingAndTestDrivenDevelopment\Store\products-db.txt";
        private List<Product> products;


        public ProductTextDatabase()
        {
            products = Load() ;
        }

        public List<Product> Products => products;
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool RemoveProduct(Product product)
        {
            return products.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        => products;

        public void Save()
        {
            using (StreamWriter writer = new(dbPath))
            {
                writer.Write(JsonConvert.SerializeObject(products));
            }
        }

        private List<Product> Load()
        {
            if(!File.Exists(dbPath))
            {
                return new List<Product>();
            }

            string productsData = "";
            using (StreamReader reader = new(dbPath))
            {
                reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Product>>(productsData);
        }
    }
}
