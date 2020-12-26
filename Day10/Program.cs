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

            #region part one
            var parsedInput = input.Replace("\r", string.Empty)
                .Split('\n')
                .Reverse()
                .SkipWhile(string.IsNullOrEmpty)
                .Reverse()
                .Select(s => (long)Convert.ChangeType(s, typeof(long)))
                .ToList();

            Console.WriteLine("One's multiplied by Three's is {0}", PartOne(parsedInput));
            #endregion

            #region part two

            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        public static int PartOne(List<long> input)
        {
            input.Add(0);
            input.Add(input.Max() + 3);

            var differences = input
                .OrderBy(x => x)
                .Pairwise((a, b) => b - a)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());

            Console.WriteLine("One's: {0} | Three's: {1}", differences[1], differences[3]);

            return (differences[1] * differences[3]);
        }
    }
}
