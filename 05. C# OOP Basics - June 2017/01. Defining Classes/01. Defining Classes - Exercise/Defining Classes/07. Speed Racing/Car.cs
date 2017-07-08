using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07.Speed_Racing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1Km;
        private double distance;
        public string Model { get => model; set => model = value; }
        public double FuelAmount { get => fuelAmount; set => fuelAmount = value; }
        public double FuelConsumptionFor1Km { get => fuelConsumptionFor1Km; set => fuelConsumptionFor1Km = value; }
        public double Distance { get => distance; set => distance = value; }
        public void Drive(List<Car> carList,string carModel , double amountOfKm)
        {
            var vehicleToManage = carList.Select(x => x).Where(x => x.Model.Equals(carModel)).FirstOrDefault();
            var maxDistance = vehicleToManage.FuelAmount / vehicleToManage.FuelConsumptionFor1Km;
            
            if (maxDistance < amountOfKm)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                vehicleToManage.FuelAmount -= amountOfKm * vehicleToManage.FuelConsumptionFor1Km;
                vehicleToManage.Distance += amountOfKm;
            }
        }
        
    }
}
