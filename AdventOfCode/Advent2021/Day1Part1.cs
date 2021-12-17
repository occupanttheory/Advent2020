using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2021
{
  public static class Day1Part1
  {
    public static void Run()
    {
      Message.Intro("...Runnning Day 1, Part 1: Sonar Sweep ");
      using var reader = new StreamReader(@"Advent2021\Resources\input1.txt");
      string line;
      bool firstValue = true;
      int oldValue = 0, newValue = 0, increaseCount = 0;
      var timer = Stopwatch.StartNew();

      while ((line = reader.ReadLine()) != null)
      {
        newValue = int.Parse(line);
        if (!firstValue && (newValue > oldValue)) increaseCount++;
        else if (firstValue) firstValue = false;
        oldValue = newValue;
      }

      timer.Stop();
      Message.Solution("...Found " + increaseCount + " increases.", timer.ElapsedMilliseconds, increaseCount);
    }
  }
}
