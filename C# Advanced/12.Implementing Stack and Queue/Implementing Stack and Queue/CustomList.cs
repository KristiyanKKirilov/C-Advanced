using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                ThrowIndexOutOfRangeException(index);
                return items[index];
            }
            set
            {
                ThrowIndexOutOfRangeException(index);
                items[index] = value;
            }
        }


        public void Add(int item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }
        public void AddRange(int[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        public int RemoveAt(int index)
        {
            ThrowIndexOutOfRangeException(index);
            int removedItem = items[index];
            items[index] = default;

            ShiftLeft(index);

            Count--;

            if (items.Length / 4 >= Count)
            {
                Shrink();
            }
            return removedItem;
        }
        public void InsertAt(int index, int item)
        {
            ThrowIndexOutOfRangeException(index);

            if(items.Length == Count)
            {
                Resize();
            }

            ShiftRight(index);

            items[index] = item;

            Count++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ThrowIndexOutOfRangeException(firstIndex);
            ThrowIndexOutOfRangeException(secondIndex);

            int firstItem = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = firstItem;
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

        private void ThrowIndexOutOfRangeException(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

        }        
        
        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default;
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
       
        private void ShiftRight(int index)
        {
            // 1 2 3 4 5 6
            //
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
            items[index] = default;
        }



    }
}
