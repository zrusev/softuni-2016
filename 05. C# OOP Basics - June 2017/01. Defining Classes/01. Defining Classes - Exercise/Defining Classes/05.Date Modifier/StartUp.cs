using System;
using System.Collections.Generic;

namespace _05.Date_Modifier
{
    public class StartUp
    {
        public static void Main()
        {
            var firstInput = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var secondInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var dates = new DateModifier();
            dates.FirstDate = string.Join("/", firstInput);
            dates.SecondDate = string.Join("/", secondInput);

            Console.WriteLine(dates.CalculateDifference());
        }
    }
}
