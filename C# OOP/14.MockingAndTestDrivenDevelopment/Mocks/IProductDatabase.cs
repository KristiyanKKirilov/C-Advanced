using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocks
{
    public interface IProductDatabase
    {
        public void AddProduct(string product);

        public bool RemoveProduct(string product);

        public IEnumerable<string> GetAll();

        public void Save();
    }
}
