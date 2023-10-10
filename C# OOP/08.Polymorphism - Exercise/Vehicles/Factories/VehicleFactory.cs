using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Type vehicleType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t=> t.Name == type);

            if(vehicleType is null)
            {
                throw new InvalidOperationException("Invalid vehicle type");
            }

            IVehicle vehicle = Activator.CreateInstance(vehicleType , fuelQuantity, fuelConsumption, tankCapacity) as IVehicle;

            return vehicle;

        }
    }
}
