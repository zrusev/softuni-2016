using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Jedi_Galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var galaxySize =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var rows = galaxySize[0];
            var columns = galaxySize[1];
            var galaxy = new int[rows][];

            var counter = 0;

            for (int r = 0; r < rows; r++)
            {
                galaxy[r] = new int[columns];
                for (int c = 0; c < columns; c++)
                {
                    galaxy[r][c] = counter;
                    counter++;
                }
            }

            long ivoScore = 0;
            var turn = Console.ReadLine();
            while (turn != "Let the Force be with you")
            {

                var ivoTurn = turn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                var ivoRow = ivoTurn[0];
                var ivoCol = ivoTurn[1];


                // calibrate rows if col < 0
                if (ivoCol < 0)
                {
                    var deltaIvo = 0 - ivoCol;
                    ivoCol = 0;
                    ivoRow -= deltaIvo;
                }

                turn = Console.ReadLine();
                if (turn != "Let the Force be with you")
                {
                    var evilTurn = turn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();

                    var evilRow = evilTurn[0];
                    var evilCol = evilTurn[1];


                    // calibrate rows if col >= galaxy columns
                    if (evilCol >= columns)
                    {
                        var deltaEvil = evilCol - (columns - 1);
                        evilCol = columns - 1;
                        evilRow -= deltaEvil;
                    }



                    // evil destroying the stars
                    while (evilRow >= 0 && evilRow < rows && evilCol >= 0 && evilCol < columns)
                    {
                        galaxy[evilRow][evilCol] = 0;
                        evilRow--;
                        evilCol--;
                    }

                    // gather points
                    while (ivoRow >= 0 && ivoRow < rows && ivoCol >= 0 && ivoCol < columns)
                    {
                        ivoScore += galaxy[ivoRow][ivoCol];
                        ivoCol++;
                        ivoRow--;
                    }


                    // print matrix
                    //for (int r = 0; r < rows; r++)
                    //{
                    //    Console.WriteLine(string.Join(" ",galaxy[r]));
                    //}
                }
                turn = Console.ReadLine();
            }

            Console.WriteLine(ivoScore);
        }
    }
}