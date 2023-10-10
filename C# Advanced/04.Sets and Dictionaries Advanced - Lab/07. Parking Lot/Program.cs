using System;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = info[0];
                string plate = info[1];
                if (command == "IN")
                {
                    parking.Add(plate);
                }
                else if(command == "OUT")
                {
                    parking.Remove(plate);
                }
            }
            if (parking.Any())
            {
                foreach (var plate in parking)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}