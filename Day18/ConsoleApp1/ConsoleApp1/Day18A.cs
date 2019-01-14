using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day18A
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var dim = input.Length;

            var area = new char[dim][];

            for (var row = 0; row < dim; row++)
            {
                var line = input[row];
                var arearow = new char[line.Length];
                var chars = line.ToCharArray();
                for (var i = 0; i < chars.Length; i++)
                {
                    arearow[i] = chars[i];
                }
                area[row] = arearow;
            }

            var copy = Copy(area);

            var minutes = 0;
            while (minutes++ < 10)
            {
                for (var y = 0; y < dim; y++)
                {
                    for (var x = 0; x < dim; x++)
                    {
                        var c = area[y][x];
                        if (c == '.')
                        {
                            var adj = Parse(area, dim, x, y, '|');
                            if (adj >= 3)
                                copy[y][x] = '|';
                        }
                        else if (c == '|')
                        {
                            var adj = Parse(area, dim, x, y, '#');
                            if (adj >= 3)
                                copy[y][x] = '#';
                        }
                        else if (c == '#')
                        {
                            var adjL = Parse(area, dim, x, y, '#');
                            var adjT = Parse(area, dim, x, y, '|');
                            if (adjL >= 1 && adjT >= 1)
                                copy[y][x] = '#';
                            else
                                copy[y][x] = '.';
                        }
                    }
                }
                area = Copy(copy);
            }

            var wood = area.SelectMany(x => x).Count(x => x == '|');
            var lumb = area.SelectMany(x => x).Count(x => x == '#');
            var prod = wood * lumb;

            Console.WriteLine(prod); // 560091
        }

        private static int Parse(IReadOnlyList<char[]> area, int dim, int x, int y, char lookFor)
        {
            var count = 0;

            if (y > 0 && x > 0 && area[y - 1][x - 1] == lookFor)
                count++;
            if (y > 0 && area[y - 1][x] == lookFor)
                count++;
            if (y > 0 && x < dim - 1 && area[y - 1][x + 1] == lookFor)
                count++;
            if (x > 0 && area[y][x - 1] == lookFor)
                count++;
            if (x < dim - 1 && area[y][x + 1] == lookFor)
                count++;
            if (y < dim - 1 && x > 0 && area[y + 1][x - 1] == lookFor)
                count++;
            if (y < dim - 1 && area[y + 1][x] == lookFor)
                count++;
            if (y < dim - 1 && x < dim - 1 && area[y + 1][x + 1] == lookFor)
                count++;

            return count;
        }

        private static char[][] Copy(char[][] area)
        {
            var dim = area.GetLength(0);
            var copy = new char[dim][];
            for (var y = 0; y < dim; y++)
            {
                var arearow = new char[dim];
                for (var x = 0; x < dim; x++)
                {
                    arearow[x] = area[y][x];
                }
                copy[y] = arearow;
            }
            return copy;
        }
    }
}