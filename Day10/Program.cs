using System;
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
            long[] orderedInput = new long[33];
            int index = 1;
            orderedInput[0] = 0;

            long aux = 0;

            foreach (var line in input)
            {
                orderedInput[index] = Convert.ToInt64(line);
                index++;
            }

            for (int i = 0; i < orderedInput.Length - 1; i++)
            {
                for (int j = i + 1; j < orderedInput.Length; j++)
                {
                    if (orderedInput[i] > orderedInput[j])
                    {
                        aux = Convert.ToInt64(orderedInput[i]);
                        orderedInput[i] = orderedInput[j];
                        orderedInput[j] = aux;
                    }
                }
            }

            orderedInput[index] = orderedInput[index - 1] + 3;

            //orderedInput[index] = orderedInput[index - 1] + 3;

            PartOne(orderedInput);

            #endregion

            #region part two

            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        public static void PartOne(long[] input)
        {
            int ones = 0;
            int twos = 0;
            int threes = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                switch (input[i] - input[i+1])
                {
                    case -1:
                        ones++;
                        break;
                    case -2:
                        twos++;
                        break;
                    case -3:
                        threes++;
                        break;
                }
            }

            Console.WriteLine("One's: {0} | Two's: {1} | Three's {2}", ones, twos, threes);
            Console.WriteLine("One's multiplied by Three's is {0}", ones * threes);
        }
    }
}
