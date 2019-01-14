using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Day3B
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

            foreach (var line in lines)
            {
                var left = int.Parse(line.Substring(line.IndexOf('@') + 2, line.IndexOf(',') - (line.IndexOf('@') + 2)));
                var top = int.Parse(line.Substring(line.IndexOf(',') + 1, line.IndexOf(':') - (line.IndexOf(',') + 1)));
                var width = int.Parse(line.Substring(line.IndexOf(':') + 2, line.IndexOf('x') - (line.IndexOf(':') + 2)));
                var height = int.Parse(line.Substring(line.IndexOf('x') + 1));

                var skip = false;
                for (var y = 0; y < height; y++)
                {
                    if (skip)
                    {
                        break;
                    }

                    for (var x = 0; x < width; x++)
                    {
                        if (inches[(left + x, top + y)] > 1)
                        {
                            skip = true;
                            break;
                        }

                        if (x != width - 1 || y != height - 1)
                            continue;

                        Console.WriteLine(line); // #164 @ 351,608: 12x15
                        break;
                    }
                }
            }
        }
    }
}
