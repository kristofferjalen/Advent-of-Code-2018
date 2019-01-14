using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Day1B
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var frequencies = new List<int>();
            int sum = 0, i = 0;
            while (true)
            {
                sum += int.Parse(lines[i++ % lines.Length]);

                if (frequencies.Contains(sum))
                    break;

                frequencies.Add(sum);
            }

            Console.WriteLine(sum); // 56752
        }
    }
}
