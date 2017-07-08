using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Raw_Data
{
    public class StartUp
    {
        public static void Main()
        {
            var listOfRectangles = new List<Rectangle>();
            var input = Console.ReadLine().Split(' ');
            var numberOfRectangles = int.Parse(input[0]);
            var numberOfIntersections = int.Parse(input[1]);

            for (int i = 0; i < numberOfRectangles; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var id = tokens[0];
                var width = double.Parse(tokens[1]);
                var height = double.Parse(tokens[2]);
                var horizontalCoordinate = double.Parse(tokens[3]);
                var verticalCoordinate = double.Parse(tokens[4]);

                var currentRectangle = new Rectangle();
                currentRectangle.Id = id;
                currentRectangle.Width = width;
                currentRectangle.Height = height;
                currentRectangle.HorizontalCoordinate = horizontalCoordinate;
                currentRectangle.VerticalCoordinate = verticalCoordinate;

                listOfRectangles.Add(currentRectangle);
            }

            for (int i = 0; i < numberOfIntersections; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var firstRectangle = listOfRectangles.Select(x => x).Where(x => x.Id.Equals(tokens[0])).FirstOrDefault();
                var secondRectangle = listOfRectangles.Select(x => x).Where(x => x.Id.Equals(tokens[1])).FirstOrDefault();

                var result = CheckIntersection(firstRectangle, secondRectangle);
                Console.WriteLine(result);
            }
        }

        private static string CheckIntersection(Rectangle firstRectangle, Rectangle secondRectangle)
        {
            double x1 = firstRectangle.HorizontalCoordinate;
            double x2 = secondRectangle.HorizontalCoordinate;
            double y1 = firstRectangle.VerticalCoordinate;
            double y2 = secondRectangle.VerticalCoordinate;
            double w1 = firstRectangle.Width;
            double w2 = secondRectangle.Width;
            double h1 = firstRectangle.Height;
            double h2 = secondRectangle.Height;


            if ((x1 + w1) < x2 || (x2 + w2) < x1 || (y1 + h1) < y2 || (y2 + h2) < y1)
            {
                return "false";
            }

            return "true";
        }
    }
}
