using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2020
{
    public static class Day1Part2
    {
        public static void Run()
        {
            Message.Intro("...Runnning Day 1 Puzzle 2: Verify expense report with three values");
            if (Message.Verbose) Console.WriteLine("...Reading expense report");
            using var reader = new StreamReader(@"Advent2020\Resources\input1.txt");
            string entry;
            var candidates = new HashSet<int>();
            var candidateSums = new Dictionary<int, Tuple<int, int>>();
            var timer = Stopwatch.StartNew();
            while ((entry = reader.ReadLine()) != null)
            {
                entry = entry.Trim();
                if (int.TryParse(entry, out int candidate))
                {
                    foreach (var c in candidates)
                        if (!candidateSums.ContainsKey(candidate + c)) 
                            candidateSums.Add(candidate + c, new Tuple<int, int>(candidate, c));
                    candidates.Add(candidate);
                }
            }
            if (Message.Verbose) Console.WriteLine("...Examining " + candidates.Count + " entries.");
            foreach (var c in candidates)
            {
                var complement = 2020 - c;
                if (candidateSums.ContainsKey(complement))
                {
                    timer.Stop();
                    var tuple = candidateSums[complement];
                    Message.Solution("...Found entries " + c + ", " + tuple.Item1 + ", and " + tuple.Item2 + " which match the criteria.", 
                        timer.ElapsedMilliseconds, 
                        c * tuple.Item1 * tuple.Item2);
                    return;
                }
            }
            timer.Stop();
            Message.Solution("No solution found", timer.ElapsedMilliseconds, "N/A");
        }
    }
}
