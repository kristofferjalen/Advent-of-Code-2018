using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day3A
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var inches = new Dictionary<(int, int), int>();

            foreach (var line in lines)
            {
                var left = int.Parse(line.Substring(line.IndexOf('@') + 2, line.IndexOf(',') - (line.IndexOf('@') + 2)));
                var top = int.Parse(line.Substring(line.IndexOf(',') + 1, line.IndexOf(':') - (line.IndexOf(',') + 1)));
                var width = int.Parse(line.Substring(line.IndexOf(':') + 2, line.IndexOf('x') - (line.IndexOf(':') + 2)));
                var height = int.Parse(line.Substring(line.IndexOf('x') + 1));

                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        if (!inches.ContainsKey((left + x, top + y)))
                        {
                            inches.Add((left + x, top + y), 0);
                        }
                        inches[(left + x, top + y)]++;
                    }
                }
            }

            var sum = inches.Count(x => x.Value >= 2);
            Console.WriteLine(sum); // 105231
        }
    }
}
