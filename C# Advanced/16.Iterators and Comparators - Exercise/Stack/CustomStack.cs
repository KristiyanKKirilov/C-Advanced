using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] items;
        private const int InitialCapacity = 4;
        public CustomStack()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; set; }
        public void Push(params T[] values)
        {          
            for (int i = 0; i < values.Length; i++)
            {
                if (Count == items.Length)
                {
                    Resize();
                }
                items[Count] = values[i];
                Count++;

            }
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removedItem = items[Count - 1];
            Count--;
            return removedItem;
        }
        private void Resize()
        {
            T[] copy = new T[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
