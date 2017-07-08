using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensionSize = int.Parse(Console.ReadLine());
            var changedCells = 0;
            var sumOfParticles = 0L;
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "Analyze")
            {
                var tokens = inputLine.Split(' ').Select(int.Parse).ToArray();
                if (tokens.Take(3).Any(pt => pt < 0 || pt >= dimensionSize))
                {
                    continue;
                }

                if (tokens[3] != 0)
                {
                    sumOfParticles += tokens[3];
                    changedCells++;
                }

            }

            Console.WriteLine(sumOfParticles);
            Console.WriteLine(Math.Pow(dimensionSize, 3) - changedCells);
        }
    }
}
