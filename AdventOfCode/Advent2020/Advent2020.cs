using System;

namespace AdventOfCode.Advent2020
{
    public static class Advent2020
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Advent of Code 2020");
            Console.WriteLine();
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("Which puzzle do you want run?");
                Console.WriteLine();
                Console.WriteLine("(1) Day 1, Part 1: Verify expense report with two values");
                Console.WriteLine("(2) Day 1, Part 2: Verify expense report with three values");
                Console.WriteLine("(3) Day 2, Part 1: Finding valid passwords with the wrong policies");
                Console.WriteLine("(4) Day 2, Part 2: Finding valid passwords with the right policies");
                Console.WriteLine("(5) Day 3, Part 1: Count the number of trees encountered with a -1/3 slope");
                Console.WriteLine("(6) Day 3, Part 2: Count the number of trees encountered with several slopes, and multiply them");
                Console.WriteLine();
                Console.WriteLine("(X) Exit to previous menu");

                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'X':
                    case 'x':
                        exit = true;
                        break;
                    case '1': Day1Part1.Run(); break;
                    case '2': Day1Part2.Run(); break;
                    case '3': Day2Part1.Run(); break;
                    case '4': Day2Part2.Run(); break;
                    case '5': Day3Part1.Run(); break;
                    case '6': Day3Part2.Run(); break;
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
    }
}
