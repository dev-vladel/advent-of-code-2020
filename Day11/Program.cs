using System;
using System.IO;

namespace Day9
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
        public const int x = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Constants.filePath);

            var rowLength = input.Length + 2;
            var columnLength = input[0].Length + 2;

            var matrix = new char[rowLength, columnLength];
            var matrixCopy = new char[rowLength, columnLength];
            var countSeats = 0;
            var run = true;

            // Building matrix
            BuildMatrix(input, matrix, rowLength, columnLength);

            #region part one

            while (run == true)
            {
                CopyMatrix(matrixCopy, matrix, rowLength, columnLength);

                for (int i = 1; i <= rowLength - 2; i++)
                {
                    for (int j = 1; j <= columnLength - 2; j++)
                    {
                        SeatAlteration(matrix,
                                       matrixCopy,
                                       matrix[i, j],
                                       i,
                                       j);
                    }
                }

                run = CompareMatrices(matrix, matrixCopy, rowLength - 2, columnLength - 2);

                CopyMatrix(matrix, matrixCopy, rowLength, columnLength);
            }


            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (matrix[i, j] == '#') countSeats++;
                }
            }

            Console.WriteLine(countSeats);

            #endregion

            #region part two

            rowLength = input.Length * 3;
            columnLength = input[0].Length * 3;

            var matrixTwo = new char[rowLength, columnLength];
            var matrixTwoCopy = new char[rowLength, columnLength];
            countSeats = 0;
            run = true;

            // Building matrix
            BuildMatrixTwo(input, matrixTwo, rowLength, columnLength);

            while (run == true)
            {
                CopyMatrix(matrixTwoCopy, matrixTwo, rowLength, columnLength);

                for (int i = rowLength / 3; i <= rowLength - rowLength / 3 ; i++)
                {
                    for (int j = columnLength / 3; j <= columnLength - columnLength / 3; j++)
                    {
                        SeatAlterationTwo(matrixTwo,
                                       matrixTwoCopy,
                                       matrixTwo[i, j],
                                       i,
                                       j,
                                       rowLength / 3);
                    }
                }

                run = CompareMatrices(matrixTwo, matrixTwoCopy, rowLength - 2, columnLength - 2);

                CopyMatrix(matrixTwo, matrixTwoCopy, rowLength, columnLength);
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    Console.Write(matrixTwo[i, j]);
                    if (matrixTwo[i, j] == '#') countSeats++;
                }

                Console.WriteLine();

            }

            Console.WriteLine(countSeats);

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

        private static void SeatAlterationTwo(char[,] matrix, char[,] matrixCopy, char seat, int row, int column, int distance)
        {
            if (matrix[row, column] == 'L')
            {
                int countOccupied = 0;

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row - i, column - i]) { countOccupied++; break; }
                    else if ('L' == matrix[row - i, column - i]) { break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row - i, column]) { countOccupied++; break; }
                    else if ('L' == matrix[row - i, column]) { break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row - i, column + i]) { countOccupied++; break; }
                    else if ('L' == matrix[row - i, column + i]) { break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row, column - i]) { countOccupied++; break; }
                    else if ('L' == matrix[row, column - i]) {  break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row, column + i]) { countOccupied++; break; }
                    else if ('L' == matrix[row, column + i]) { break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row + i, column + i]) { countOccupied++; break; }
                    else if ('L' == matrix[row + i, column + i]) { break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row + i, column]) { countOccupied++; break; }
                    else if ('L' == matrix[row + i, column]) { break; }
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row + i, column - i]) { countOccupied++; break; }
                    else if ('L' == matrix[row + i, column - i]) { break; }
                }

                if (countOccupied == 0)
                {
                    matrixCopy[row, column] = '#';
                }
                else
                {
                    matrixCopy[row, column] = 'L';
                }
            }
            else if (matrix[row, column] == '#')
            {
                int count = 0;

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row - i, column - i]) { count++; break; }
                    else if ('L' == matrix[row - i, column - i]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row - i, column]) { count++; break; }
                    else if ('L' == matrix[row - i, column]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row - i, column + i]) { count++; break; }
                    else if ('L' == matrix[row - i, column + i]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row, column - i]) { count++; break; }
                    else if ('L' == matrix[row, column - i]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row, column + i]) { count++; break; }
                    else if ('L' == matrix[row, column + i]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row + i, column + i]) { count++; break; }
                    else if ('L' == matrix[row + i, column + i]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row + i, column]) { count++; break; }
                    else if ('L' == matrix[row + i, column]) break;
                }

                for (int i = 1; i <= distance; i++)
                {
                    if ('#' == matrix[row + i, column - i]) { count++; break; }
                    else if ('L' == matrix[row + i, column - i]) break;
                }

                if (count >= 5)
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

        private static void BuildMatrix(string[] input, char[,] matrix, int rowLength, int columnLength)
        {
            // Building outer layer
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    matrix[i, j] = '.';
                }
            }

            // Building inner layer
            var row = 1;

            foreach (var line in input)
            {
                for (int j = 1; j <= line.Length; j++)
                {
                    matrix[row, j] = line[j - 1];
                }

                row++;
            }
        }

        private static void BuildMatrixTwo(string[] input, char[,] matrix, int rowLength, int columnLength)
        {
            // Building outer layer
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    matrix[i, j] = '.';
                }
            }

            // Building inner layer
            var row = rowLength / 3;

            foreach (var line in input)
            {
                for (int j = 1; j <= line.Length; j++)
                {
                    matrix[row, j + columnLength / 3 - 1] = line[j - 1];
                }

                row++;
            }
        }
    }
}
