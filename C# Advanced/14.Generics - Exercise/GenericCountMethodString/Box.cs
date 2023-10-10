using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString
{
    public class Box<T> where T: IComparable<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }

        public int Count(T itemToCompare)
        {
            int count = 0;
            foreach (var item in items)
            {
                if(item.CompareTo(itemToCompare) == 1)
                {
                    count++;
                }
            }
            return count;
        }
        

    }
}
