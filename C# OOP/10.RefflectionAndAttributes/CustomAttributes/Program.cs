using System;

namespace CustomAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Printer);
            object[] attributes = type.GetCustomAttributes(typeof(DocumentAttribute), false);
            DocumentAttribute att = (DocumentAttribute)attributes[0];
            Console.WriteLine(att.IsCritical);
            Console.ForegroundColor  = att.Color;
            Console.WriteLine("iskam");
        }

    }

    [Document]
    class Printer
    {
        [Document(true, Color = ConsoleColor.Red)]
        public void Print()
        {

        }
    }

}