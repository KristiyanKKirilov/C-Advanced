using System;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList list= new CustomList();
            list.Add(1);
            list.Add(2);    
            list.Add(3);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.InsertAt(1, 4);
            list.Swap(0, 1);
        }
    }
}