using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            // I've added another line to the input.txt file because File.ReadAllLines ignores the last line if its whitespace or empty
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
                                if (value.Length == 4)
                                {
                                    if (Int32.Parse(value) >= 1920 && Int32.Parse(value) <= 2002)
                                    {
                                        passport.BirthYear = value;
                                    }
                                }
                                break;
                            case "iyr":
                                if (value.Length == 4)
                                {
                                    if (Int32.Parse(value) >= 2010 && Int32.Parse(value) <= 2020)
                                    {
                                        passport.IssueYear = value;
                                    }
                                }
                                break;
                            case "eyr":
                                if (value.Length == 4)
                                {
                                    if (Int32.Parse(value) >= 2020 && Int32.Parse(value) <= 2030)
                                    {
                                        passport.ExpirationYear = value;
                                    }
                                }
                                break;
                            case "hgt":
                                Regex rxHeight = new Regex(@"(cm)|(in){1}");
                                
                                if (rxHeight.Matches(value).Any())
                                {
                                    string heightMeasure = value.Substring(value.Length - 2);
                                    int heightValue = Int32.Parse(value.Substring(0, value.Length - 2));

                                    if ((heightMeasure == "cm" && heightValue >= 150 && heightValue <= 193)
                                        || (heightMeasure == "in" && heightValue >= 59 && heightValue <= 76))
                                    {
                                        passport.Height = value;
                                    }
                                }
                                break;
                            case "hcl":
                                if (value.Substring(0, 1) == "#")
                                {
                                    Regex rxHair = new Regex(@"([a-f0-9]){6}");
                                    var hairColorValue = value.Substring(1);

                                    if (hairColorValue.Length == 6 && rxHair.Matches(hairColorValue).Any())
                                    {
                                        passport.HairColor = value;
                                    }
                                }
                                break;
                            case "ecl":
                                Regex rxEye = new Regex(@"(amb|blu|brn|gry|grn|hzl|oth){1}");

                                if (rxEye.Matches(value).Any())
                                {
                                    passport.EyeColor = value;
                                }
                                break;
                            case "pid":
                                Regex rxPassportId = new Regex(@"^([0-9]){9}$");

                                if (rxPassportId.Matches(value).Any())
                                {
                                    passport.PassportId = value;
                                }
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
