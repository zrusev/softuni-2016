namespace _01.Sino_The_Walker
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Sino_The_Walker
    {
        public static void Main()
        {
            var startingTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var numberOfSteps = int.Parse(Console.ReadLine());
            var secondsPerStep = int.Parse(Console.ReadLine());

            long initialSeconds = startingTime.Hour * 60 * 60 + startingTime.Minute * 60 + startingTime.Second;

            ulong secondsToAdd = (ulong)numberOfSteps * (ulong)secondsPerStep;

            ulong totalSeconds = (ulong)initialSeconds + secondsToAdd;

            var seconds = totalSeconds % 60;
            var totalMinutes = totalSeconds / 60;
            var minutes = totalMinutes % 60;
            var totalHours = totalMinutes / 60;
            var hours = totalHours % 24;

            Console.WriteLine($"Time Arrival: {hours:00}:{minutes:00}:{seconds:00}");


        }
    }
}
