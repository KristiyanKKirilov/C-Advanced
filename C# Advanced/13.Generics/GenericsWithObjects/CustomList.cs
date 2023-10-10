using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsWithObjects
{
    public class CustomList<T>
    {
        private T[] items;
        private int index;

        public CustomList()
        {
                this.items = new T[2];
        }
        public void Add(T item)
        {
            items[index++] = item;
        }
        public object GetAtIndex(int index)
        {
            return items[index];
        }
        public T[] ToArray()
        {
            return items;
        }
    }
}
