using System;

namespace AdventOfCode.Advent2021
{
  public static class Advent2021
  {
    public static void Run()
    {
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Advent of Code 2021");
      Console.WriteLine();
      var exit = false;
      while (!exit)
      {
        Console.WriteLine("Which puzzle do you want run?");
        Console.WriteLine();
        Console.WriteLine("(1)  Day 1, Part 1: Sonar Sweep");
        Console.WriteLine("(2)  Day 1, Part 2: Sonar Sweep");
        Console.WriteLine("(3)  Day 2, Part 1: Dive!");
        Console.WriteLine("(4)  Day 2, Part 2: Dive!");
        Console.WriteLine("(5)  Day 3, Part 1: Binary Diagnostic");
        Console.WriteLine("(6)  Day 3, Part 2: Binary Diagnostic");
        Console.WriteLine();
        Console.WriteLine("(X) Exit to previous menu");

        var key = Console.ReadLine();
        switch (key)
        {
          case "X":
          case "x":
            exit = true;
            break;
          case "1": Day1Part1.Run(); break;
          case "2": Day1Part2.Run(); break;
          case "3": Day2Part1.Run(); break;
          case "4": Day2Part2.Run(); break;
          case "5": Day3Part1.Run(); break;
          case "6": Day3Part2.Run(); break;
          default:
            Console.WriteLine();
            Console.WriteLine("Sorry, that input was not recognized.");
            Console.WriteLine();
            break;
        }
      }
      Console.WriteLine();
      Console.WriteLine();
    }

    /*
    public static void Template()
    {
      Message.Intro("...Runnning Day X, Part Y: Name ");
      using var reader = new StreamReader(@"Advent2021\Resources\inputZ.txt");
      string line;
      var timer = Stopwatch.StartNew();

      while ((line = reader.ReadLine()) != null)
      {
      }

      timer.Stop();
      Message.Solution("...Message", timer.ElapsedMilliseconds, result);
    }
    */
  }
}
