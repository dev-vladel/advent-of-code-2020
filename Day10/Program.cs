using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

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
            string input = File.ReadAllText(Constants.filePath);

            // Parsing the input to a list
            var parsedInput = input.Replace("\r", string.Empty)
                .Split('\n')
                .Reverse()
                .SkipWhile(string.IsNullOrEmpty)
                .Reverse()
                .Select(s => (long)Convert.ChangeType(s, typeof(long)))
                .ToList();

            #region part one
            Console.WriteLine("One's multiplied by Three's is {0}", PartOne(parsedInput));
            #endregion

            #region part two
            Console.WriteLine("The number of available chains are {0}", PartTwo(parsedInput));
            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        public static int PartOne(List<long> input)
        {
            // Adding the base jolt
            input.Add(0);
            // Adding the maximum jolt
            input.Add(input.Max() + 3);

            // Using MoreLINQ nuget for easier solution
            var differences = input
                .OrderBy(x => x)
                .Pairwise((a, b) => b - a)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());

            Console.WriteLine("One's: {0} | Three's: {1}", differences[1], differences[3]);

            return (differences[1] * differences[3]);
        }

        public static string PartTwo(List<long> input)
        {
            // Adding the base jolt
            input.Add(0);
            // Adding the maximum jolt
            input.Add(input.Max() + 3);
            // Sorting the input
            input.Sort();

            Dictionary<int, long> memoize = new Dictionary<int, long>()
            {
                [input.Count - 1] = 1
            };

            for (int k = input.Count - 2; k >= 0; k--)
            {
                long connections = 0L;

                for (var connected = k + 1; connected < input.Count && input[connected] - input[k] <= 3; connected++)
                {
                    connections += memoize[connected];
                }

                memoize[k] = connections;
            }

            return memoize[1].ToString();
        }
    }
}
