using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Raw_Data_1_
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfCars = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var currentCar = new Car();
                currentCar.Model = tokens[0];
                currentCar.Engine.EngineSpeed = int.Parse(tokens[1]);
                currentCar.Engine.EnginePower = int.Parse(tokens[2]);
                currentCar.Cargo.CargoWeight = int.Parse(tokens[3]);
                currentCar.Cargo.CargoType = tokens[4];
                currentCar.Tires.Tire1Pressure = double.Parse(tokens[5]);
                currentCar.Tires.Tire1Age = int.Parse(tokens[6]);
                currentCar.Tires.Tire2Pressure = double.Parse(tokens[7]);
                currentCar.Tires.Tire2Age = int.Parse(tokens[8]);
                currentCar.Tires.Tire3Pressure = double.Parse(tokens[9]);
                currentCar.Tires.Tire3Age = int.Parse(tokens[10]);
                currentCar.Tires.Tire4Pressure = double.Parse(tokens[11]);
                currentCar.Tires.Tire4Age = int.Parse(tokens[12]);

                listOfCars.Add(currentCar);
            }

            if (Console.ReadLine().Equals("fragile"))
            {
               var newList = listOfCars.GroupBy(x => x.Model).Select(x => new
                {
                    Type = x.Select(t => t.Cargo.CargoType.Equals("fragile")),
                    Tires = x.Select(e => e.Tires),
                    Gr = x
                }).Where(x => x.Tires.Any(y => y.Tire1Pressure < 1 || y.Tire2Pressure < 1 || y.Tire3Pressure < 1 ||
                                               y.Tire4Pressure < 1)).ToList();

                foreach (var element in newList)
                {
                    Console.WriteLine(element.Gr.Key);
                }

            }
            else
            {
                var newList = listOfCars.GroupBy(x => x.Model).Select(x => new
                {
                    Type = x.Select(t => t.Cargo.CargoType.Equals("flamable")),
                    Engine = x.Select(e => e.Engine),
                    Gr = x
                }).Where(x => x.Engine.Any(y => y.EnginePower > 250)).ToList();

                foreach (var element in newList)
                {
                    Console.WriteLine(element.Gr.Key);
                }
            }
        }
    }
}
