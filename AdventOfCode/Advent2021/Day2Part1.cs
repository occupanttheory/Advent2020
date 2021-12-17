using System.Diagnostics;
using System.IO;

namespace AdventOfCode.Advent2021
{
  public static class Day2Part1
  {
    public static void Run()
    {
      Message.Intro("...Runnning Day 2, Part 1: Dive! ");
      using var reader = new StreamReader(@"Advent2021\Resources\input2.txt");
      string line;
      var timer = Stopwatch.StartNew();

      int horizontal = 0, depth = 0;
      while ((line = reader.ReadLine()) != null)
      {
        var instructions = line.Split(" ");
        char direction = instructions[0].ToLower()[0];
        int magnitude = int.Parse(instructions[1]);
        switch (direction)
        {
          case 'd': depth += magnitude; break;
          case 'f': horizontal += magnitude; break;
          case 'u': depth -= magnitude; break;
        }
      }
      int result = horizontal * depth;

      timer.Stop();
      Message.Solution("...Result is " + result, timer.ElapsedMilliseconds, result);
    }
  }
}
