using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.Parking_Sys
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solution without matrices => 100/100 in Judge

            string[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);

            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                string[] parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int entryRow = int.Parse(parameters[0]);
                int desiredRow = int.Parse(parameters[1]);
                int desiredCol = int.Parse(parameters[2]);

                // Where is parked?
                int parkColumn = 0;

                if (!IsOccupied(parking, desiredRow, desiredCol))
                {
                    parkColumn = desiredCol;
                }
                else
                {
                    for (int i = 1; i < cols - 1; i++)
                    {
                        if (((desiredCol - i) > 0) &&
                            !IsOccupied(parking, desiredRow, (desiredCol - i)))
                        {
                            parkColumn = (desiredCol - i);
                            break;
                        }
                        else if (((desiredCol + i) < cols) &&
                                 !IsOccupied(parking, desiredRow, (desiredCol + i)))
                        {
                            parkColumn = (desiredCol + i);
                            break;
                        }
                    }
                }

                if (parkColumn == 0)
                {
                    Console.WriteLine($"Row {desiredRow} full");
                }
                else
                {
                    parking[desiredRow].Add(parkColumn);
                    int steps = Math.Abs(entryRow - desiredRow) + 1 + parkColumn;
                    Console.WriteLine(steps);
                }

                input = Console.ReadLine();
            }
        }

        private static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }
            else
            {
                parking.Add(row, new HashSet<int>());
            }
            return false;
        }
    }
}