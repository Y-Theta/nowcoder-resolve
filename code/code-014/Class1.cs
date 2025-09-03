using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_014
{
    internal class Class1
    {
        public class Rect
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public int Top { get; set; }
            public int Bottom { get; set; }
        }

        public static void Main()
        {
            string[] size = System.Console.ReadLine().Split();
            int h = int.Parse(size[0]);
            int w = int.Parse(size[1]);
            int[,] mn = new int[h, w];
            int startx = 0, starty = 0;
            int endx = 0, endy = 0;
            for (int i = 0; i < h; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < w; j++)
                {
                    if (line[j] == '.')
                    {
                        mn[i, j] = 1;
                    }
                    else if (line[j] == 'S')
                    {
                        mn[i, j] = 1;
                        startx = j;
                        starty = i;
                    }
                    else if (line[j] == 'E')
                    {
                        mn[i, j] = 1;
                        endx = j;
                        endy = i;
                    }
                }
            }

            var range1 = FindMaxRange(mn, startx, starty, w, h);
            var range2 = FindMaxRange(mn, endx, endy, w, h);

            if (IsInterect(range1, range2))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsInterect(Rect r1, Rect r2)
        {
            if (r1.Left < r2.Left)
            {
                if (r1.Right > r2.Left)
                {
                    return true;
                }
                else if (r2.Left - r1.Right < 2)
                {
                    return true;
                }
            }
            else
            {
                if (r1.Left < r2.Right)
                {
                    return true;
                }
                else if (r1.Left - r2.Right < 2)
                {
                    return true;
                }
            }

            if (r1.Top < r2.Top)
            {
                if (r1.Bottom > r2.Top)
                {
                    return true;
                }
                else if (r2.Top - r1.Bottom < 2)
                {
                    return true;
                }
            }
            else
            {
                if (r1.Top < r2.Bottom)
                {
                    return true;
                }
                else if (r1.Top - r2.Bottom < 2)
                {
                    return true;
                }
            }

            return false;
        }

        private static Rect FindMaxRange(int[,] map, int x, int y, int w, int h)
        {
            int xleft = x;
            int xright = x;
            int ytop = y;
            int ybottom = y;
            Stack<(int y, int x)> seedstack = new Stack<(int x, int y)>();
            HashSet<(int y, int x)> visited = new HashSet<(int x, int y)>();
            seedstack.Push((y, x));
            while (seedstack.Count > 0)
            {
                var seed = seedstack.Pop();
                if (seed.x + 1 < w && !visited.Contains((seed.y, seed.x + 1)) && map[seed.y, seed.x + 1] == 1)
                {
                    visited.Add((seed.y, seed.x + 1));
                    seedstack.Push((seed.y, seed.x + 1));
                }
                if (seed.y + 1 < h && !visited.Contains((seed.y + 1, seed.x)) && map[seed.y + 1, seed.x] == 1)
                {
                    visited.Add((seed.y + 1, seed.x));
                    seedstack.Push((seed.y + 1, seed.x));
                }
                if (seed.x - 1 >= 0 && !visited.Contains((seed.y, seed.x - 1)) && map[seed.y, seed.x - 1] == 1)
                {
                    visited.Add((seed.y, seed.x - 1));
                    seedstack.Push((seed.y, seed.x - 1));
                }
                if (seed.y - 1 >= 0 && !visited.Contains((seed.y - 1, seed.x)) && map[seed.y - 1, seed.x] == 1)
                {
                    visited.Add((seed.y - 1, seed.x));
                    seedstack.Push((seed.y - 1, seed.x));
                }
                xleft = System.Math.Min(seed.x, xleft);
                xright = System.Math.Max(seed.x, xright);
                ytop = System.Math.Min(seed.y, ytop);
                ybottom = System.Math.Max(seed.y, ybottom);
            }

            return new Rect { Left = xleft, Top = ytop, Right = xright, Bottom = ybottom };
        }

    }
}
