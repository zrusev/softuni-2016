namespace Problem03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Problem03
    {
        public static void Main()
        {
            var beehives = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var hornets = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var sumPowerHornets = hornets.Sum();
            var deadHornet = 0;

            for (int i = 0; i < beehives.Length; i++)
            {

                if (sumPowerHornets > beehives[i])
                {
                    beehives[i] = 0;
                }
                else if (sumPowerHornets <= beehives[i] && sumPowerHornets > 0)
                {
                    beehives[i] = beehives[i] - sumPowerHornets;
                    hornets[deadHornet] = 0;
                    deadHornet++;
                    sumPowerHornets = hornets.Sum();
                }
            }

            if (beehives.Sum() != 0)
            {
                var newArray = beehives
                    .Where(x => x != 0)
                    .ToArray();
                Console.WriteLine(string.Join(" ", newArray));
            }
            else
            {
                var newArrayHornets = hornets
                    .Where(x => x != 0)
                    .ToArray();
                var res = string.Join(" ", newArrayHornets);
                Console.WriteLine(string.Join(" ", newArrayHornets));
            }

        }
    }
}
