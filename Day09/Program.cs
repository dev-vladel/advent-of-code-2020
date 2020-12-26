using System;
using System.Collections.Generic;
using System.IO;

namespace Day9
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Constants.filePath);

            #region part one
            PartOne(input);
            #endregion

            #region part two

            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        public static void PartOne(string[] input)
        {
            // Variable which will store the correct sums
            List<long> preambleSum = new List<long>();

            // Determining all possible sums which indicate a valid number
            for (int i = 0; i < 24; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    preambleSum.Add(Convert.ToInt64(input[i]) + Convert.ToInt64(input[j]));
                }
            }

            // Start reading after the preamble
            for (int i = 25; i < input.Length; i++)
            {
                // Verify if the number is a weakness or not
                if (!preambleSum.Contains(Convert.ToInt64(input[i])))
                {
                    Console.WriteLine("The first weakness number is {0}", input[i]);
                    //break;
                }

                // Recalculate preamble sum
                preambleSum = new List<long>();

                for (int j = i - 24; j < i; j++)
                {
                    for (int k = i - 23; k < i + 1; k++)
                    {
                        preambleSum.Add(Convert.ToInt64(input[j]) + Convert.ToInt64(input[k]));
                    }
                }
            }
        }
    }
}
