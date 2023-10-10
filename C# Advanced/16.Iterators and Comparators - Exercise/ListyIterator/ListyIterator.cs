using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListyIterator
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> items) 
        {
            this.items = items;
        }
        public bool Move()
        {
            if(index < items.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index < items.Count - 1;
        }

        public void Print()
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[index]);
        }
        public void PrintAll()
        {
            //foreach (var item in items)
            //{
            //    Console.Write($"{item} ");
            //}
            Console.WriteLine(string.Join(' ', items));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
