using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        public CustomStack()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int item)
        {
            if(items.Length == Count)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }
        public int Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException("Custom stack is empty");
            }

            int removedItem = items[Count - 1];
            //items[Count - 1] = default;
            Count--;          

            if (items.Length / 4 >= Count)
            {
                Shrink();
            }
            return removedItem;
        }       
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Custom stack is empty");
            }
            return items[Count - 1];                                            
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                int currentItem = items[i];
                action(currentItem);
            }
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items = copy;
        }
        private void Shrink()
        {
            int[] copy = new int[InitialCapacity / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
    }
}
