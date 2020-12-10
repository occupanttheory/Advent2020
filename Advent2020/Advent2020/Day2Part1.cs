using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2020
{
    public static class Day2Part1
    {
        public static readonly bool logging = false;
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("...Runnning Day 2 Puzzle 1: Finding valid passwords with the wrong policies");
            Console.WriteLine("...Reading password file");
            using var reader = new StreamReader(@"Resources\input2.txt");
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
                    if (logging) Error(", only has " + entryParts.Count + " elements");
                    continue;
                }
                var range = entryParts[0].Split('-');
                if (range.Length < 1 || range.Length > 2)
                {
                    if (logging) Error(", cannot parse range: " + entryParts[0]);
                    continue;
                }
                if (!int.TryParse(range[0], out int minCount))
                {
                    if (logging) Error(", cannot parse minimum count: " + range[0]);
                    continue;
                }
                int maxCount = minCount;
                if (range.Length == 2 && !int.TryParse(range[1], out maxCount))
                {
                    if (logging) Error(", cannot parse maximum count: " + range[1]);
                    continue;
                }
                if (entryParts[1].Length != 2)
                {
                    if (logging) Error(", cannot parse token: " + entryParts[1]);
                    continue;
                }
                char token = entryParts[1][0];
                if (string.IsNullOrEmpty(entryParts[2]))
                {
                    if (logging) Error(", password is empty");
                    continue;
                }
                string password = entryParts[2];
                if (Test(minCount, maxCount, token, password))
                    validCount++;
            }
            timer.Stop();
            Console.WriteLine("Inspected " + totalCount + " password entries.");
            Console.WriteLine("Elapsed time was " + timer.ElapsedMilliseconds + " ms");
            Console.Write("Valid password count: ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(validCount);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static bool Test(int minCount, int maxCount, char token, string password)
        {
            int tokenCount = password.Count(t => t == token);
            if (tokenCount < minCount)
            {
                if (logging) Error(", min count rule: " + tokenCount + ", " + minCount + ", " + token + ", " + password);
                return false;
            }
            if (tokenCount > maxCount)
            {
                if (logging) Error(", max count rule: " + tokenCount + ", " + maxCount + ", " + token + ", " + password);
                return false;
            }
            if (logging)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Valid password entry");
                Console.ResetColor();
                Console.Write(": " + minCount + ", " + maxCount + ", " + token + ", " + password + Environment.NewLine);
            }
            return true;
        }

        public static void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Invalid password entry");
            Console.ResetColor();
            Console.Write(message + Environment.NewLine);
        }
    }
}
