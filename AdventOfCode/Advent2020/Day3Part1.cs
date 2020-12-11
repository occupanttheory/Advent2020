using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2020
{
    public static class Day3Part1
    {
        public static void Run()
        {
            Message.Intro("...Runnning Day 3 Puzzle 1: Count the number of trees encountered with a -1/3 slope");
            Console.WriteLine("...Reading geography file");
            using var reader = new StreamReader(@"Advent2020\Resources\input3.txt");
            string line;
            var treeMatrix = new List<List<bool>>();
            var timer = Stopwatch.StartNew();
            while ((line = reader.ReadLine()) != null)
            {
                var treeRow = new List<bool>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '#') treeRow.Add(true);
                    else treeRow.Add(false);
                }
                treeMatrix.Add(treeRow);
            }
            int col = 0;
            int treeCount = 0;
            for (int row = 0; row < treeMatrix.Count; row++)
            {
                if (Message.Verbose) Console.WriteLine("Position " + row + ", " + col + " is " + treeMatrix[row][col]);
                if (treeMatrix[row][col]) treeCount++;
                var spaceLeft = treeMatrix[row].Count - col - 1;
                col = spaceLeft switch
                {
                    0 => 2,
                    1 => 1,
                    2 => 0,
                    _ => col + 3,
                };
            }
            timer.Stop();
            Message.Solution("Traversed " + treeMatrix.Count + " rows of geography.", timer.ElapsedMilliseconds, treeCount);
        }
    }
}