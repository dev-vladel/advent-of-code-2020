using System;
using System.IO;

namespace Day8
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // I've added another line to the input.txt file because File.ReadAllLines ignores the last line if its whitespace or empty
            string[] input = File.ReadAllLines(Constants.filePath);

            int[] frequency = new int[630];
            int acc = 0;

            #region part one
            for (int i = 0; i < input.Length; i++)
            {
                frequency[i]++;

                if (frequency[i] > 1)
                {
                    break;
                }

                var splitLine = input[i].Split(' ');

                if (input[i].Contains("acc"))
                {
                    acc += Convert.ToInt32(splitLine[1]);
                }
                else if (input[i].Contains("jmp"))
                {
                    if (Convert.ToInt32(splitLine[1]) != 0)
                    {
                        i += Convert.ToInt32(splitLine[1]) - 1;
                    }
                }
            }

            Console.WriteLine("The value of acc is {0}", acc);
            #endregion

            #region part two
            for (int i = 0; i < input.Length; i++)
            {
                string[] auxInput = File.ReadAllLines(Constants.filePath);
                acc = 0;
                frequency = new int[1000];

                var splitLine = input[i].Split(' ');

                if (splitLine[0].Contains("jmp"))
                {
                    auxInput[i] = "nop " + splitLine[1];
                }
                else if (splitLine[0].Contains("nop"))
                {
                    auxInput[i] = "jmp " + splitLine[1];
                }

                for (int j = 0; j < auxInput.Length; j++)
                {
                    frequency[j]++;

                    if (frequency[j] > 1)
                    {
                        break;
                    }

                    var splitLineAux = auxInput[j].Split(' ');

                    if (auxInput[j].Contains("acc"))
                    {
                        acc += Convert.ToInt32(splitLineAux[1]);
                    }
                    else if (auxInput[j].Contains("jmp"))
                    {
                        if (Convert.ToInt32(splitLineAux[1]) != 0)
                        {
                            j += Convert.ToInt32(splitLineAux[1]) - 1;
                        }
                    }

                    if (j == auxInput.Length - 1)
                    {
                        Console.WriteLine("The value of acc without loop is {0}", acc);
                    }
                }
            }
            #endregion

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
