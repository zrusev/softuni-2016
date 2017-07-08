using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Radio_Bunn
{
    class Radio_Bunn
    {
        static void Main()
        {
            int[] dimension = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[][] area = new char[dimension[0]][];

            for (int row = 0; row < area.Length; row++)
            {
                area[row] = Console.ReadLine()
                    .ToCharArray();
            }

            string path = Console.ReadLine();
            int playerRow = GetPlayerRow(area);
            int playerCol = GetPlayerCol(area);
            bool isOut = false;
            bool isDead = false;

            for (int i = 0; i < path.Length; i++)
            {
                char currentDirection = path[i];

                switch (currentDirection)
                {
                    case 'U':
                        if (playerRow - 1 < 0)
                        {
                            isOut = true;
                        }
                        else if (area[playerRow - 1][playerCol] == 'B')
                        {
                            isDead = true;
                            area[playerRow][playerCol] = '.';
                            playerRow--;
                        }
                        else
                        {
                            area[playerRow - 1][playerCol] = 'P';
                            area[playerRow][playerCol] = '.';
                            playerRow--;
                            SpreadBunnies(area);
                        }
                        break;
                    case 'D':
                        if (playerRow + 1 >= area.Length)
                        {
                            isOut = true;
                        }
                        else if (area[playerRow + 1][playerCol] == 'B')
                        {
                            isDead = true;
                            area[playerRow][playerCol] = '.';
                            playerRow++;
                        }
                        else
                        {
                            area[playerRow + 1][playerCol] = 'P';
                            area[playerRow][playerCol] = '.';
                            playerRow++;
                            SpreadBunnies(area);
                        }
                        break;
                    case 'L':
                        if (playerCol - 1 < 0)
                        {
                            isOut = true;
                        }
                        else if (area[playerRow][playerCol - 1] == 'B')
                        {
                            isDead = true;
                            area[playerRow][playerCol] = '.';
                            playerCol--;
                        }
                        else
                        {
                            area[playerRow][playerCol - 1] = 'P';
                            area[playerRow][playerCol] = '.';
                            playerCol--;
                            SpreadBunnies(area);
                        }
                        break;
                    case 'R':
                        if (playerCol + 1 >= area[playerRow].Length)
                        {
                            isOut = true;
                        }
                        else if (area[playerRow][playerCol + 1] == 'B')
                        {
                            isDead = true;
                            area[playerRow][playerCol] = '.';
                            playerCol++;
                        }
                        else
                        {
                            area[playerRow][playerCol + 1] = 'P';
                            area[playerRow][playerCol] = '.';
                            playerCol++;
                            SpreadBunnies(area);
                        }
                        break;
                }

                if (isOut)
                {
                    area[playerRow][playerCol] = '.';
                    SpreadBunnies(area);
                    PrintArea(area);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }

                if (isDead)
                {
                    SpreadBunnies(area);
                    PrintArea(area);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void PrintArea(char[][] area)
        {
            foreach (var row in area)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void SpreadBunnies(char[][] area)
        {
            List<int> bunnyRows = GetBunnyRows(area);
            List<int> bunnyCols = GetBunnyCols(area);

            for (int i = 0; i < bunnyRows.Count; i++)
            {
                int row = bunnyRows[i];
                int col = bunnyCols[i];

                if (row > 0) //Spread up
                {
                    area[row - 1][col] = 'B';
                }

                if (row < area.Length - 1) //Spread down
                {
                    area[row + 1][col] = 'B';
                }

                if (col > 0) //Spread left
                {
                    area[row][col - 1] = 'B';
                }

                if (col < area[row].Length - 1) //Spread right
                {
                    area[row][col + 1] = 'B';
                }
            }
        }

        private static List<int> GetBunnyCols(char[][] area)
        {
            List<int> cols = new List<int>();

            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'B')
                    {
                        cols.Add(col);
                    }
                }
            }

            return cols;
        }

        private static List<int> GetBunnyRows(char[][] area)
        {
            List<int> rows = new List<int>();

            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'B')
                    {
                        rows.Add(row);
                    }
                }
            }

            return rows;
        }

        private static int GetPlayerCol(char[][] area)
        {
            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'P')
                    {
                        return col;
                    }
                }
            }

            return 0;
        }

        private static int GetPlayerRow(char[][] area)
        {
            for (int row = 0; row < area.Length; row++)
            {
                for (int col = 0; col < area[row].Length; col++)
                {
                    if (area[row][col] == 'P')
                    {
                        return row;
                    }
                }
            }

            return 0;
        }
    }
}