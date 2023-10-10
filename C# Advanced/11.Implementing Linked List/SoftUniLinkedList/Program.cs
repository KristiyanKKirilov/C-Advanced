using System;

namespace SoftUniLinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        //Node ten = new Node(10);
        //Node twenty = new Node(20);
        //Node thirty = new Node(30);
        //ten.Next = twenty;
        //twenty.Previous = ten;
        //twenty.Next = thirty;
        //thirty.Previous = twenty;

        //Node currentNode = ten;
        //while (currentNode != null)
        //{
        //    Console.WriteLine(currentNode.Value);
        //    currentNode = currentNode.Next;
        //}
        //CustomSoftUniLinkedList<int> linkedList = new CustomSoftUniLinkedList<int>();
        ////linkedList.AddLast(1);
        //linkedList.AddLast(2);
        //linkedList.AddLast(3);
        //linkedList.AddFirst(1);
        //linkedList.AddFirst(2);
        //linkedList.AddFirst(3);
        //linkedList.AddFirst(4);
        //linkedList.AddFirst(5);

        //Node<int> currentNode = linkedList.RemoveFirst();
        //linkedList.ForEach(node =>
        //{
        //    Console.WriteLine($"ForEach is cool {node.Value}");           
        //});

        //CustomSoftUniLinkedList<string> linkedList1 = new CustomSoftUniLinkedList<string>();
        ////while (currentNode != null) 
        ////{
        ////    Console.WriteLine(currentNode.Value);
        ////    currentNode = linkedList.RemoveFirst();
        ////}
        ///

        CustomSoftUniLinkedList<int> list = new();
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddFirst(1);
        list.AddFirst(4);

        Console.WriteLine(list.RemoveFirst());
        Console.WriteLine(list.RemoveLast());

        int[] arr = list.ToArray();
        list.ForEach(i => Console.WriteLine(i + " "));
        Console.WriteLine();
        Console.WriteLine(list.Count);

    }
}