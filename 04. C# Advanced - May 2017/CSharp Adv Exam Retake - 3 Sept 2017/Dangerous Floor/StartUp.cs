namespace Dangerous_Floor
{
    using System;
    using System.Linq;
    public static class StartUp
    {
        private static char[,] board;
        public static void Main()
        {
            board = new char[8, 8];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(ch => char.Parse(ch)).ToArray();

                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = input[column];
                }
            }
            //PrintBoard(board);           

            var commands = Console.ReadLine().Trim();
            while (commands != "END")
            {
                var piece = commands[0];
                var initialRow = int.Parse(commands[1].ToString());
                var initialColumn = int.Parse(commands[2].ToString());
                var endRow = int.Parse(commands[4].ToString());
                var endColumn = int.Parse(commands[5].ToString());

                var firstCheck = CheckIfPieceExists(piece, initialRow, initialColumn);
                if (!firstCheck)
                {
                    Console.WriteLine("There is no such a piece!");
                    goto nextIteration;
                }

                var secondCheck = CheckMovekByPiece(piece, initialRow, initialColumn, endRow, endColumn);
                if (!secondCheck)
                {
                    Console.WriteLine("Invalid move!");                    
                    goto nextIteration;
                }

                var thirdCheck = IsPositionWithinBoard(endRow, endColumn, board.GetLength(0));
                if (!thirdCheck)
                {
                    Console.WriteLine("Move go out of board!");
                    goto nextIteration;
                }

                board[endRow, endColumn] = piece;
                board[initialRow, initialColumn] = 'x';

            nextIteration:
                commands = Console.ReadLine().Trim();
            }
        }
        private static bool CheckMovekByPiece(char pieace, int initialRow, int initialColumn, int endRow, int endColumn)
        {
            switch (pieace)
            {
                case 'K': return IsKingsMoveValid(initialRow, initialColumn, endRow, endColumn);
                case 'R': return IsRookMoveValid(initialRow, initialColumn, endRow, endColumn);
                case 'B': return IsBishopMoveValid(initialRow, initialColumn, endRow, endColumn);
                case 'Q': return IsQueenMoveValid(initialRow, initialColumn, endRow, endColumn);
                case 'P': return IsPawnMoveValid(initialRow, initialColumn, endRow, endColumn);
            }
            return true;
        }
        private static bool IsPawnMoveValid(int initialRow, int initialColumn, int endRow, int endColumn)
        {
            return endRow + 1 == initialRow && endColumn == initialColumn;
        }
        private static bool IsQueenMoveValid(int initialRow, int initialColumn, int endRow, int endColumn)
        {
            return IsBishopMoveValid(initialRow, initialColumn, endRow, endColumn) || 
                   IsRookMoveValid(initialRow, initialColumn, endRow, endColumn);
        }
        private static bool IsBishopMoveValid(int initialRow, int initialColumn, int endRow, int endColumn)
        {          //Up 
            //return endRow < initialRow && endColumn < initialColumn ||
            //       endRow < initialRow && endColumn > initialColumn ||
            //       //Down
            //       endRow > initialRow && endColumn < initialColumn ||
            //       endRow > initialRow && endColumn > initialColumn;

            return Math.Abs(initialRow - endRow) == Math.Abs(initialColumn - endColumn);
        }
        private static bool IsRookMoveValid(int initialRow, int initialColumn, int endRow, int endColumn)
        {          //Vertical 
            return endRow < initialRow && endColumn == initialColumn ||
                   endRow > initialRow && endColumn == initialColumn ||
                   //Horizontal
                   endRow == initialRow && endColumn < initialColumn ||
                   endRow == initialRow && endColumn > initialColumn;
        }           
        private static bool IsKingsMoveValid(int initialRow, int initialColumn, int endRow, int endColumn)
        {
                   //Up 
            return endRow + 1 == initialRow && endColumn + 1 == initialColumn ||
                   endRow + 1 == initialRow && endColumn == initialColumn ||
                   endRow + 1 == initialRow && endColumn - 1 == initialColumn ||
                   //Down
                   endRow - 1 == initialRow && endColumn - 1 == initialColumn ||
                   endRow - 1 == initialRow && endColumn == initialColumn ||
                   endRow - 1 == initialRow && endColumn + 1 == initialColumn ||
                   //Left and Right
                   endRow == initialRow && endColumn + 1 == initialColumn ||
                   endRow == initialRow && endColumn - 1 == initialColumn;
        }
        private static bool CheckIfPieceExists(char piece, int initialRow, int initialColumn)
        {
            if (board[initialRow, initialColumn].Equals(piece))
            {
                return true;
            }

            return false;
        }
        private static bool IsPositionWithinBoard(int endRow, int endColumn, int boardSize)
        {
            return endRow >= 0 && endRow < boardSize && endColumn >= 0 && endColumn < boardSize;
        }

        private static void PrintBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    Console.Write(board[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}