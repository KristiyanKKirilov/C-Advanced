using System;

namespace _01.Implementing;

internal class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedList = new();

        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(5);

        LinkedListNode<int> currentNode = linkedList.First;
        //foreach (var number in linkedList)
        //{
           // Console.WriteLine(number);
        //}
        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Value);
            currentNode = currentNode.Next;
        }
            
    }
}