using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2020
{
    public static class Day2Part1
    {
        public static void Run()
        {
            Message.Intro("...Runnning Day 2 Puzzle 1: Finding valid passwords with the wrong policies");
            if (Message.Verbose) Console.WriteLine("...Reading password file");
            using var reader = new StreamReader(@"Advent2020\Resources\input2.txt");
            string entry;
            var entryParts = new List<string>();
            var validCount = 0; 
            var totalCount = 0;
            var timer = Stopwatch.StartNew();
            while ((entry = reader.ReadLine()) != null)
            {
                totalCount++;
                entryParts = entry.Trim().Split(' ').ToList();
                if (entryParts.Count != 3)
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", only has " + entryParts.Count + " elements");
                    continue;
                }
                var range = entryParts[0].Split('-');
                if (range.Length < 1 || range.Length > 2)
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse range: " + entryParts[0]);
                    continue;
                }
                if (!int.TryParse(range[0], out int minCount))
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse minimum count: " + range[0]);
                    continue;
                }
                int maxCount = minCount;
                if (range.Length == 2 && !int.TryParse(range[1], out maxCount))
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse maximum count: " + range[1]);
                    continue;
                }
                if (entryParts[1].Length != 2)
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse token: " + entryParts[1]);
                    continue;
                }
                char token = entryParts[1][0];
                if (string.IsNullOrEmpty(entryParts[2]))
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", password is empty");
                    continue;
                }
                string password = entryParts[2];
                if (Test(minCount, maxCount, token, password))
                    validCount++;
            }
            timer.Stop();
            Message.Solution("Inspected " + totalCount + " password entries.", timer.ElapsedMilliseconds, validCount);
        }

        public static bool Test(int minCount, int maxCount, char token, string password)
        {
            int tokenCount = password.Count(t => t == token);
            if (tokenCount < minCount)
            {
                if (Message.Verbose) Message.Error("Invalid password entry", ", min count rule: " + tokenCount + ", " + minCount + ", " + token + ", " + password);
                return false;
            }
            if (tokenCount > maxCount)
            {
                if (Message.Verbose) Message.Error("Invalid password entry", ", max count rule: " + tokenCount + ", " + maxCount + ", " + token + ", " + password);
                return false;
            }
            if (Message.Verbose) Message.Success("Valid password entry", ": " + minCount + ", " + maxCount + ", " + token + ", " + password + Environment.NewLine);

            return true;
        }
    }
}
