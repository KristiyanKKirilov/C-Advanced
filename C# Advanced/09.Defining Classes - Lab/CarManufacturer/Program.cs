using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string tireInfo;
            List<Car> cars = new List<Car>();


            while ((tireInfo = Console.ReadLine()) != "No more tires")
            {
                Car car = new Car();
                Tire[] tires = new Tire[4];
                

                double[] yearAndPressure = tireInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                

                for (int i = 0; i < tires.Length; i++)
                {
                    for (int j = 0; j < yearAndPressure.Length; j+= 2)
                    {
                        tires[i] = new Tire((int)yearAndPressure[j], yearAndPressure[j + 1]);
                        i++;                                               
                    }
                }
                cars.Add(car);
            }
            //Engine engine = new Engine(265, 2);



        }
    }

}