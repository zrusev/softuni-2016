namespace _01.Softuni_Coffee_Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Globalization;

    public class Softuni_Coffee_Orders
    {
        public static void Main()
        {
            var ordersNumber = int.Parse(Console.ReadLine());

            var total = default(decimal);

            for (int i = 0; i < ordersNumber; i++)
            {
                var totalPerOrder = default(decimal);
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsulesCount = int.Parse(Console.ReadLine());

                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                totalPerOrder = pricePerCapsule * daysInMonth * capsulesCount;
                total += totalPerOrder;

                Console.WriteLine($"The price for the coffee is: ${totalPerOrder:F2}");
            }

            Console.WriteLine($"Total: ${total:F2}");


        }
    }
}
