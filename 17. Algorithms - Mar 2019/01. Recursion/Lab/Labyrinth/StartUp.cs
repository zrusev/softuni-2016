namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static char[,] labyrinth;
        static List<char> path = new List<char>();

        public static void Main()
        {
            ReadFromConsole();
            Solve(0, 0, 'S');
        }

        private static void Solve(int row, int col, char direction)
        {
            if (IsOutsideOfLabyrinth(row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintSolution();
            }
            else if(IsPassable(row, col))
            {
                labyrinth[row, col] = 'x';

                Solve(row + 1, col, 'D'); //Down
                Solve(row - 1, col, 'U'); //Up
                Solve(row, col + 1, 'R'); //Right
                Solve(row, col - 1, 'L'); //Left

                labyrinth[row, col] = '-';
            }

            path.RemoveAt(path.Count - 1);

        }

        private static bool IsPassable(int row, int col)
        {
            if (labyrinth[row, col] == 'x')
            {
                return false;
            }

            if (labyrinth[row, col] == '*')
            {
                return false;
            }

            return true;
        }

        private static void PrintSolution()
        {
            Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row, col] == 'e';    
        }

        private static bool IsOutsideOfLabyrinth(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0))
            {
                return true;
            }

            if (col < 0 || col >= labyrinth.GetLength(1))
            {
                return true;
            }

            return false;

        }

        private static void ReadFromConsole()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = currentLine[col];
                }
            }
        }
    }
}
