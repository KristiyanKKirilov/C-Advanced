using System;

namespace Overriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            B b = new();
            Console.WriteLine(b.ToString());
        }
    }
    class A
    {
        public virtual string ToString()
        {
            return "FirstOne";
        }
    }
    class B : A
    {
        public override sealed string ToString()
        {
            
            return $"{base.ToString()} SecondOne";
        }
    }
    
}