using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2020
{
    public static class Day5Part2
    {

        public static void Run()
        {
            Message.Intro("...Runnning Day 5 Puzzle 2: Find the missing seat ID from the middle of the list of seats");
            Console.WriteLine("...Reading seat file");
            using var reader = new StreamReader(@"Advent2020\Resources\input5.txt");
            string line;
            var idList = new List<int>();
            var timer = Stopwatch.StartNew();
            while ((line = reader.ReadLine()) != null)
            {
                var row = Convert.ToInt32(line.Substring(0, 7).Replace("F", "0").Replace("B", "1"), 2);
                var col = Convert.ToInt32(line.Substring(7).Replace("L", "0").Replace("R", "1"), 2);
                var id = (row * 8) + col;
                idList.Add(id);
            }
            idList = idList.OrderBy(a => a).ToList();
            var answer = 0;
            for (int i = 0; i < idList.Count - 1; i++)
            {
                Console.WriteLine(idList[i]);
                if (idList[i + 1] == idList[i] + 2)
                {
                    answer = idList[i] + 1;
                    break;
                }
            }
            timer.Stop();
            Message.Solution("Evaluated " + idList.Count + " seats.", timer.ElapsedMilliseconds, answer);
        }
    }
}
