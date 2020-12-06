using System;
using System.IO;

namespace Day4
{
    public static class Constants
    {
        public const string filePath = @"../../../input.txt";
    }

    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Constants.filePath);

            int validPassports = 0;
            int invalidPassports = 0;

            var passport = new Passport();

            //solution to be added
            foreach (var line in input)
            {
                if (line.Length > 0)
                {
                    string[] splits = line.Split(' ');

                    foreach (var split in splits)
                    {
                        string key = split.Split(':')[0];
                        string value = split.Split(':')[1];

                        switch (key)
                        {
                            case "byr":
                                passport.BirthYear = value;
                                break;
                            case "iyr":
                                passport.IssueYear = value;
                                break;
                            case "eyr":
                                passport.ExpirationYear = value;
                                break;
                            case "hgt":
                                passport.Height = value;
                                break;
                            case "hcl":
                                passport.HairColor = value;
                                break;
                            case "ecl":
                                passport.EyeColor = value;
                                break;
                            case "pid":
                                passport.PassportId = value;
                                break;
                            case "cid":
                                passport.CountryId = value;
                                break;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(passport.BirthYear) && !string.IsNullOrEmpty(passport.IssueYear) && 
                        !string.IsNullOrEmpty(passport.ExpirationYear) && !string.IsNullOrEmpty(passport.Height) &&
                        !string.IsNullOrEmpty(passport.HairColor) && !string.IsNullOrEmpty(passport.EyeColor) &&
                        !string.IsNullOrEmpty(passport.PassportId))
                    {
                        validPassports++;
                    } 
                    else
                    {
                        invalidPassports++;
                    }

                    passport = new Passport();
                }
            }

            Console.WriteLine(string.Format("The number of valid passports is {0}", validPassports));

            // Prevents console app from closing
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }
    }
}
