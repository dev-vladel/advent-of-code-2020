using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
        public const string colour = "shiny gold";
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(Constants.filePath);

            IEnumerable<string> lines = input.Replace("\r", string.Empty)
               .Split('\n')
               .Reverse()
               .SkipWhile(string.IsNullOrEmpty)
               .Reverse()
               .Select(s => (string)Convert.ChangeType(s, typeof(string)));

            Dictionary<string, Dictionary<string, int>> parsedInput = lines.Select(x => Regex.Match(x, @"(.*) bags contain(?: (\d+ .*?) bags?[,.])*"))
                .ToDictionary(
                    x => x.Groups[1].Value,
                    x => x.Groups[2].Captures
                        .Select(y => y.Value.Split(' ', 2))
                        .ToDictionary(
                            z => z[1],
                            z => int.Parse(z[0])
                        )
                );

            bool Contains(string colour) => parsedInput[colour].ContainsKey(Constants.colour) || parsedInput[colour].Keys.Any(Contains);
            var result = parsedInput.Keys.Count(Contains).ToString();

            int MustContain(string colour) => parsedInput[colour].Sum(kvp => kvp.Value * (1 + MustContain(kvp.Key)));
            var resultTwo = MustContain(Constants.colour).ToString();

            Console.WriteLine(string.Format("The number of bags that can cointain at least one shiny gold bag is {0}", result));
            Console.WriteLine(string.Format("The number of individual required inside a single shiny gold bag is {0}", resultTwo));

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
