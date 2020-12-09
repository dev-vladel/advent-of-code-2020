using System;
using System.Collections.Generic;
using System.IO;

namespace Day7
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

            List<string> bags = new List<string>();

            // solution to be added

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
