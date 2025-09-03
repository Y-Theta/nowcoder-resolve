using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_015
{
    internal class Class1
    {
        static int transthold = 0;
        static int max = 0;
        static int width = 0;
        static int height = 0;

        public class Node
        {
            public int Number { get; set; }

            public long[] Up { get; set; }

            public long[] Down { get; set; }
        }

        public static void Main()
        {
            string[] brief = System.Console.ReadLine().Split();
            int total = int.Parse(brief[0]);
            transthold = int.Parse(brief[1]);
            height = total;
            width = 2 * total - 1;

            var maxstart = transthold + (total - transthold) / 2 + 1;
            Node[,] origin = new Node[total, 2 * total - 1];
            int half = (2 * total - 1) / 2;
            for (int i = 0; i < total; i++)
            {
                string[] line = System.Console.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                    var node = new Node { Number = int.Parse(line[j]), Up = new long[total - i], Down = new long[total - i] };
                    for (int k = 0; k < node.Up.Length; k++)
                    {
                        node.Up[k] = node.Down[k] = 100 * (long)int.MinValue;
                    }
                    origin[i, half - (line.Length / 2) + j] = node;
                    if (i == total - 1)
                    {
                        node.Up[0] = node.Number;
                        node.Down[0] = node.Number;
                    }
                }
            }

            if (total == 1)
            {
                Console.WriteLine(origin[0, 0].Number);
                return;
            }

            for (int r = total - 2; r >= 0; r--)
            {
                int start = total - r - 1;
                int end = start + 2 * r + 1;
                if (r > maxstart)
                {
                    var offset = maxstart - (r - maxstart);
                    //start = Math.Max(start, r - offset);
                    //end = Math.Min(end, r + offset);
                }

                for (int c = start; c < end; c++)
                {
                    CalcMaxSum(origin, origin[r, c], r + 1, c, 0);
                    CalcMaxSum(origin, origin[r, c], r + 1, c + 1, 1);
                    CalcMaxSum(origin, origin[r, c], r + 1, c - 1, -1);
                }
            }

            long max = long.MinValue;
            for (int i = 0; i <= transthold; i++)
            {
                max = Math.Max(origin[0, half].Up[i], max);
                max = Math.Max(origin[0, half].Down[i], max);
            }
            //DFS(origin, 0, half, 0, 0);
            Console.WriteLine(max);
        }

        private static void CalcMaxSum(Node[,] map, Node node, int r, int c, int k)
        {
            var subnode = map[r, c];
            if (subnode == null)
                return;

            for (int i = 0; i < subnode.Up.Length; i++)
            {
                var key = i + k;
                //if (key > transthold + 1 || k < -transthold - 1)
                //    continue;
                long exist = subnode.Up[i] + node.Number;
                if (key > 0)
                {
                    node.Up[key] = Math.Max(node.Up[key], exist);
                }
                else if (key < 0)
                {
                    node.Down[-key] = Math.Max(node.Down[-key], exist);
                }
                else
                {
                    node.Up[0] = node.Down[0] = Math.Max(node.Up[0], exist);
                }
            }

            for (int i = 0; i < subnode.Down.Length; i++)
            {
                var key = -i + k;
                //if (key > transthold + 1 || k < -transthold - 1)
                //    continue;
                long exist = subnode.Down[i] + node.Number;
                if (key > 0)
                {
                    node.Up[key] = Math.Max(node.Up[key], exist);
                }
                else if (key < 0)
                {
                    node.Down[-key] = Math.Max(node.Down[-key], exist);
                }
                else
                {
                    node.Up[0] = node.Down[0] = Math.Max(node.Up[0], exist);
                }
            }
        }

        static Dictionary<(int i, int j, int l), int> dp = new Dictionary<(int i, int j, int l), int>();
        private static void DFS(int[,] tree, int i, int j, int l, int current)
        {
            if (i == height || j == width || (i == (height - 1) && Math.Abs(l) > transthold))
                return;

            current = tree[i, j] + current;
            max = Math.Max(max, current);
            var key = (i, j, l);
            if (dp.TryGetValue(key, out var oldnum))
            {
                if (oldnum > current)
                {
                    return;
                }
            }
            dp[(i, j, l)] = current;
            DFS(tree, i + 1, j, l, current);
            DFS(tree, i + 1, j + 1, l + 1, current);
            DFS(tree, i + 1, j - 1, l - 1, current);
        }

    }
}
