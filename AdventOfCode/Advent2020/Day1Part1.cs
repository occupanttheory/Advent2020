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
            Message.Intro("...Runnning Day 1 Puzzle 1: Verify expense report ");
            if (Message.Verbose) Console.WriteLine("...Reading expense report");
            using var reader = new StreamReader(@"Advent2020\Resources\input1.txt");          
            string entry;
            var candidates = new HashSet<int>();
            var timer = Stopwatch.StartNew();
            while ((entry = reader.ReadLine()) != null)
            {
                entry = entry.Trim();
                if (int.TryParse(entry, out int candidate))
                    candidates.Add(candidate);
            }
            if (Message.Verbose) Console.WriteLine("...Examining " + candidates.Count + " entries.");
            foreach (var c in candidates)
            {
                var complement = 2020 - c;
                if (candidates.Contains(complement))
                {
                    timer.Stop();
                    Message.Solution("...Found entries " + c + " and " + complement + " which match the criteria.", timer.ElapsedMilliseconds, c * complement);
                    return;
                }
            }
            timer.Stop();
            Message.Solution("No solution found", timer.ElapsedMilliseconds, "N/A");
        }
    }
}
