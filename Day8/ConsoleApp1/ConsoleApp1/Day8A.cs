using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Day8A
    {
        private static int _index;
        private static int[] _tree;

        static void Main(string[] args)
        {
            var text = File.ReadAllText("input.txt");

            _tree = text.Split(' ').Select(int.Parse).ToArray();

            var sum = Rec(0); // 41555

            Console.WriteLine(sum);
        }

        private static int Rec(int sum)
        {
            var c = _tree[_index + 0];
            var m = _tree[_index + 1];

            _index += 2;

            for (var i = 0; i < c; i++)
            {
                sum = Rec(sum);
            }

            var metas = _tree.Skip(_index).Take(m);

            _index = _index + m;

            return sum + metas.Sum();
        }
    }
}
