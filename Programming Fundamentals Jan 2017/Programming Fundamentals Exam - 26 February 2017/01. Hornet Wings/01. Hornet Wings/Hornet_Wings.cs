namespace _01.Hornet_Wings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = decimal.Parse(Console.ReadLine());
            var p = int.Parse(Console.ReadLine());

            var distance = n / 1000 * m;
            var flapsPerSecond = n / 100;
            var secondsToRest = n / p * 5;

            Console.WriteLine($"{distance:F2} m.");
            var result = flapsPerSecond + secondsToRest;
            Console.WriteLine($"{result} s.");
        }
    }
}
