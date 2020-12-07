using System;
using System.Collections.Generic;
using System.IO;

namespace Day5
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

            int seatMax = 0;

            List<int> seats = new List<int>(); 

            foreach (var line in input)
            {
                // Determining row
                int rowMin = 0;
                int rowMax = 127;
                int rowPosition = 1;

                for (int i = 0; i < 7; i++)
                {
                    decimal medianRow = rowMin + rowMax;

                    switch (line[i])
                    {
                        case 'F':
                            rowMax = (int) Math.Floor(medianRow / 2);
                            rowPosition = rowMax;
                            break;

                        case 'B':
                            rowMin = (int)Math.Ceiling(medianRow / 2);
                            rowPosition = rowMin;
                            break;

                        default:
                            break;
                    }
                }

                // Determining column
                int columnMin = 0;
                int columnMax = 7;
                int columnPosition = 1;

                for (int i = 7; i < 10; i++)
                {
                    decimal medianColumn = columnMin + columnMax;

                    switch (line[i])
                    {
                        case 'L':
                            columnMax = (int)Math.Floor(medianColumn / 2);
                            columnPosition = columnMax;
                            break;

                        case 'R':
                            columnMin = (int)Math.Ceiling(medianColumn / 2);
                            columnPosition = columnMin;
                            break;

                        default:
                            break;
                    }
                }

                // Determine seat ID maximum
                if (rowPosition * 8 + columnPosition > seatMax)
                {
                    seatMax = rowPosition * 8 + columnPosition;
                }

                // Build list of IDs
                seats.Add(rowPosition * 8 + columnPosition);
            }

            Console.WriteLine(string.Format("The highest seat ID is {0}", seatMax));

            // Sort list of IDs from converted array
            var seatsArray = seats.ToArray();
            int auxValue;

            for (int i = 0; i < seatsArray.Length - 1; i++)
            {
                for (int j = i + 1; j < seatsArray.Length; j++)
                {
                    if (seatsArray[i] > seatsArray[j])
                    {
                        auxValue = seatsArray[i];
                        seatsArray[i] = seatsArray[j];
                        seatsArray[j] = auxValue;
                    }
                }
            }

            // Find your seat ID
            for (int i = 0; i < seatsArray.Length - 1; i++)
            {
                if (seatsArray[i+1] - seatsArray[i] == 2)
                {
                    Console.WriteLine(string.Format("Your seat ID is {0}", seatsArray[i]+1));
                }
            }

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
