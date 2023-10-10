using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new(100, 100);
            sportCar.Drive(5);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
