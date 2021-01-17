using System;
using System.Collections.Generic;
using System.IO;

namespace Day9
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    public class Direction
    {
        public int currentDirection { get; set; }
        public int eastWest { get; set; }
        public int northSouth { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Constants.filePath);

            #region part one

            var direction = new Direction()
            {
                // 1 is East / 2 is South / 3 is West / 4 is North
                currentDirection = 1,
                // Started positions/coordinates for each axis
                eastWest = 0,
                northSouth = 0
            };

            foreach (var line in input)
            {
                // Decipher the instruction
                string word = line.Substring(0, 1);
                int number = Int32.Parse(line.Substring(1));

                PartOneExecuteInstruction(word, number, direction);
            }

            Console.WriteLine("eastWest {0} / northSouth {1}", direction.eastWest, direction.northSouth);
            Console.WriteLine("The Manhattan distance is {0}", Math.Abs(direction.eastWest) + Math.Abs(direction.northSouth));

            #endregion

            #region part two

            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        static void PartOneExecuteInstruction(string word, int number, Direction direction)
        {
            switch (word)
            {
                case "N":
                    direction.northSouth = direction.northSouth + number;
                    break;
                case "S":
                    direction.northSouth = direction.northSouth - number;
                    break;
                case "E":
                    direction.eastWest = direction.eastWest + number;
                    break;
                case "W":
                    direction.eastWest = direction.eastWest - number;
                    break;
                case "L":
                    if (number == 90)
                    {
                        if (direction.currentDirection == 1) direction.currentDirection = 4;
                        else if (direction.currentDirection == 2) direction.currentDirection = 1;
                        else if (direction.currentDirection == 3) direction.currentDirection = 2;
                        else if (direction.currentDirection == 4) direction.currentDirection = 3;
                    }
                    else if (number == 180)
                    {
                        if (direction.currentDirection == 1) direction.currentDirection = 3;
                        else if (direction.currentDirection == 2) direction.currentDirection = 4;
                        else if (direction.currentDirection == 3) direction.currentDirection = 1;
                        else if (direction.currentDirection == 4) direction.currentDirection = 2;
                    }
                    else if (number == 270)
                    {
                        if (direction.currentDirection == 1) direction.currentDirection = 2;
                        else if (direction.currentDirection == 2) direction.currentDirection = 3;
                        else if (direction.currentDirection == 3) direction.currentDirection = 4;
                        else if (direction.currentDirection == 4) direction.currentDirection = 1;
                    }
                    break;
                case "R":
                    if (number == 90)
                    {
                        if (direction.currentDirection == 1) direction.currentDirection = 2;
                        else if (direction.currentDirection == 2) direction.currentDirection = 3;
                        else if (direction.currentDirection == 3) direction.currentDirection = 4;
                        else if (direction.currentDirection == 4) direction.currentDirection = 1;
                    }
                    else if (number == 180)
                    {
                        if (direction.currentDirection == 1) direction.currentDirection = 3;
                        else if (direction.currentDirection == 2) direction.currentDirection = 4;
                        else if (direction.currentDirection == 3) direction.currentDirection = 1;
                        else if (direction.currentDirection == 4) direction.currentDirection = 2;
                    }
                    else if (number == 270)
                    {
                        if (direction.currentDirection == 1) direction.currentDirection = 4;
                        else if (direction.currentDirection == 2) direction.currentDirection = 1;
                        else if (direction.currentDirection == 3) direction.currentDirection = 2;
                        else if (direction.currentDirection == 4) direction.currentDirection = 3;
                    }
                    break;
                case "F":
                    if (direction.currentDirection == 1) direction.eastWest = direction.eastWest + number;
                    else if (direction.currentDirection == 2) direction.northSouth = direction.northSouth - number;
                    else if (direction.currentDirection == 3) direction.eastWest = direction.eastWest - number;
                    else if (direction.currentDirection == 4) direction.northSouth = direction.northSouth + number;
                    break;
                default:
                    break;
            }
        }
    }
}
