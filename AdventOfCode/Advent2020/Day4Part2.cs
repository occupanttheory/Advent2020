using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Advent2020
{
    public static class Day4Part2
    {
        public static readonly List<string> eclList = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        public static readonly string hclPattern = "^#(?:[0-9a-f]{6})$";
        public static readonly string pidPattern = "^(?:[0-9]{9})$";

        public static void Run()
        {
            Message.Intro("...Runnning Day 4 Puzzle 1: Count the number of valid passports");
            Console.WriteLine("...Reading passport file");
            using var reader = new StreamReader(@"Advent2020\Resources\input4.txt");
            string line, currentPassport = string.Empty;
            int validCount = 0, totalCount = 1;
            var timer = Stopwatch.StartNew();
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(line)) currentPassport += " " + line.TrimEnd(Environment.NewLine.ToCharArray());
                else
                {
                    if (Evaluate(currentPassport.Trim())) validCount++;
                    currentPassport = string.Empty;
                    totalCount++;
                }
            }
            timer.Stop();
            Message.Solution("Evaluated " + totalCount + " passports.", timer.ElapsedMilliseconds, validCount);
        }

        public static bool Evaluate(string passport)
        {
            var data = passport.Split(' ').ToList();
            bool hasBYR = false, hasIYR = false, hasEYR = false, hasHGT = false, hasHCL = false, hasECL = false, hasPID = false;
            foreach (var item in data)
            {
                if (item.ToLower().StartsWith("byr") && IsValidBYR(item)) hasBYR = true;
                else if (item.ToLower().StartsWith("iyr") && IsValidIYR(item)) hasIYR = true;
                else if (item.ToLower().StartsWith("eyr") && IsValidEYR(item)) hasEYR = true;
                else if (item.ToLower().StartsWith("hgt") && IsValidHGT(item)) hasHGT = true;
                else if (item.ToLower().StartsWith("hcl") && IsValidHCL(item)) hasHCL = true;
                else if (item.ToLower().StartsWith("ecl") && IsValidECL(item)) hasECL = true;
                else if (item.ToLower().StartsWith("pid") && IsValidPID(item)) hasPID = true;
            }
            var valid = hasBYR && hasIYR && hasEYR && hasHGT && hasHCL && hasECL && hasPID;
            if (Message.Verbose && valid)
            {
                var fields = passport.Split(' ').OrderBy(a => a).ToArray();                
                Console.WriteLine(string.Join('\t', fields));
                Console.WriteLine("byr " + hasBYR + "\tecl " + hasECL + "\teyr " + hasEYR + "\thcl " + hasHCL + "\thgt " + hasHGT + "\tiyr " + hasIYR + "\tpid " + hasPID);
                Console.WriteLine();
            }
            return valid;
        }

        public static bool IsValidBYR(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            if (!int.TryParse(rawpair[1], out int value)) return false;
            if (value < 1920 || value > 2002) return false;
            return true;
        }

        public static bool IsValidIYR(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            if (!int.TryParse(rawpair[1], out int value)) return false;
            if (value < 2010 || value > 2020) return false;
            return true;
        }

        public static bool IsValidEYR(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            if (!int.TryParse(rawpair[1], out int value)) return false;
            if (value < 2020 || value > 2030) return false;
            return true;
        }

        public static bool IsValidHGT(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            var rawvalue = rawpair[1];
            bool isIN = false, isCM = false;
            if (rawvalue.ToLower().EndsWith("in"))
            {
                isIN = true;
                rawvalue = rawvalue.ToLower().Replace("in", string.Empty);
            }
            else if (rawvalue.ToLower().EndsWith("cm"))
            {
                isCM = true;
                rawvalue = rawvalue.ToLower().Replace("cm", string.Empty);
            }
            else return false;
            if (!int.TryParse(rawvalue, out int value)) return false;
            if (isIN && (value < 59 || value > 76)) return false;
            if (isCM && (value < 150 || value > 193)) return false;
            return true;
        }

        public static bool IsValidHCL(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            if (!Regex.IsMatch(rawpair[1].ToLower(), hclPattern)) return false;
            return true;
        }

        public static bool IsValidECL(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            var value = rawpair[1].Trim().ToLower();
            if (!eclList.Contains(value)) return false;
            return true;
        }

        public static bool IsValidPID(string nvp)
        {
            var rawpair = nvp.Split(':');
            if (rawpair.Length != 2) return false;
            if (!Regex.IsMatch(rawpair[1].ToLower(), pidPattern)) return false;
            return true;
        }
    }
}