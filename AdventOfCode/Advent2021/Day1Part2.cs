using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2021
{
  public static class Day1Part2
  {
    public static void Run()
    {
      Message.Intro("...Runnning Day 1, Part 2: Sonar Sweep ");
      using var reader = new StreamReader(@"Advent2021\Resources\input1.txt");
      string line;
      List<int> values = new List<int>();
      int increaseCount = 0;
      
      var timer = Stopwatch.StartNew();

      while ((line = reader.ReadLine()) != null)
      {
        values.Add(int.Parse(line));
        if (values.Count == 5) values.RemoveAt(0);
        if (values.Count == 4)
        {
          int sum1 = values[0] + values[1] + values[2];
          int sum2 = values[1] + values[2] + values[3];
          if (sum2 > sum1) increaseCount++;
        }
      }

      timer.Stop();
      Message.Solution("...Found " + increaseCount + " increases.", timer.ElapsedMilliseconds, increaseCount);
    }
  }
}
