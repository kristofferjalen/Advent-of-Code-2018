using System;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    class Day5B
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("input.txt");
            
            var unique = text.Distinct().ToList();

            var dict = unique.ToDictionary(c => c, c => 0);

            foreach (var u in unique)
            {
                var polymer = text.Replace(u.ToString(), "", StringComparison.InvariantCultureIgnoreCase);

                var i = 0;

                while (i < polymer.Length - 1)
                {
                    if (polymer[i].ToString().ToLower() == polymer[i + 1].ToString().ToLower() &&
                        (char.IsLower(polymer[i]) && char.IsUpper(polymer[i + 1]) ||
                         char.IsUpper(polymer[i]) && char.IsLower(polymer[i + 1])))
                    {
                        polymer = polymer.Remove(i, 2);
                        i = Math.Max(0, i - 2);
                    }
                    else
                        i++;
                }

                dict[u] = polymer.Length;
            }

            var result = dict.OrderBy(x => x.Value).First().Value;

            Console.WriteLine(result); // 5446
        }
    }
}
