using System;
using System.IO;

namespace Day6
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // I've added another line to the input.txt file because File.ReadAllLines ignores the last line if its whitespace or empty
            string[] input = File.ReadAllLines(Constants.filePath);

            // For first part we need the sum and a vector for appearances
            int sum = 0;
            int[] appearances = new int[130];

            int rowLength = 0;
            int sumCommon = 0;

            foreach (var line in input)
            {
                // Part 1 - If a character appears at least once we increment
                foreach (var character in line)
                {
                    appearances[character]++;
                }

                // Part 2 - An answer should appears as many times as how many rows does a group have
                if (!string.IsNullOrEmpty(line))
                {
                    rowLength++;
                }

                // When we find an empty line we know it's the end of the group
                if (string.IsNullOrEmpty(line))
                {
                    foreach(var number in appearances)
                    {
                        // Part 1 - If a number appears at least once we increment
                        if (number != 0)
                        {
                            sum++;
                        }

                        // Part 2 - If the number of appearances matches the row number we increment
                        if (number == rowLength)
                        {
                            sumCommon++;
                        }
                    }

                    // Reinitialize control variables for each new group
                    appearances = new int[130];
                    rowLength = 0;
                }
            }

            Console.WriteLine(string.Format("The sum of all questions is {0}", sum));
            Console.WriteLine(string.Format("The sum of all common questions is {0}", sumCommon));

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
