using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2020
{
    public static class Day3Part2
    {
        public static List<List<bool>> treeMatrix;
        public static void Run()
        {
            Message.Intro("...Runnning Day 3 Puzzle 2: Count the number of trees encountered with several slopes, and multiply them");
            Console.WriteLine("...Reading geography file");
            using var reader = new StreamReader(@"Advent2020\Resources\input3.txt");
            string line;
            treeMatrix = new List<List<bool>>();
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
            var result1 = EvaluatePath(1, 1);
            var result2 = EvaluatePath(1, 3);
            var result3 = EvaluatePath(1, 5);
            var result4 = EvaluatePath(1, 7);
            var result5 = EvaluatePath(2, 1);
            if (Message.Verbose) Console.WriteLine(result1 + ", " + result2 + ", " + result3 + ", " + result4 + ", " + result5);
            var solution = result1 * result2 * result3 * result4 * result5;
            timer.Stop();
            Message.Solution("Traversed " + treeMatrix.Count + " rows of geography across 5 slopes.", timer.ElapsedMilliseconds, solution);
        }

        public static long EvaluatePath(int rise, int run)
        {
            int col = 0;
            long treeCount = 0;
            for (int row = 0; row < treeMatrix.Count; row += rise)
            {
                if (Message.Verbose) Console.WriteLine("Position " + row + ", " + col + " is " + treeMatrix[row][col]);
                if (treeMatrix[row][col]) treeCount++;
                if (col + run > treeMatrix[row].Count - 1)
                {
                    int spaceLeft = treeMatrix[row].Count - 1 - col;
                    col = run - 1 - spaceLeft;
                }
                else col += run;
            }
            return treeCount;
        }
    }
}