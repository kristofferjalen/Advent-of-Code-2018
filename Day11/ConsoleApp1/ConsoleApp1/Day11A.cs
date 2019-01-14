using System;

namespace ConsoleApp1
{
    class Day11A
    {
        static void Main(string[] args)
        {
            const int serial = 3613;

            var max = int.MinValue;
            var maxCell = (0, 0);
            for (var y = 1; y <= 298; y++)
            {
                for (var x = 1; x <= 298; x++)
                {
                    var total = 
                        Power((x, y), serial)
                        + Power((x + 1, y), serial)
                        + Power((x + 2, y), serial)
                        + Power((x, y + 1), serial)
                        + Power((x + 1, y + 1), serial)
                        + Power((x + 2, y + 1), serial)
                        + Power((x, y + 2), serial)
                        + Power((x + 1, y + 2), serial)
                        + Power((x + 2, y + 2), serial);

                    if (total <= max)
                        continue;

                    max = total;
                    maxCell = (x, y);
                }
            }

            Console.WriteLine(maxCell); // (20, 54)
        }

        private static int Power((int X, int Y) cell, int serial)
        {
            var (x, y) = cell;
            var rackId = x + 10;
            var foo1 = rackId * y;
            var foo2 = foo1 + serial;
            var foo3 = foo2 * rackId;
            var hundred = foo3 / 100 % 10;
            var foo4 = hundred - 5;
            return foo4;
        }
    }
}