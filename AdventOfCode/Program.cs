using System;

namespace AdventOfCode
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
                Console.WriteLine("Which Advent of Code year do you want to run?");
                Console.WriteLine();
                Console.WriteLine("(1) Advent of Code 2020");
                Console.WriteLine();
                Console.WriteLine("(X) Exit program");

                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'X':
                    case 'x':
                        exit = true;
                        break;
                    case '1': Advent2020.Advent2020.Run(); break;
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
