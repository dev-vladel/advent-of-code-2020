using System;
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

            int rightToCheck = 0;
            int numberOfTrees = 0;
            int numberOfNoTrees = 0;
            
            foreach (var line in input)
            {
                int rightToCheckAux = rightToCheck;

                while (line.Length <= rightToCheckAux)
                {
                    rightToCheckAux -= line.Length;
                }

                if (line[rightToCheckAux] == '#')
                {
                    numberOfTrees++;
                }
                else
                {
                    numberOfNoTrees++;
                }

                rightToCheck += 3;
            }

            Console.WriteLine(string.Format("The number of trees encountered is {0}", numberOfTrees));

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
