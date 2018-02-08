namespace Knight_Game
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var boardSize = int.Parse(Console.ReadLine());
            char[][] board = new char[boardSize][];

            for (int counter = 0; counter < boardSize; counter++)
            {
                board[counter] = Console.ReadLine().ToCharArray();
            }

            int maxRow = 0;
            int maxColumn = 0;
            int maxAttackedPositions = 0;
            int countOfremovedKnights = 0;

            do
            {
                if (maxAttackedPositions > 0)
                {
                    board[maxRow][maxColumn] = '0';
                    maxAttackedPositions = 0;
                    countOfremovedKnights++;
                }

                int currentAttackPositions = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    for (int column = 0; column < boardSize; column++)
                    {
                        if (board[row][column] == 'K')
                        {
                            currentAttackPositions = CalculateAttackedPositions(row, column, board);

                            if (currentAttackPositions > maxAttackedPositions)
                            {
                                maxAttackedPositions = currentAttackPositions;
                                maxRow = row;
                                maxColumn = column;
                            }
                        }
                    }
                }

            } while (maxAttackedPositions > 0);

            Console.WriteLine(countOfremovedKnights);
        }

        private static int CalculateAttackedPositions(int row, int column, char[][] board)
        {
            var currentAttackPositions = 0;
            if (IsPositionattacked(row - 2, column - 1, board)) currentAttackPositions++;
            if (IsPositionattacked(row - 2, column + 1, board)) currentAttackPositions++;
            if (IsPositionattacked(row - 1, column - 2, board)) currentAttackPositions++;
            if (IsPositionattacked(row - 1, column + 2, board)) currentAttackPositions++;

            if (IsPositionattacked(row + 1, column - 2, board)) currentAttackPositions++;
            if (IsPositionattacked(row + 1, column + 2, board)) currentAttackPositions++;
            if (IsPositionattacked(row + 2, column - 1, board)) currentAttackPositions++;
            if (IsPositionattacked(row + 2, column + 1, board)) currentAttackPositions++;

            return currentAttackPositions;
        }

        private static bool IsPositionattacked(int row, int column, char[][] board)
        {
            return IsPositionWithinBoard(row, column, board[0].Length) && board[row][column] == 'K';
        }

        private static bool IsPositionWithinBoard(int row, int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }
    }
}
