using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day14A
    {
        static void Main(string[] args)
        {
            const int stop = 084601;

            var board = new List<int> { 3, 7 };

            var elfIndex1 = 0;
            var elfIndex2 = 1;

            while (board.Count < stop + 10)
            {
                var rec1 = board[elfIndex1];
                var rec2 = board[elfIndex2];
                var sum = rec1 + rec2;

                var digits = sum.ToString().Length;
                for (var i = digits; i >= 1; i--)
                {
                    var recipe = (int)(sum / Math.Pow(10, i - 1)) % 10;
                    board.Add(recipe);
                }

                elfIndex1 = (elfIndex1 + 1 + rec1) % board.Count;
                elfIndex2 = (elfIndex2 + 1 + rec2) % board.Count;
            }

            var foo = board.Skip(stop).Take(10).ToList();
            var s = "";
            for (var i=0; i< 10; i++)
            {
                s += foo[i];
            }

            Console.WriteLine(s); // 2688510125
        }
    }
}