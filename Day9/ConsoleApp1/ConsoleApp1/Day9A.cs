using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day9A
    {
        static void Main(string[] args)
        {
            const int players = 423;
            const int lastMarble = 71944;

            var circle = new LinkedList<int>();
            var scores = Enumerable.Repeat(0, players).ToList();

            var player = 0;
            var marble = 0;
            var current = 0;

            circle.AddFirst(marble);

            while (current <= lastMarble)
            {
                marble++;
                player = (player + 1) % players;

                if (marble % 23 == 0)
                {
                    scores[player] += marble;

                    var remove = circle.Find(current).GetPrevious().GetPrevious().GetPrevious().GetPrevious().GetPrevious().GetPrevious().GetPrevious();
                    scores[player] += remove.Value;
                    current = remove.GetNext().Value;
                    circle.Remove(remove);
                }
                else
                {
                    if (circle.Count == 1)
                    {
                        circle.AddLast(marble);
                        current = marble;
                    }
                    else
                    {
                        var c = circle.Find(current).GetNext().GetNext();

                        if (c == circle.First)
                            circle.AddLast(marble);
                        else
                            circle.AddBefore(c, marble);
                        current = marble;
                    }
                }

            }

            var highscore = scores.Max();

            Console.WriteLine(highscore); // 418237
        }

    }


    public static class Extensions
    {
        public static LinkedListNode<int> GetNext(this LinkedListNode<int> node) => node.Next ?? node.List.First;

        public static LinkedListNode<int> GetPrevious(this LinkedListNode<int> node) => node.Previous ?? node.List.Last;
    }
}