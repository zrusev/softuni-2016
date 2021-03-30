namespace Snakes
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static char[] currentSnake;
        private static HashSet<string> visitedCells = new HashSet<string>();
        private static HashSet<string> result = new HashSet<string>();
        private static HashSet<string> allPossibleSnakes = new HashSet<string>();
        private static int AllPossibleRotations = 4;

        private static void GenerateSnake(int index, int row, int column, char direction)
        {
            if (index >= currentSnake.Length)
            {
                MarkSnake();
            }
            else
            {
                var cell = $"{row} {column}";

                if (!visitedCells.Contains(cell))
                {
                    currentSnake[index] = direction;
                    visitedCells.Add(cell);

                    GenerateSnake(index + 1, row, column + 1, 'R');
                    GenerateSnake(index + 1, row + 1, column, 'D');
                    GenerateSnake(index + 1, row, column - 1, 'L');
                    GenerateSnake(index + 1, row - 1, column, 'U');

                    visitedCells.Remove(cell);
                }
            }
        }

        private static void MarkSnake()
        {
            var normalSnake = new string(currentSnake);

            if (allPossibleSnakes.Contains(normalSnake))
            {
                return;
            }

            result.Add(normalSnake);

            var flippedSnake = Flip(normalSnake);
            var reversedSnake = Reverse(normalSnake);
            var reversedFlipSnake = Flip(reversedSnake);

            for (int i = 0; i < AllPossibleRotations; i++)
            {
                allPossibleSnakes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                allPossibleSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                allPossibleSnakes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                allPossibleSnakes.Add(reversedFlipSnake);
                reversedFlipSnake = Rotate(reversedFlipSnake);
            }
        }

        private static string Rotate(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'L'; break;
                    case 'L': newSnake[i] = 'U'; break;
                    case 'U': newSnake[i] = 'R'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - 1] = snake[i];
            }

            return new string(newSnake);
        }

        private static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'U'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            currentSnake = new char[n];

            GenerateSnake(0, 0, 0, 'S');

            foreach (var snake in result)
            {
                Console.WriteLine(snake);
            }

            Console.WriteLine($"Snakes count = {result.Count}");
        }
    }
}
