namespace _03.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Array_Manipulator
    {
        static void Main()
        {
            List<int> inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> containsPositions = new List<int>();

            for (int i = 0; i < i + 1; i++)
            {



                List<string> commandAndValues = Console.ReadLine().Split(' ').ToList();
                if (commandAndValues[0] == "add")
                {
                    inputArray = AddCmd(inputArray, commandAndValues);
                }
                else if (commandAndValues[0] == "remove")
                {
                    inputArray = RemoveIndex(inputArray, commandAndValues);
                }
                else if (commandAndValues[0] == "addMany")
                {
                    inputArray = AddManyCmd(inputArray, commandAndValues);

                }
                else if (commandAndValues[0] == "shift")
                {

                    inputArray = ShiftCmd(inputArray, commandAndValues);

                }
                else if (commandAndValues[0] == "sumPairs")
                {
                    inputArray = SumCmd(inputArray, commandAndValues);

                }

                else if (commandAndValues[0] == "contains")
                {
                    int solution = 0;
                    solution = Contains(inputArray, commandAndValues);
                    containsPositions.Add(solution);

                }
                else if (commandAndValues[0] == "print")
                {
                    for (int num = 0; num < containsPositions.Count; num++)
                    {
                        Console.WriteLine(containsPositions[num]);
                    }
                    var result = String.Join(", ", inputArray);
                    Console.WriteLine("[" + result + "]");
                    break;
                }

            }

        }
        public static List<int> SumCmd(List<int> input, List<string> cmd)
        {
            List<int> solution = new List<int>();
            for (int i = 1; i < input.Count; i += 2)
            {
                solution.Add(input[i - 1] + input[i]);
            }
            if (input.Count % 2 != 0)
            {
                solution.Add(input[input.Count - 1]);
            }
            return solution;

        }

        public static List<int> AddCmd(List<int> input, List<string> cmd)
        {
            List<int> newValue = new List<int>();

            newValue = input;
            newValue.Insert(int.Parse(cmd[1]), int.Parse(cmd[2]));
            return newValue;
        }
        public static List<int> ShiftCmd(List<int> input, List<string> cmd)
        {
            int positions = int.Parse(cmd[1]);
            List<int> newValue = new List<int>(input.Count);
            for (int shiftPos = 0; shiftPos < input.Count; shiftPos++)
            {
                newValue.Add(input[(positions + shiftPos) % input.Count]);
            }
            return newValue;
        }
        public static List<int> RemoveIndex(List<int> input, List<string> cmd)
        {
            List<int> newValue = new List<int>();

            newValue = input;
            newValue.RemoveAt(int.Parse(cmd[1]));
            return newValue;
        }
        public static int Contains(List<int> input, List<string> cmd)
        {
            int newValue = -1;

            for (int temp = 0; temp < input.Count; temp++)
            {
                if (int.Parse(cmd[1]) == input[temp])
                {
                    newValue = temp;
                    break;
                }
            }

            return newValue;
        }
        public static List<int> AddManyCmd(List<int> input, List<string> cmd)
        {
            List<int> newValue = new List<int>();
            List<int> valuesForInsert = new List<int>();
            for (int i = 2; i < cmd.Count; i++)
            {
                valuesForInsert.Add(int.Parse(cmd[i]));
            }
            newValue = input;
            newValue.InsertRange(int.Parse(cmd[1]), valuesForInsert);

            return newValue;
        }
    }
}