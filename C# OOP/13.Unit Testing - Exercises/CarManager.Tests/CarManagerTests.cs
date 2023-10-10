namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("Audi", "A5", 10, 110)]
        public void CreatingCarConstructorShouldWorkProperly
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);

            string expectedMake = make;
            string expectedModel = model;
            double expectedFuelConsumption = fuelConsumption;
            double expectedFuelCapacity = fuelCapacity;
            double expectedfuelAmount = 0;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(expectedfuelAmount, car.FuelAmount);

        }

        [TestCase(null, "A5", 10, 110)]
        [TestCase("", "A5", 10, 110)]
        public void CreatingCarConstructorShouldThrowExceptionWhenMakeIsNullOrEmpty
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(make, model, fuelConsumption, fuelCapacity), "Make cannot be null or empty!");

        }


        [TestCase("Audi", null, 10, 110)]
        [TestCase("Audi", "", 10, 110)]
        public void CreatingCarConstructorShouldThrowExceptionWhenModeleIsNullOrEmpty
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(make, model, fuelConsumption, fuelCapacity), "Model cannot be null or empty!");

        }

        [TestCase("Audi", "A5", 0, 110)]
        [TestCase("Audi", "A5", -10, 110)]
        public void CreatingCarConstructorShouldThrowExceptionWhenFuelConsumptionIsNotPositive
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(make, model, fuelConsumption, fuelCapacity),
                "Fuel consumption cannot be zero or negative!");

        }

        [TestCase("Audi", "A5", 10, 0)]
        [TestCase("Audi", "A5", 10, -10)]
        public void CreatingCarConstructorShouldThrowExceptionWhenFuelCapacityIsNotPositive
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Car(make, model, fuelConsumption, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");

        }


        [TestCase("Audi", "A5", 10, 110)]
        public void CreatingCarRefuelMethodShouldWorkCorrectly
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(25);

            double expectedFuel = 25;

            Assert.AreEqual(expectedFuel, car.FuelAmount);

        }

        [TestCase("Audi", "A5", 10, 110, 0)]
        [TestCase("Audi", "A5", 10, 110, -29)]

        public void CreatingCarRefuelMethodShouldThrowExceptionWhenFuelIsNotPositive
            (string make, string model, double fuelConsumption, double fuelCapacity, double refuelAmount)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);

            double expectedFuel = 25;

            Assert.Throws<ArgumentException>(
                () => car.Refuel(refuelAmount), "Fuel amount cannot be zero or negative!");

        }

        [TestCase("Audi", "A5", 10, 50, 55)]
        [TestCase("Audi", "A5", 10, 110, 111)]
        public void CreatingCarRefuelMethodShouldRefuelProperly
            (string make, string model, double fuelConsumption, double fuelCapacity, double refuelAmount)
        {
            Car car = new(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(refuelAmount);

            double expectedFuel = fuelCapacity;

            Assert.AreEqual(expectedFuel, car.FuelAmount);

        }


        [TestCase("Audi", "A5", 10, 50, 50, 20)]
        public void CreatingCarDriveMethodShouldWorkCorrectlyNeededFuel
            (string make, string model, double fuelConsumption, double fuelCapacity,
            double refuelAmount, double distance)
        {

            Car car = new(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(refuelAmount);

            double previousFuel = car.FuelAmount;
            car.Drive(distance);

            double expectedFuelNeeded = 2;
            double actualFuelNeeded = previousFuel - car.FuelAmount;
            Assert.AreEqual(expectedFuelNeeded, actualFuelNeeded);

        }

        [TestCase("Audi", "A5", 10, 50, 50, 20)]
        public void CreatingCarDriveMethodShouldWorkCorrectly
            (string make, string model, double fuelConsumption, double fuelCapacity,
            double refuelAmount, double distance)
        {

            Car car = new(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(refuelAmount);

            double expectedFuelAmount = 48;
            car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }

        [TestCase("Audi", "A5", 10, 50, 10, 200)]
        public void CreatingCarDriveMethodShouldThrowExceptionWhenFuelIsntEnough
            (string make, string model, double fuelConsumption, double fuelCapacity,
            double refuelAmount, double distance)
        {

            Car car = new(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(refuelAmount);

            Assert.Throws<InvalidOperationException>(
                () => car.Drive(distance), "You don't have enough fuel to drive!");

        }

    }
}