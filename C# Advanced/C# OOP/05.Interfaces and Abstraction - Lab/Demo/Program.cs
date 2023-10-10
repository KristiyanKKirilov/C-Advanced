using System;


namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waiter waiter = new(new Kitchen());
            Waiter waiterNew = new(new ModernKitchen());
            while (true)
            {
                waiter.TakeOrder(Console.ReadLine());
                waiterNew.TakeOrder(Console.ReadLine());
            }
        }
    }
}