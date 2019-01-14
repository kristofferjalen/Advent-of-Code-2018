using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day4B
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var ordered = lines.Select(line => new { line, date = DateTime.Parse(line.Substring(1, 16)) })
                .Select(t => (t.date, t.line.Substring(19))).OrderBy(x => x.date);

            var dict = new Dictionary<string, Dictionary<int, int>>();

            var guard = "";
            var start = 0;
            foreach (var (date, text) in ordered)
            {
                if (text.StartsWith("Guard"))
                {
                    guard = text.Split(' ')[1];
                }
                else if (text == "falls asleep")
                {
                    start = date.Minute;
                }
                else if (text == "wakes up")
                {
                    if (!dict.ContainsKey(guard))
                    {
                        dict.Add(guard, new Dictionary<int, int>());
                    }
                    var minutes = dict[guard];
                    for (var i = 0; i < date.Minute - start; i++)
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

            var g = dict.Select(x => new
            {
                Id = x.Key,
                Minutes = x.Value.OrderByDescending(z => z.Value)
            }).OrderByDescending(x => x.Minutes.First().Value).ToList();

            var id = int.Parse(g.First().Id.Substring(1));
            var minute = g.First().Minutes.First().Key;
            var answer = id * minute;

            Console.WriteLine(answer); // 4727
        }
    }
}
