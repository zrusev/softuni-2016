using System.Text.RegularExpressions;

namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var inputParams = Regex.Split(input, ", ", RegexOptions.IgnorePatternWhitespace);

                if (inputParams[0] == "IN")
                {
                    parking.Add(inputParams[1]);
                }
                else
                {
                    if (parking.Contains(inputParams[1]))
                    {
                        parking.Remove(inputParams[1]);
                    }
                }

                input = Console.ReadLine();

            }

            if (parking.Count != 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car.Trim());
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            

        }
    }
}
