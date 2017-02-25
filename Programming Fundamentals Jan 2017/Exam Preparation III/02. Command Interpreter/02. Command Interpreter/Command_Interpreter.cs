namespace _02.Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Command_Interpreter
    {
        public static void Main()
        {
            List<string> array = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] commandParams = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = commandParams[0];

                switch (command)
                {
                    case "reverse":
                        int reverseStart = int.Parse(commandParams[2]);
                        int reverseCount = int.Parse(commandParams[4]);

                        if (IsValid(array, reverseStart, reverseCount))
                        {
                            //Reverse(array, reverseStart, reverseCount);
                            array.Reverse(reverseStart, reverseCount);
                        }
                        else
                        { 
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;

                    case "sort":
                        int sortStart = int.Parse(commandParams[2]);
                        int sortCount = int.Parse(commandParams[4]);

                        if (IsValid(array, sortStart, sortCount))
                        {
                            Sort(array, sortStart, sortCount);
                            //array.Sort(sortStart, sortCount, StringComparer.InvariantCulture);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;

                    case "rollLeft":
                        int rollLeftCount = int.Parse(commandParams[1]);

                        if (rollLeftCount >= 0)
                        {
                            RollLeft(array, rollLeftCount); 
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;

                    case "rollRight":
                        int rollRightCount = int.Parse(commandParams[1]);

                        if (rollRightCount >= 0)
                        {
                            RollRight(array, rollRightCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                }


                inputLine = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", array));
            
        }

        private static void RollRight(List<string> array, int rollRightCount)
        {
            rollRightCount = rollRightCount % array.Count;
            for (int i = 0; i < rollRightCount; i++)
            {
                string lastEleme = array[array.Count - 1];
                array.RemoveAt(array.Count - 1);
                array.Insert(0, lastEleme);
            }
        }

        private static void RollLeft(List<string> array, int rollLeftCount)
        {
            rollLeftCount = rollLeftCount % array.Count;
            for (int i = 0; i < rollLeftCount; i++)
            {
                string firstElem = array[0];
                for (int j = 0; j < array.Count - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Count - 1] = firstElem;
            }
        }

        private static void Sort(List<string> array, int sortStart, int sortCount)
        {
            List<string> resultArray = array.Skip(sortStart).Take(sortCount).OrderBy(x => x).ToList();
            array.RemoveRange(sortStart, sortCount);
            array.InsertRange(sortStart, resultArray);
        }

        private static void Reverse(List<string> array, int start, int count)
        {
            List<string> resultArray = array.Skip(start).Take(count).Reverse().ToList();
            array.RemoveRange(start, count);
            array.InsertRange(start, resultArray);
        }

        private static bool IsValid(List<string> array, int start, int count)
        {
            if (start >= 0 && start < array.Count && count >= 0 && (start + count) <= array.Count)
            {
                return true;
            }

            return false;
        }
    }
}
