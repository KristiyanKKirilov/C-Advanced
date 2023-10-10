using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.AddRange(new string[] { "1", "2", "3" });
            
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(string.Join(" ", stack));
        }

    }
}