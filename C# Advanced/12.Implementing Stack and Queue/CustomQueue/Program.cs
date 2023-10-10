using System;

namespace CustomQueue;

internal class Program
{
    static void Main(string[] args)
    {
        CustomQueue queue = new CustomQueue();
        queue.Enqeue(9);
        queue.Enqeue(10);
        queue.Enqeue(11);
        queue.Enqeue(12);
        queue.Enqeue(13);
        queue.Enqeue(9);
        queue.Enqeue(10);
        queue.Enqeue(11);
        queue.Enqeue(12);
        queue.Enqeue(13);
        queue.Enqeue(11);
        queue.Enqeue(12);
        queue.Enqeue(13);

        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
        queue.ForEach(item => Console.Write(item + " "));
        Console.WriteLine();
        Console.WriteLine(queue.Count); 
        queue.Clear();
        //queue.ForEach(item => Console.WriteLine(item + " "));
    }
}
