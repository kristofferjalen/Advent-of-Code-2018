using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day4A
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            /*
                [1518-09-27 00:54] wakes up
                [1518-07-09 00:00] Guard #2153 begins shift
                [1518-04-11 00:37] falls asleep
             */

            var list = new List<(DateTime, string)>();

            foreach (var line in lines)
            {
                var date = DateTime.Parse(line.Substring(1, 16));
                list.Add((date, line.Substring(19)));
            }

            var ordered = list.OrderBy(x => x.Item1);

            var dict = new Dictionary<string, Dictionary<int, int>>();

            var guard = "";
            var start = 0;
            foreach (var line in ordered)
            {
                if (line.Item2.StartsWith("Guard"))
                {
                    guard = line.Item2.Split(' ')[1];
                }
                if (line.Item2 == "falls asleep")
                {
                    start = line.Item1.Minute;
                }
                if (line.Item2 == "wakes up")
                {
                    if (!dict.ContainsKey(guard))
                    {
                        dict.Add(guard, new Dictionary<int, int>());
                    }
                    var length = line.Item1.Minute - start;
                    var minutes = dict[guard];
                    for (var i=0; i < length; i++)
                    {
                        if (!minutes.ContainsKey(start + i))
                        {
                            minutes.Add(start + i, 0);
                        }
                        minutes[start + i]++;
                    }
                    dict[guard] = minutes;
                }
            }

            var g = dict.OrderByDescending(x => x.Value.Sum(y => y.Value)).First(); // 1601
            var asdfasdf = g.Value.OrderByDescending(z => z.Value).First().Key; // 46

            // 73646



        }
    }
}
