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

            var matrix = new char[input.Length + 2, input[0].Length + 2];
            var matrixCopy = new char[input.Length + 2, input[0].Length + 2];
            var row = 1;
            var countSeats = 0;
            var run = true;

            // Building matrix

            // Building outer layer
            for (int i = 0; i < input.Length + 2; i++)
            {
                for (int j = 0; j < input[0].Length + 2; j++)
                {
                    matrix[i, j] = '.';
                }
            }

            // Building inner layer
            foreach (var line in input)
            {
                for (int j = 1; j <= line.Length; j++)
                {
                    matrix[row, j] = line[j - 1];
                }

                row++;
            }

            #region part one

            while (run == true)
            {
                CopyMatrix(matrixCopy, matrix, input.Length + 2, input[0].Length + 2);

                for (int i = 1; i <= input.Length; i++)
                {
                    for (int j = 1; j <= input[0].Length; j++)
                    {
                        SeatAlteration(matrix,
                                       matrixCopy,
                                       matrix[i, j],
                                       i,
                                       j);
                    }
                }

                run = CompareMatrices(matrix, matrixCopy, input.Length, input[0].Length);

                CopyMatrix(matrix, matrixCopy, input.Length + 2, input[0].Length + 2);
            }


            for (int i = 0; i < input.Length + 2; i++)
            {
                for (int j = 0; j < input[0].Length + 2; j++)
                {
                    if (matrix[i, j] == '#') countSeats++;
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(countSeats);

            #endregion

            #region part two

            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        private static void SeatAlteration(char[,] matrix, char[,] matrixCopy, char seat, int row, int column)
        {
            int count = 0;
             
            if (matrix[row, column] == 'L')
            {
                if (matrix[row - 1, column - 1] == '#' ||
                    matrix[row - 1, column] == '#' ||
                    matrix[row - 1, column + 1] == '#' ||
                    matrix[row, column - 1] == '#' ||
                    matrix[row, column + 1] == '#' ||
                    matrix[row + 1, column + 1] == '#' ||
                    matrix[row + 1, column] == '#' ||
                    matrix[row + 1, column - 1] == '#')
                {
                    matrixCopy[row, column] = 'L';
                }
                else
                {
                    matrixCopy[row, column] = '#';
                }
            }
            else if (matrix[row, column] == '#')
            {
                if ('#' == matrix[row - 1, column - 1]) count++;
                if ('#' == matrix[row - 1, column]) count++;
                if ('#' == matrix[row - 1, column + 1]) count++;
                if ('#' == matrix[row, column - 1]) count++;
                if ('#' == matrix[row, column + 1]) count++;
                if ('#' == matrix[row + 1, column + 1]) count++;
                if ('#' == matrix[row + 1, column]) count++;
                if ('#' == matrix[row + 1, column - 1]) count++;

                if (count >= 4)
                {
                    matrixCopy[row, column] = 'L';
                }
                else
                {
                    matrixCopy[row, column] = '#';
                }
            }
        }

        private static bool CompareMatrices(char[,] matrix, char[,] matrixCopy, int rowLength, int columnLength)
        {
            for (int i = 0; i < rowLength + 2; i++)
            {
                for (int j = 0; j < columnLength + 2; j++)
                {
                    if (matrix[i, j] != matrixCopy[i, j]) return true;
                }
            }

            return false;
        }

        private static void CopyMatrix(char[,] matrixOne, char[,] matrixTwo, int rowLength, int columnLength)
        {
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    matrixOne[i, j] = matrixTwo[i, j];
                }
            }
        }
    }
}
