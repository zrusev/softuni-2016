using System;
using System.Collections.Generic;

namespace _07.Speed_Racing
{
    public class StartUp
    {
        public static void Main()
        {
            var carList = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumptionFor1Km = double.Parse(input[2]);
                var currentVehicle = new Car();
                currentVehicle.Model = model;
                currentVehicle.FuelAmount = fuelAmount;
                currentVehicle.FuelConsumptionFor1Km = fuelConsumptionFor1Km;
                currentVehicle.Distance = 0;
                carList.Add(currentVehicle);
            }

            string end = String.Empty;
            while ((end = Console.ReadLine()) != "End")
            {
                var tokens = end.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var carModel = tokens[1];
                var amountOfKm = double.Parse(tokens[2]);
                var currentVehicle = new Car();
                currentVehicle.Drive(carList,carModel,amountOfKm);
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.Distance}");
            }

        }
    }
}
