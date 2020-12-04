using System;
using System.IO;

namespace Day4
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

            //solution to be added

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
