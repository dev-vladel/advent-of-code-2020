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

            int sum = 0;
            int[] appearances = new int[130];

            foreach (var line in input)
            {
                foreach (var character in line)
                {
                    appearances[character]++;
                }

                if (string.IsNullOrEmpty(line))
                {
                    foreach(var number in appearances)
                    {
                        if (number != 0)
                        {
                            sum++;
                        }
                    }

                    appearances = new int[130];
                }
            }

            Console.WriteLine(string.Format("The sum of all questions is {0}", sum));

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
