using System;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> normalGuests = new HashSet<string>();

            string reservationNumber = string.Empty;

            while ((reservationNumber = Console.ReadLine()) != "PARTY")
            {
                if (!guests.Contains(reservationNumber) && reservationNumber.Length == 8)
                {
                    guests.Add(reservationNumber);
                }
            }

            while ((reservationNumber = Console.ReadLine()) != "END")
            {
                if (guests.Contains(reservationNumber))
                {
                    guests.Remove(reservationNumber);
                }               
            }

            Console.WriteLine(guests.Count);

            foreach (var guest in guests)
            {
                int firstIndex = guest[0];
                
                if(firstIndex >= 48 && firstIndex <= 57)
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    normalGuests.Add(guest);
                }
                
            }
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in normalGuests)
            {
                Console.WriteLine(guest);
            }


        }

    }
}