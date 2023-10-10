using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLinkedList
{
    public class CustomSoftUniLinkedList<T>
    {
        private bool isReversed = false;
        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public int Count { get; set; }  

        public void Reverse()
        {           
            Node<T> oldHead = Head;
            Head = Tail;
            Tail = oldHead;
            isReversed = !isReversed;
        }
        public void ForEach(Action<Node<T>> action)
        {
            Node<T> node;
            if (isReversed)
            {
                node = Tail;
            }
            else
            {
                node = Head;
            }
            while (node != null)
            {
                action(node);
                if (isReversed)
                {
                    node = node.Previous;
                }
                else
                {
                    node = node.Next;
                }
                
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            ForEach(node => array[index++] = node.Value);
            return array;
        }
        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);
            if(Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
        }
        public void AddFirst(T value) 
        {
            Node<T> node = new Node<T>(value);
            if(Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            Head.Previous = node;
            node.Next = Head;
            Head = node;
        }
        public Node<T> RemoveFirst()
        {
            if(Head == null)
            {
                return null;
            }
            Node<T> oldHead = Head;
            if(Head.Next == null)
            {
                Head = null;
                Tail = null;
                return oldHead;
            }
            Node<T> newHead = Head.Next;
            Head.Next = null;
            newHead.Previous = null;
            Head = newHead;

            return oldHead;
        }
        public Node<T> RemoveLast()
        {
            if (Tail == null)
            {
                return null;
            }
            Node<T> oldTail = Tail;
            if (Tail.Previous == null)
            {
                Head = null;
                Tail = null;
                return oldTail;
            }
            Node<T> newTail = Tail.Previous;
            Tail.Previous = null;
            newTail.Next = null;
            Tail = newTail;

            return oldTail;
        }
    }
}
