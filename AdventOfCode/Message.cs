using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    public static class Message
    {
        // set this to true if you want a lot of diagnostic messages
        public static bool Verbose = false;
        public static void Intro(string description)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(description);
        }

        public static void Solution(string description, long time, object value)
        {
            Console.WriteLine(description);
            Console.WriteLine("Elapsed time was " + time + " ms.");
            Console.Write("Solution: ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(value.ToString());
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Error(string preamble, string detail)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(preamble);
            Console.ResetColor();
            Console.Write(detail + Environment.NewLine);
        }

        public static void Success(string preamble, string detail)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(preamble);
            Console.ResetColor();
            Console.Write(detail);
        }
    }
}
