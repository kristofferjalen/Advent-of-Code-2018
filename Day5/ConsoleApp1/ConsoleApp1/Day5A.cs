using System;
using System.IO;

namespace ConsoleApp1
{
    class Day5A
    {
        static void Main(string[] args)
        {
            var polymer = File.ReadAllText("input.txt");

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

            Console.WriteLine(polymer.Length); // 11476
        }
    }
}
