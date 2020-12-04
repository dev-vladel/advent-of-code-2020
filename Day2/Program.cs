using System;
using System.IO;
using System.Linq;

namespace Day2
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

            // Part 1
            int numberOfValidPasswords = 0;

            foreach (var line in input)
            {
                // Split the rules and the password
                string[] lineSplit = line.Split(':');

                // Split the occurrences from the letter they apply to
                string[] firstSplit = lineSplit[0].Split(' ');

                // Split the min and max occurrences and parse them
                string[] occurrencesSplit = firstSplit[0].Split('-');
                int minOccurrences = Int32.Parse(occurrencesSplit[0]);
                int maxOccurences = Int32.Parse(occurrencesSplit[1]);

                // Retain the letter that needs checked
                char[] letterToCheck = firstSplit[1].ToCharArray();

                int letterCount = lineSplit[1].Count(c => c == letterToCheck[0]);

                if (minOccurrences <= letterCount && maxOccurences >= letterCount)
                {
                    numberOfValidPasswords++;
                }
            }

            Console.WriteLine("The number of valid passwords is {0}", numberOfValidPasswords);

            // Part 2
            numberOfValidPasswords = 0;

            foreach (var line in input)
            {
                // Split the rules and the password
                string[] lineSplit = line.Split(':');

                // Split the occurrences from the letter they apply to
                string[] firstSplit = lineSplit[0].Split(' ');

                // Split the first and second occurrences and parse themtaking in consideration index zero
                string[] occurrencesSplit = firstSplit[0].Split('-');
                int firstPosition = Int32.Parse(occurrencesSplit[0]) - 1;
                int secondPosition = Int32.Parse(occurrencesSplit[1]) - 1;

                // Retain the letter that needs checked
                char[] letterToCheck = firstSplit[1].ToCharArray();

                // Get rid of the white spaces
                string simpleString = lineSplit[1].Trim().ToString();

                // If the letter appears on one position but not on both then increment
                if ((simpleString[firstPosition] == letterToCheck[0] || simpleString[secondPosition] == letterToCheck[0])
                    && !(simpleString[firstPosition] == letterToCheck[0] && simpleString[secondPosition] == letterToCheck[0]))
                {
                    numberOfValidPasswords++;
                }
            }

            Console.WriteLine("The number of valid passwords is {0}", numberOfValidPasswords);

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
