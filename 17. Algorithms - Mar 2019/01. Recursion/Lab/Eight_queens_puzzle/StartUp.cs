using System;
using System.Collections.Generic;

namespace Eight_queens_puzzle
{
    public class StartUp: EightQueens
    {
        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedColumns = new HashSet<int>();
        public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        public static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PutQueens(0);
        }

        static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttachkedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttachkedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(row + col);
            chessboard[row, col] = false;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(row + col);
            chessboard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied =
                attackedRows.Contains(row) ||
                attackedColumns.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(row + col);

            return !positionOccupied;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Console.Write(chessboard[row, col] ? "* ": "- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            solutionsFound++;
        }
    }

    public class EightQueens 
    {
        public const int Size = 8;
        public static bool[,] chessboard = new bool[Size, Size];
        public static int solutionsFound = 0;
    }
}
