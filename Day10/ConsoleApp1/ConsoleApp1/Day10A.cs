using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day10A
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var positions = new List<(int X, int Y, int Xd, int Yd)>();

            foreach (var line in input)
            {
                var x = int.Parse(line.Substring(10, line.IndexOf(",") - 10).Trim());
                var y = int.Parse(line.Substring(line.IndexOf(",") + 1, line.IndexOf(">") - (line.IndexOf(",") + 1)).Trim());
                var xd = int.Parse(line.Substring(line.LastIndexOf("<") + 1, line.LastIndexOf(",") - (line.LastIndexOf("<") + 1)).Trim());
                var yd = int.Parse(line.Substring(line.LastIndexOf(",") + 1, line.LastIndexOf(">") - (line.LastIndexOf(",") + 1)).Trim());
                positions.Add((x, y, xd, yd));
            }

            var lastDistX = int.MaxValue;
            var lastDistY = int.MaxValue;

            while (true)
            {
                var positions2 = new List<(int X, int Y, int Xd, int Yd)>();

                foreach (var p in positions)
                {
                    var (x, y, xd, yd) = p;
                    positions2.Add((x + xd, y + yd, xd, yd));
                }

                var ordered = positions2.OrderBy(x => x.Y).ToArray();

                var minX = ordered.Min(x => x.X);
                var maxX = ordered.Max(x => x.X);
                if (maxX - minX > lastDistX)
                    break;
                lastDistX = maxX - minX;

                var minY = ordered.Min(x => x.Y);
                var maxY = ordered.Max(x => x.Y);
                if (maxY - minY > lastDistY)
                    break;
                lastDistY = maxY - minY;

                for (var i = 0; i < positions.Count; i++)
                {
                    positions[i] = positions2[i];
                }
            }

            Output(positions, 
                positions.Min(x => x.X), 
                positions.Max(x => x.X),
                positions.Min(x => x.Y), 
                positions.Max(x => x.Y)); // PPNJEENH

            Console.ReadLine();
        }

        private static void Output(IEnumerable<(int X, int Y, int Xd, int Yd)> ordered, int minX, int maxX, int minY, int maxY)
        {
            var width = Math.Abs(minX) + Math.Abs(maxX) + 1;
            var height = Math.Abs(minY) + Math.Abs(maxY) + 1;

            var s = string.Join("", Enumerable.Repeat(".", width));
            var dots = new List<string>(height);
            for (var d = 0; d < height; d++)
            {
                dots.Add(s);
            }

            var grouped = ordered.GroupBy(x => x.Y, x => new
            {
                x = x.X,
                _x = x.Xd,
                _y = x.Yd
            });

            foreach (var line in grouped)
            {
                foreach (var item in line)
                {
                    var ax = dots[line.Key + Math.Abs(minY)].ToCharArray();
                    ax[item.x + Math.Abs(minX)] = '#';
                    dots[line.Key + Math.Abs(minY)] = string.Join("", ax);
                }
            }

            dots.ForEach(Console.WriteLine);
        }
    }
}