using System;

namespace Advent2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, Occupant.");
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
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that input was not recognized.");
                        Console.WriteLine();
                        break;
                }
            }
            Console.WriteLine("Goodbye, Occupant.");
            Console.ReadKey();
        }
    }
}
