using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day7A
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            
            var steps = lines
                .Select(x => new
                {
                    Step = x.Substring(x.IndexOf(" can") - 1, 1),
                    Requires = x.Substring(x.IndexOf(" must") - 1, 1)
                })
                .GroupBy(x => x.Step,
                    x => x.Requires,
                    (key, g) => new { Step = key, Requires = g.ToList() })
                .ToDictionary(x => x.Step, x => x.Requires);

            var allsteps = steps
                .Values
                .SelectMany(x => x)
                .Concat(steps.Keys)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var finished = new List<string>();

            var i = 0;
            while (i < allsteps.Count && allsteps.Count > 0)
            {
                var step = allsteps[i++];
                if (steps.ContainsKey(step) && !steps[step].All(x => finished.Contains(x)))
                    continue;

                finished.Add(step);
                allsteps.Remove(step);
                i = 0;
            }

            var result = string.Join("", finished.Select(x => x));

            Console.WriteLine(result); // ACHOQRXSEKUGMYIWDZLNBFTJVP
        }
    }
}
