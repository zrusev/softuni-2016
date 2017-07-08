namespace _02.Ladybugs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ladybugs
    {
        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var ladyBugIndexes = Console.ReadLine()
                                .Split()
                                .Select(p => p.Trim())
                                .Select(k => Convert.ToInt32(k))
                                .ToArray();

            var bugArray = new int[fieldSize];

            for (int i = 0; i < bugArray.Length; i++)
            {
                if (ladyBugIndexes.Contains(i))
                {
                    bugArray[i] = 1;
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("end"))
                {
                    break;
                }

                var line = input
                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(p => p.Trim())
                           .ToArray();

                var ladybugIndex = int.Parse(line[0]);
                var command = line.Skip(1).First();
                var movement = int.Parse(line[2]);

                if (ladybugIndex >= 0 && ladybugIndex < bugArray.Length && bugArray[ladybugIndex] != 0)
                {

                    switch (command)
                    {
                        case "right":
                            bugArray[ladybugIndex] = 0;
                            for (int i = ladybugIndex + movement; i < bugArray.Length; i += movement)
                            {
                                if (bugArray[i] != 1) 
                                {
                                    bugArray[i] = 1;
                                    break;
                                }
                            }
                            break;
                        case "left":
                            bugArray[ladybugIndex] = 0;
                            for (int i = ladybugIndex - movement; i >= 0 ; i-= movement)
                            {
                                if (bugArray[i] != 1)
                                {
                                    bugArray[i] = 1;
                                    break;
                                }
                            }
                            break;
                    };
                }

            }

            Console.WriteLine(string.Join(" ", bugArray));

        }
    }
}
