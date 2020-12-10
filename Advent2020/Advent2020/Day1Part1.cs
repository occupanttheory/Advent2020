using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2020
{
    public static class Day1Part1
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("...Runnning Day 1 Puzzle 1: Verify expense report ");
            Console.WriteLine("...Reading expense report");
            using var reader = new StreamReader(@"Resources\input1.txt");          
            string entry;
            var candidates = new HashSet<int>();
            var timer = Stopwatch.StartNew();
            while ((entry = reader.ReadLine()) != null)
            {
                entry = entry.Trim();
                if (int.TryParse(entry, out int candidate))
                    candidates.Add(candidate);
            }
            Console.WriteLine("...Examining " + candidates.Count + " entries.");
            foreach (var c in candidates)
            {
                var complement = 2020 - c;
                if (candidates.Contains(complement))
                {
                    timer.Stop();
                    Console.WriteLine("...Found entries " + c + " and " + complement + " which match the criteria.");
                    Console.WriteLine("Elapsed time was " + timer.ElapsedMilliseconds + " ms.");
                    Console.Write("Solution: ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write(c * complement);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
