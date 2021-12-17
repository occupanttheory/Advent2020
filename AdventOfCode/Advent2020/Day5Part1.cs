using System;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2020
{
    public static class Day5Part1
    {

        public static void Run()
        {
            Message.Intro("...Runnning Day 5 Puzzle 1: Find the highest seat ID from list of seats");
            Console.WriteLine("...Reading seat file");
            using var reader = new StreamReader(@"Advent2020\Resources\input5.txt");
            string line;
            int highestID = 0, totalCount = 0;
            var timer = Stopwatch.StartNew();
            while ((line = reader.ReadLine()) != null)
            {
                var row = Convert.ToInt32(line.Substring(0, 7).Replace("F", "0").Replace("B", "1"), 2);
                var col = Convert.ToInt32(line.Substring(7).Replace("L", "0").Replace("R", "1"), 2);
                var id = (row * 8) + col;
                if (id > highestID) highestID = id;
            }
            timer.Stop();
            Message.Solution("Evaluated " + totalCount + " seats.", timer.ElapsedMilliseconds, highestID);
        }
    }
}
