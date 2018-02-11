using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace Problem02
{
    using System;
    public class StartUp
    {
        private static char[][] board;
        private static bool IsNikoDead = false;
        private static bool IsSamDead = false;
        public static void Main()
        {
            Func<int, bool> IsElementBOnThisLine = r => board[r].Contains('b') == true;

            var rows = int.Parse(Console.ReadLine());
            board = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                board[i] = line;
            }

            var samMoves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < samMoves.Length; i++)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    //Enemies move
                    if (board[row].Contains('b') || board[row].Contains('d'))
                    {
                        MoveEnemy(IsElementBOnThisLine(row), row);

                        //kill Sam if here
                        if (board[row].Contains('S'))
                        {
                            var samColumnIndex = ReturnElementColumn('S', row);

                            // b on the line
                            if (IsElementBOnThisLine(row))
                            {
                                var bColumnIndes = ReturnElementColumn('b', row);

                                if (bColumnIndes < samColumnIndex)
                                {
                                    Console.WriteLine($"Sam died at {row}, {samColumnIndex}");
                                    board[row][samColumnIndex] = 'X';
                                    IsSamDead = true;
                                    break;
                                }                                
                            }
                            else //d on the line
                            {
                                var dColumnIndex = ReturnElementColumn('d', row);

                                if (dColumnIndex > samColumnIndex)
                                {
                                    Console.WriteLine($"Sam died at {row}, {samColumnIndex}");
                                    board[row][samColumnIndex] = 'X';
                                    IsSamDead = true;
                                    break;
                                }                                
                            }
                        }
                    }
                }

                if (IsSamDead)
                {
                    break;
                }

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    //Sam moves
                    if (board[row].Contains('S'))
                    {
                        var command = samMoves[i];
                        var elementColumnPosition = ReturnElementColumn('S', row);
                        MoveSam(command, row, elementColumnPosition);
                        break;
                    }
                }

                if (IsNikoDead)
                {
                    break;
                }

            }

            //Print board
            PrintBoard();
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(string.Empty, board[row]));
            }
        }
        private static void MoveSam(char command, int row, int elementColumnPosition)
        {

            //move not disturbed
            switch (command)
            {
                case 'U':
                    board[row][elementColumnPosition] = '.';
                    CheckForN(row - 1);
                    board[row - 1][elementColumnPosition] = 'S';                    
                    break;
                case 'D':
                    board[row][elementColumnPosition] = '.';
                    CheckForN(row + 1);
                    board[row + 1][elementColumnPosition] = 'S';                    
                    break;
                case 'L':
                    board[row][elementColumnPosition] = '.';
                    CheckForN(row);
                    board[row][elementColumnPosition - 1] = 'S';
                    break;
                case 'R':
                    board[row][elementColumnPosition] = '.';
                    CheckForN(row);
                    board[row][elementColumnPosition + 1] = 'S';
                    break;
                default:
                    break;
            }
        }

        private static void CheckForN(int row)
        {
            if (board[row].Contains('N'))
            {
                var nColummnPosition = ReturnElementColumn('N', row);
                board[row][nColummnPosition] = 'X';
                Console.WriteLine("Nikoladze killed!");
                IsNikoDead = true;
            }
        }

        private static int ReturnElementColumn(char element, int row)
        {
            var columnIndex = 0;
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[row][col].Equals(element))
                {
                    columnIndex = col;
                    break;
                }
            }
            return columnIndex;
        }

        private static void MoveEnemy(bool isElementBOnThisLine,int row)
        {
            var elementColumnPosition = 0;

            //move b
            if (isElementBOnThisLine)
            {
                //get column
                elementColumnPosition = ReturnElementColumn('b', row);

                //movement
                board[row][elementColumnPosition] = '.';

                //flipper
                if (elementColumnPosition == board[row].Length - 1)
                {
                    board[row][elementColumnPosition] = 'd';
                    return;
                }
               
                board[row][elementColumnPosition + 1] = 'b';                
            }
            else //move d
            {
                //get column
                elementColumnPosition = ReturnElementColumn('d', row);

                //movement
                board[row][elementColumnPosition] = '.';
                
                //flipper
                if (elementColumnPosition == 0)
                {
                    board[row][elementColumnPosition] = 'b';
                    return;
                }
                board[row][elementColumnPosition - 1] = 'd';
            }
        }
    }
}



