using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode.Advent2021
{
  public static class Day3Part2
  {
    public static void Run()
    {
      Message.Intro("...Runnning Day 3, Part 2: Binary Diagnostics ");
      using var reader = new StreamReader(@"Advent2021\Resources\input3.txt");
      string line;
      var timer = Stopwatch.StartNew();

      // count the number of 1s in each ordinal
      var count1s = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      int total = 0;
      while ((line = reader.ReadLine()) != null)
      {
        string countString = line.GetNumbers();
        total++;
        for (int i = 0; i < countString.Length; i++)
          if (countString[i] == '1') count1s[i]++;
      }

      // create a string of the most common entry in each ordinal
      int half = total / 2;
      var oxygenList = count1s.Select(x =>
      {
        if (x >= 500) return 1;
        return 0;
      });
      var oxygenString = string.Join(string.Empty, oxygenList);
      // create a string of the least common entry in each orderinal
      var co2List = count1s.Select(x =>
      {
        if (x > 500) return 0;
        return 1;
      });
      var co2String = string.Join(string.Empty, co2List);

      // back to the start of the file
      reader.DiscardBufferedData();
      reader.BaseStream.Seek(0, SeekOrigin.Begin);
      string oxygenCandidate = string.Empty, co2Candidate = string.Empty;

      // look for the string that most closely matches the most/least common strings from left to right
      uint oxygenRecord = 0, co2Record = 0;
      while ((line = reader.ReadLine()) != null)
      {
        string trial = line.GetNumbers();
        uint oxygenMatch = StringMatch(trial, oxygenString);
        if (oxygenMatch > oxygenRecord)
        {
          oxygenCandidate = trial;
          oxygenRecord = oxygenMatch;
        }
        uint co2Match = StringMatch(trial, co2String);
        if (co2Match > co2Record)
        {
          co2Candidate = trial;
          co2Record = co2Match;
        }
      }

      uint oxygen = Convert.ToUInt32(oxygenCandidate, 2);
      uint co2 = Convert.ToUInt32(co2Candidate, 2);
      uint result = oxygen * co2;

      timer.Stop();
      Message.Solution("...Message", timer.ElapsedMilliseconds, result);
    }

    private static uint StringMatch(string first, string second)
    {
      int count = Math.Max(first.Length, second.Length);

      uint matches = 0;
      for(int i = 0; i < count; i++)
      {
        if (first[i] == second[i]) matches++;
        else break;
      }
      return matches;
    }

    public static string GetNumbers(this string me)
    {
      return new string(me.Where(x => char.IsDigit(x)).ToArray());
    }
  }
}
