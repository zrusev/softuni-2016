using System.Linq;

namespace _06.Truck_Tour
{
    using System;
    using System.Collections.Generic;
    public class Truck_Tour
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<GasPump> pumps = new Queue<GasPump>();

            for (int i = 0; i < n; i++)
            {
                string[] pumpInfo = Console.ReadLine().Split();
                int distanceToNext = int.Parse(pumpInfo[1]);
                int amountOfGas = int.Parse(pumpInfo[0]);

                GasPump pump = new GasPump(distanceToNext, amountOfGas, i);
                pumps.Enqueue(pump);
            }

            GasPump starterPump = null;
            bool completeJourney = false;
            while (true)
            {
                GasPump currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                starterPump = currentPump;
                int gasInTank = currentPump.amountOfGas;

                while (gasInTank >= currentPump.distanceToNext)
                {
                    gasInTank -= currentPump.distanceToNext;

                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);
                    if (currentPump == starterPump)
                    {
                        completeJourney = true;
                        break;
                    }
                    gasInTank += currentPump.amountOfGas;
                }

                if (completeJourney)
                {
                    Console.WriteLine(starterPump.indexOfPump);
                    break;
                }
            }
        }
    }

    public class GasPump
    {
        public int distanceToNext;
        public int amountOfGas;
        public int indexOfPump;

        public GasPump(int distanceToNext, int amountOfGas, int indexOfPump)
        {
            this.distanceToNext = distanceToNext;
            this.amountOfGas = amountOfGas;
            this.indexOfPump = indexOfPump;
        }

    }
}
