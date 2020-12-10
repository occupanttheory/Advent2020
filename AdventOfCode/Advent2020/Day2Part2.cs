using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2020
{
    public static class Day2Part2
    {
        public static readonly bool logging = false;
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("...Runnning Day 2 Puzzle 2: Finding valid passwords with the right policies");
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
                if (range.Length != 2)
                {
                    if (logging) Error(", cannot parse positions: " + entryParts[0]);
                    continue;
                }
                if (!int.TryParse(range[0], out int firstPosition))
                {
                    if (logging) Error(", cannot parse first position: " + range[0]);
                    continue;
                }
                if (!int.TryParse(range[1], out int secondPosition))
                {
                    if (logging) Error(", cannot parse second position: " + range[1]);
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
                if (Test(firstPosition, secondPosition, token, password))
                    validCount++;
            }
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

        public static bool Test(int firstPosition, int secondPosition, char token, string password)
        {
            int matches = 0;
            if (password.Length < firstPosition - 1)
            {
                if (logging) Error(", password too short: " + firstPosition + ", " + password);
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
                if (logging) Error(", neither position correct: " + firstPosition + ", " + secondPosition + ", " + token + ", " + password);
                return false;
            }
            if (matches > 1)
            {
                if (logging) Error(", both positions correct: " + firstPosition + ", " + secondPosition + ", " + token + ", " + password);
                return false;
            }
            if (logging)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Valid password entry");
                Console.ResetColor();
                Console.Write(": " + firstPosition + ", " + secondPosition + ", " + token + ", " + password + Environment.NewLine);
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
