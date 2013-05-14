using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonBoobsGame
{
    class Engine
    {
        public static void ProcessGame(string temp)
        {
            string[,] topFive = TopFive.topFive;
            BalloonBoobs engine = new BalloonBoobs();

            int userMoves = 0;

            byte rows = 5;
            byte cols = 10;
            byte[,] matrix = engine.gen(rows, cols);
            engine.printMatrix(matrix);

            switch (temp)
            {
                case "RESTART":
                    matrix = engine.gen(5, 10);
                    engine.printMatrix(matrix);
                    userMoves = 0;
                    break;
                case "TOP":
                    engine.PrintTopFiveChart(topFive);
                    break;
                default:
                    if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                    {
                        int userRow, userColumn;
                        userRow = int.Parse(temp[0].ToString());
                        if (userRow > 4)
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            return;
                        }
                        userColumn = int.Parse(temp[2].ToString());

                        if (engine.change(matrix, userRow, userColumn))
                        {
                            Console.WriteLine("cannot pop missing ballon!");
                            return;
                        }
                        userMoves++;
                        if (engine.MakeAMove(matrix))
                        {
                            Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                            if (engine.IsPlayerResultInTopFive(topFive, userMoves))
                            {
                                engine.PrintTopFiveChart(topFive);
                            }
                            else
                            {
                                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                            }
                            matrix = engine.gen(5, 10);
                            userMoves = 0;
                        }
                        engine.printMatrix(matrix);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input ! Try Again ! ");
                        break;
                    }
            }
        }
    }
}
