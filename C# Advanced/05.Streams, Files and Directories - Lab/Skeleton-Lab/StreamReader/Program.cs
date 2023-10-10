using System;

namespace StreamReaderAnalys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (StreamReader reader = new StreamReader("../../../input.txt"))
            //{
            //    int row = 1;
            //    while (!reader.EndOfStream)
            //    {
            //        Console.WriteLine($"{row++}.{reader.ReadLine()}");

            //    }               
            //}
            for (int i = 0; i < 5; i++)
            {
                using (StreamWriter writer = new($"../../../output{i+1}.txt", false))
                {
                    writer.WriteLine($"New line added ({i+1})");
            }
            }
            



        }
    }
}