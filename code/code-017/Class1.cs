using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_017
{
    internal class Class1
    {
        public class Line
        {

            public int Index { get; set; }

            public int Start { get; set; }

            public int End { get; set; }
        }

        static int range = 0;
        public static void Main()
        {
            var brief = System.Console.ReadLine().Split();
            range = int.Parse(brief[0]);
            int lines = int.Parse(brief[1]);

            Dictionary<int, List<Line>> linestart = new Dictionary<int, List<Line>>();
            for (int i = 0; i < lines; i++)
            {
                var eles = Console.ReadLine().Split();
                var line = new Line { Start = int.Parse(eles[0]), End = int.Parse(eles[1]) };
                if (!linestart.ContainsKey(line.Start))
                {
                    linestart.Add(line.Start, new List<Line>());
                }
                linestart[line.Start].Add(line);
            }

            if (!linestart.ContainsKey(1) || linestart[1].Count < 2)
            {
                Console.WriteLine(0);
                return;
            }

            foreach (var item in linestart)
            {
                item.Value.Sort((a, b) => b.End - a.End);
            }

            var keys = linestart.ToList();
            keys.Sort((a, b) => a.Key - b.Key);

            List<Line> orderedlines = new List<Line>();
            int index = 0;
            for (int i = 0; i < keys.Count; i++)
            {
                var sublist = keys[i].Value;
                for (int j = 0; j < sublist.Count; j++)
                {
                    sublist[j].Index = index++;
                    orderedlines.Add(sublist[j]);
                }
            }

            count = 0;
            Stack<Line> picked = new Stack<Line>();
            for (int i = 0; i < keys[0].Value.Count; i++)
            {
                picked.Clear();
                picked.Push(keys[0].Value[i]);
                Select(orderedlines, i, picked, (0, keys[0].Value[i].End));
            }
            Console.WriteLine(count);
        }

        static int count = 0;
        private static void Select(List<Line> linestart, int index, Stack<Line> picked, (int e1, int e2) end)
        {
            if (end.e1 == range)
            {
                var remaincount = (int)Math.Pow(2, linestart.Count - index - 1);
                count += remaincount;
                return;
            }

            for (int i = index + 1; i < linestart.Count; i++)
            {
                var next = linestart[i];
                var lastpoint = Math.Min(end.e1, end.e2);
                if (next.Start <= lastpoint || next.Start == lastpoint + 1)
                {
                    //if (next.Start == lastpoint + 1)
                    //{

                    //}
                    picked.Push(next);
                    var newend = (end.e1, end.e2);
                    if (next.End > end.e2)
                    {
                        newend = (end.e2, next.End);
                    }
                    else if (next.End > end.e1)
                    {
                        newend = (next.End, end.e2);
                    }
                    Select(linestart, i, picked, newend);
                    var top = picked.Pop();
                    Select(linestart, i, picked, end);
                    break;
                }
            }
        }
    }
}
