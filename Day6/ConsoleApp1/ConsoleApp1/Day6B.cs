using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day6B
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var coords = lines.Select(x => (X: int.Parse(x.Split(", ")[0]), Y: int.Parse(x.Split(", ")[1]))).ToList();

            var r = 0;

            for (var y = 0; y < 1000; y++)
            {
                for (var x = 0; x < 1000; x++)
                {
                    var distances = coords.Sum(c => Math.Abs(c.X - x) + Math.Abs(c.Y - y));

                    r += distances < 10_000 ? 1 : 0;
                }
            }
            
            Console.WriteLine(r); // 42998
        }
    }
}
