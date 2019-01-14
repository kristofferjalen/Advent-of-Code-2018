using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day6A
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var coords = lines.Select(x => (X: int.Parse(x.Split(", ")[0]), Y: int.Parse(x.Split(", ")[1]))).ToList();

            var d = new Dictionary<(int, int), int>();

            var infinites = new List<int>();

            for (var y = 0; y < 1000; y++)
            {
                for (var x = 0; x < 1000; x++)
                {
                    var distances = coords
                        .Select((c, i) => (i, dist: Math.Abs(c.X - x) + Math.Abs(c.Y - y)))
                        .OrderBy(a => a.dist)
                        .ToArray();

                    if (distances[0].dist != distances[1].dist)
                    {
                        d[(x, y)] = distances[0].i;
                    }

                    if (x == 0 || x == 999 || y == 0 || y == 999)
                    {
                        infinites.Add(distances[0].i);
                    }
                }
            }

            var max = d
                .Where(c => !infinites.Contains(c.Value))
                .GroupBy(c => c.Value)
                .Select(c => new { c.Key, count = c.Count() })
                .Max(c => c.count);

            Console.WriteLine(max); // 3006
        }
    }
}
