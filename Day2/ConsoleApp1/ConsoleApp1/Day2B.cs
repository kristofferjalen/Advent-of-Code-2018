using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day2B
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input.txt");

            var outer = 0;
            while (outer < lines.Length)
            {
                var inner = 0;
                while (inner < lines.Length)
                {
                    var diffs = lines[outer].Select((c, index) => c != lines[inner][index] ? 1 : 0).Sum();
                    if (diffs == 1)
                    {
                        var result = string.Join("", lines[outer].Where((c, index) => lines[inner][index] == lines[outer][index]));
                        Console.WriteLine(result); // revtaubfniyhsgxdoajwkqilp
                        outer = inner = lines.Length;
                    }
                    inner++;
                }
                outer++;
            }
        }
    }
}
