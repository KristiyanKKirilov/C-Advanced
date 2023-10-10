using System;
using System.Xml.Linq;

namespace Store
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            ProductTextDatabase database = new();
            //database.AddProduct(new Product { Name = "Nike Soft", Id = 1 });
            //database.Save();
            //database.AddProduct(new Product { Name = "Nike Soft Air", Id = 2 });
            //database.Save();
            Store store = new(database);
            store.AddProduct(new Product { Name = "Nike Soft", Id = 1 });
            store.AddProduct(new Product { Name = "Nike Soft Air", Id = 2 });

        }
    }
}