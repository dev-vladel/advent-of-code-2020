using System;
using System.IO;

namespace Day1
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    class Program
    {
        public static void Main(string[] args)
        {
            bool earlyBreak = false;
            string[] input = File.ReadAllLines(Constants.filePath);

            for(int i = 0; i < input.Length - 1; i++)
            {
                for(int j = i + 1; j < input.Length; j++)
                {
                    int firstEntry = Int32.Parse(input[i]);
                    int secondEntry = Int32.Parse(input[j]);

                    if (firstEntry + secondEntry == 2020)
                    {
                        Console.WriteLine(String.Format("Two entries that summed together give 2020 are {0} and {1}", firstEntry, secondEntry));
                        Console.WriteLine(String.Format("Multiplied they are {0}", firstEntry * secondEntry));

                        earlyBreak = true;
                        break;
                    }
                }

                if (earlyBreak)
                {
                    break;
                }
            }

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
