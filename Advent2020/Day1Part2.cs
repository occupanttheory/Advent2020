using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Advent2020
{
    public static class Day1Part2
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("...Runnning Day 1 Puzzle 2: Verify expense report with three values");
            Console.WriteLine("...Reading expense report");
            using var reader = new StreamReader(@"Resources\input.txt");
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
            Console.WriteLine("...Examining " + candidates.Count + " entries.");
            foreach (var c in candidates)
            {
                var complement = 2020 - c;
                if (candidateSums.ContainsKey(complement))
                {
                    timer.Stop();
                    var tuple = candidateSums[complement];
                    Console.WriteLine("...Found entries " + c + ", " + tuple.Item1 + ", and " + tuple.Item2 + " which match the criteria.");
                    Console.WriteLine("Elapsed time was " + timer.ElapsedMilliseconds + " ms. Solution:");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(c * tuple.Item1 * tuple.Item2);
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey();
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
