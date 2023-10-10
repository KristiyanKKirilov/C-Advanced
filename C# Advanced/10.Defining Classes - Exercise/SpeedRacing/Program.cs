using System;

namespace SpeedRacing;

internal class StartUp
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int numberOfCarsToTrack = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCarsToTrack; i++)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
           
            string model = carInfo[0];
            double fuelAmount = double.Parse(carInfo[1]);
            double fuelConsumptionFor1km = double.Parse(carInfo[2]);
            Car car = new Car(model, fuelAmount, fuelConsumptionFor1km, 0);

            if (!cars.Contains(car))
            {
                cars.Add(car);
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            //"Drive {carModel} {amountOfKm}"
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);            
            string model = tokens[1];
            int amountOfKm = int.Parse(tokens[2]);

            foreach (var currentCar in cars)
            {
                if(currentCar.Model == model)
                {
                    currentCar.Move(amountOfKm);
                }
            }           
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}