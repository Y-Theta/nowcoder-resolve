using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_018
{
    internal class Class1
    {

        public class Point : IEqualityComparer<Point>
        {
            public static Point Empty = new Point(0, 0);

            public Point(int r, int c)
            {
                R = r;
                C = c;
            }

            public int R { get; set; }

            public int C { get; set; }

            public bool Equals(Point x, Point y)
            {
                return x.R == y.R && x.C == y.C;
            }

            public int GetHashCode(Point obj)
            {
                return R * 1000 + C;
            }
        }

        static int m = 0;
        static int n = 0;
        public static void Main()
        {
            string[] line = System.Console.ReadLine().Split();
            n = int.Parse(line[0]);
            m = int.Parse(line[1]);
            int[,] matrix = new int[n, m];
            for (int r = 0; r < n; r++)
            {
                var words = Console.ReadLine().Split();
                for (int c = 0; c < m; c++)
                {
                    matrix[r, c] = int.Parse(words[c]);
                }
            }

            int[,] delayMap = new int[n, m];
            //ISet<Point>[] delayList = new ISet<Point>[m + n];
            int blocklist = int.Parse(Console.ReadLine());
            for (int i = 0; i < blocklist; i++)
            {
                var words = Console.ReadLine().Split();
                int delay = int.Parse(words[2]);
                int tn = int.Parse(words[0]) - 1;
                int tm = int.Parse(words[1]) - 1;
                //var p = new Point(int.Parse(words[0]) - 1, int.Parse(words[1]) - 1);
                //if (delayList[delay] == null)
                //{
                //    delayList[delay] = new HashSet<Point>(Point.Empty);
                //}
                //delayList[delay].Add(p);
                delayMap[tn, tm] = delay;
            }

            int max = 0;
            int[,] dp = new int[n, m];
            dp[0, 0] = matrix[0, 0];
            max = Math.Max(dp[0, 0], max);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    var k = r + c;
                    if (k < 0 || dp[r, c] != 0)
                        continue;

                    var step = delayMap[r, c];
                    if (step > 0 && step <= k)
                    {
                        dp[r, c] = int.MinValue;
                        continue;
                    }

                    int left = int.MinValue;
                    if (c - 1 >= 0)
                    {
                        left = dp[r, c - 1];
                    }
                    int top = int.MinValue;
                    if (r - 1 >= 0)
                    {
                        top = dp[r - 1, c];
                    }
                    int num = dp[r, c] = Math.Max(left + matrix[r, c], top + matrix[r, c]);
                    max = Math.Max(num, max);
                }
            }
            //var stack = new Stack<(int r,int c)>();
            //stack.Push((0, 0));
            //Tranverse(matrix, 0, 0, stack, delayMap, matrix[0, 0]);

            Console.WriteLine(max);
        }

        static int max = 0;
        private static void Tranverse(int[,] matrix, int r, int c, Stack<(int r, int c)> posstack, int[,] delayList, int val)
        {
            var pointrightr = r;
            var pointrightc = c + 1;
            var pointdownr = r + 1;
            var pointdownc = c;
            bool canright = pointrightc < m && pointrightr < n && (delayList[pointrightr, pointrightc] == 0 || delayList[pointrightr, pointrightc] > posstack.Count);
            bool candown = pointdownr < n && pointdownc < m && (delayList[pointdownr, pointdownc] == 0 || delayList[pointdownr, pointdownc] > posstack.Count);

            if (canright)
            {
                posstack.Push((pointrightr, pointrightc));
                Tranverse(matrix, pointrightr, pointrightc, posstack, delayList, val + matrix[pointrightr, pointrightc]);
                posstack.Pop();
            }

            if (candown)
            {
                posstack.Push((pointdownr, pointdownc));
                Tranverse(matrix, pointdownr, pointdownc, posstack, delayList, val + matrix[pointdownr, pointdownc]);
                posstack.Pop();
            }

            if (!candown && !canright)
            {
                max = Math.Max(max, val);
            }
        }

    }
}
