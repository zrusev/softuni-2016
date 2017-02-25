namespace _01.Charity_Marathon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Charity_Marathon
    {
        public static void Main()
        {
            var marathonDays = decimal.Parse(Console.ReadLine());
            var numberOfRunners = decimal.Parse(Console.ReadLine());
            var numberOfLaps = decimal.Parse(Console.ReadLine());
            var trackLength = decimal.Parse(Console.ReadLine());
            var trackCapacity = decimal.Parse(Console.ReadLine());
            var moneyPerKilometer = decimal.Parse(Console.ReadLine());

            var totalRunners = Math.Min(numberOfRunners, trackCapacity * marathonDays);
            var totalMeters = totalRunners * numberOfLaps * trackLength;
            var totalKilometers = totalMeters / 1000;

            var moneyRaised = totalKilometers * moneyPerKilometer;

            Console.WriteLine($"Money raised: {moneyRaised:F2}");
           


        }
    }
}
