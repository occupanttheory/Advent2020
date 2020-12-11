using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2020
{
    public static class Day2Part2
    {
        public static void Run()
        {
            Message.Intro("...Runnning Day 2 Puzzle 2: Finding valid passwords with the right policies");
            Console.WriteLine("...Reading password file");
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
                if (range.Length != 2)
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse positions: " + entryParts[0]);
                    continue;
                }
                if (!int.TryParse(range[0], out int firstPosition))
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse first position: " + range[0]);
                    continue;
                }
                if (!int.TryParse(range[1], out int secondPosition))
                {
                    if (Message.Verbose) Message.Error("Invalid password entry", ", cannot parse second position: " + range[1]);
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
                if (Test(firstPosition, secondPosition, token, password))
                    validCount++;
            }
            Message.Solution("Inspected " + totalCount + " password entries.", timer.ElapsedMilliseconds, validCount);
        }

        public static bool Test(int firstPosition, int secondPosition, char token, string password)
        {
            int matches = 0;
            if (password.Length < firstPosition - 1)
            {
                if (Message.Verbose) Message.Error("Invalid password entry", ", password too short: " + firstPosition + ", " + password);
                return false;
            }
            char first = password[firstPosition - 1];
            if (token == first) matches++;
            if (password.Length >= secondPosition)
            {
                char second = password[secondPosition - 1];
                if (token == second) matches++;
            }
            if (matches < 1)
            {
                if (Message.Verbose) Message.Error("Invalid password entry", ", neither position correct: " + firstPosition + ", " + secondPosition + ", " + token + ", " + password);
                return false;
            }
            if (matches > 1)
            {
                if (Message.Verbose) Message.Error("Invalid password entry", ", both positions correct: " + firstPosition + ", " + secondPosition + ", " + token + ", " + password);
                return false;
            }
            if (Message.Verbose) Message.Success("Valid password entry", ": " + firstPosition + ", " + secondPosition + ", " + token + ", " + password + Environment.NewLine);

            return true;
        }
    }
}
