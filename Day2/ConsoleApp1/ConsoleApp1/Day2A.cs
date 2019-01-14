using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day2A
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var foo = lines.Select(line => line.ToCharArray().GroupBy(x => x).Select(g => new
            {
                g.Key,
                Count = g.Count()
            })).ToList();

            var foo1 = foo.Sum(gg => gg.Any(x => x.Count == 2) ? 1 : 0);
            var foo2 = foo.Sum(gg => gg.Any(x => x.Count == 3) ? 1 : 0);

            Console.WriteLine(foo1 * foo2); // 6225
        }
    }
}
