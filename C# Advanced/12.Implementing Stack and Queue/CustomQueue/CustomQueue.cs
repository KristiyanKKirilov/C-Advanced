using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private int[] items;
        public CustomQueue()
        {
            items = new int[InitialCapacity];
        }
        public int Count { get; set; }


        public void Enqeue(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }
            items[Count] = item;
            Count++;
        }
        public int Dequeue()
        {
            IsEmpty();

            int removedItem = items[0];
            ShiftLeft();
            Count--;

            if (IsReadyToShrink())
            {
                Shrink();
            }
            return removedItem;
        }

        public int Peek()
        {
            IsEmpty();
            return items[0];
        }

        public void Clear()
        {
            IsEmpty();

            items = new int[InitialCapacity];
            Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            IsEmpty();

            for (int i = Count - 1; i >= 0; i--)
            {
                action(items[i]);
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
        private void ShiftLeft()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            
        }
        private void IsEmpty()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
        }        
        private bool IsReadyToShrink()
        {
            if(items.Length / 4 >= Count)
            {
                return true;
            }

            return false;
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
