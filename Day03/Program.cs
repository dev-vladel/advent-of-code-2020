using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Constants.filePath);

            // Use tuples here because of issues with const declaration
            var slopes = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2)
            };

            long multiplicationOfTrees = 1;

            foreach (var slope in slopes)
            {
                int rightToCheck = 0;
                int downToCheck = slope.Item2;
                int numberOfTrees = 0;

                foreach (var line in input)
                {
                    int rightToCheckAux = rightToCheck;

                    // if the slope is 2 and the current moves of down is 1 skip line
                    if (downToCheck == 1 && slope.Item2 == 2)
                    {
                        downToCheck = slope.Item2;
                        continue;
                    }

                    // traverse line pattern until is in bounds of index
                    while (line.Length <= rightToCheckAux)
                    {
                        rightToCheckAux -= line.Length;
                    }

                    if (line[rightToCheckAux] == '#')
                    {
                        numberOfTrees++;
                    }

                    rightToCheck += slope.Item1;
                    downToCheck--;
                }

                multiplicationOfTrees = multiplicationOfTrees * numberOfTrees;
                Console.WriteLine(string.Format("The number of trees encountered is {0}", numberOfTrees));
            }

            Console.WriteLine(string.Format("The mulltiplication of trees encountered is {0}", multiplicationOfTrees));


            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
