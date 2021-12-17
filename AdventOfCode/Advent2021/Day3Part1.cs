using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2021
{
  public static class Day3Part1
  {
    public static void Run()
    {
      Message.Intro("...Runnning Day 3, Part 1: Binary Diagnostics ");
      using var reader = new StreamReader(@"Advent2021\Resources\input3.txt");
      string line;
      var timer = Stopwatch.StartNew();

      var count1s = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      int total = 0;
      while ((line = reader.ReadLine()) != null)
      {
        total++;
        for (int i = 0; i < line.Length; i++)
          if (line[i] == '1') count1s[i]++;
      }

      int half = total / 2;
      var gammaList = count1s.Select(x => 
      {
        if (x > 500) return 1;
        return 0;
      });
      var gammaString = string.Join(string.Empty, gammaList);
      uint gamma = Convert.ToUInt32(gammaString, 2);

      var epsilonList = count1s.Select(x =>
      {
        if (x > 500) return 0;
        return 1;
      });
      var epsilonString = string.Join(string.Empty, epsilonList);
      uint epsilon = Convert.ToUInt32(epsilonString, 2);

      uint result = gamma * epsilon;

      timer.Stop();
      Message.Solution("...Message", timer.ElapsedMilliseconds, result);
    }
  }
}
