using System;
using System.Collections.Generic;

namespace _10.Car_Salesman
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfEngines = new List<Engine>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var currentEngine = new Engine();
                currentEngine.Model = tokens[0];
                currentEngine.Power = int.Parse(tokens[1]);
                currentEngine.Displacement = "n/a";
                currentEngine.Efficiency = "n/a";

                if (tokens.Length == 3)
                {
                    if (int.TryParse(tokens[2], out int displacement))
                    {
                        currentEngine.Displacement = displacement.ToString();

                    }
                    else
                    {
                        currentEngine.Efficiency = tokens[2];
                    }

                }
                else if (tokens.Length == 4)
                {
                    if (int.TryParse(tokens[2], out int displacement))
                    {
                        currentEngine.Displacement = displacement.ToString();
                        currentEngine.Efficiency = tokens[3];

                    }
                    else
                    {
                        currentEngine.Displacement = tokens[3];
                        currentEngine.Efficiency = tokens[2];
                    }
                }

                listOfEngines.Add(currentEngine);
            }

            var listOfCars = new List<Car>();
            var m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                var tokens = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var currentCar = new Car();

                currentCar.Model = tokens[0];
                currentCar.Engine = listOfEngines.Find(x => x.Model.Equals(tokens[1]));

                currentCar.Weight = "n/a";
                currentCar.Color = "n/a";

                if (tokens.Length == 3)
                {
                    if (int.TryParse(tokens[2], out int weight))
                    {
                        currentCar.Weight = weight.ToString();
                    }
                    else
                    {
                        currentCar.Color = tokens[2];
                    }
                }
                else if (tokens.Length == 4)
                {
                    if (int.TryParse(tokens[2], out int weight))
                    {
                        currentCar.Weight = weight.ToString();
                        currentCar.Color = tokens[3];
                    }
                    else
                    {
                        currentCar.Weight = tokens[3];
                        currentCar.Color = tokens[2];
                    }
                }

                listOfCars.Add(currentCar);
            }

            foreach (var car in listOfCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }


        }
    }
}
