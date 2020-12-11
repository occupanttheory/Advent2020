using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2020
{
    public static class Day4Part1
    {
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
                if (item.ToLower().StartsWith("byr")) hasBYR = true;
                else if (item.ToLower().StartsWith("iyr")) hasIYR = true;
                else if (item.ToLower().StartsWith("eyr")) hasEYR = true;
                else if (item.ToLower().StartsWith("hgt")) hasHGT = true;
                else if (item.ToLower().StartsWith("hcl")) hasHCL = true;
                else if (item.ToLower().StartsWith("ecl")) hasECL = true;
                else if (item.ToLower().StartsWith("pid")) hasPID = true;
            }
            return hasBYR && hasIYR && hasEYR && hasHGT && hasHCL && hasECL && hasPID;
        }
    }
}