using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day1A
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var sum = lines.Sum(int.Parse);

            Console.WriteLine(sum); // 416
        }
    }
}
