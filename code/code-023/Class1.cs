using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_023
{
    internal class Class1
    {
        public class NumFact
        {
            public List<int> Factors { get; set; } = new List<int>();

            public int Min { get; set; }
        }

        public static void Main()
        {
            int total = int.Parse(System.Console.ReadLine());
            var allnums = System.Console.ReadLine().Split();
            int[] dic = new int[1000];
            int max = (int)Math.Sqrt(1000);
            for (int i = 2; i <= max; i++)
            {
                if (dic[i] > 0)
                {
                    continue;
                }
                for (int j = 2; i * j < 1000; j++)
                {
                    dic[i * j] = 1;
                }
            }

            List<int> nums = new List<int>();
            for (int i = 2; i < 1000; i++)
            {
                if (dic[i] == 0)
                {
                    nums.Add(i);
                }
            }

            HashSet<int> allfactors = new HashSet<int>();
            List<NumFact> numbfs = new List<NumFact>();
            int[,] differents = new int[total, nums.Count];
            for (int i = 0; i < allnums.Length; i++)
            {
                var tnum = int.Parse(allnums[i]);
                NumFact numbf = new NumFact();
                for (int j = 0; j < nums.Count; j++)
                {
                    if (nums[j] > tnum)
                        break;
                    var factor = nums[j];
                    bool isfactor = tnum % factor == 0;
                    if (!isfactor)
                        continue;
                    allfactors.Add(factor);
                    numbf.Factors.Add(factor);
                }
                if (numbf.Factors.Count == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                numbf.Min = numbf.Factors.Min();
                numbfs.Add(numbf);
            }

            if (allfactors.Count < total)
            {
                Console.WriteLine(-1);
                return;
            }

            numbfs.Sort((a, b) => a.Min - b.Min);
            Stack<int> selected = new Stack<int>();
            Select(numbfs, 0, 0, selected);

            if (flag)
            {
                Console.WriteLine(min);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        static int min = int.MaxValue - 10;
        static bool flag = false;
        private static void Select(List<NumFact> numbfs, int current, int currentfactor, Stack<int> selected)
        {
            if (numbfs.Count > current && current >= 0)
            {
                var numbf = numbfs[current];
                for (int i = 0; i < numbf.Factors.Count; i++)
                {
                    if (numbf.Factors[i] <= currentfactor)
                        continue;

                    var factor = numbf.Factors[i];
                    if (!selected.Contains(factor))
                    {
                        selected.Push(factor);
                        if (selected.Count == numbfs.Count)
                        {
                            flag = true;
                            min = Math.Min(min, selected.Sum());
                        }
                        Select(numbfs, current + 1, 0, selected);
                        if (selected.Count > 0)
                        {
                            selected.Pop();
                        }
                    }
                }

                if (selected.Count == 0)
                    return;

                var last = selected.Pop();
                Select(numbfs, current - 1, last, selected);
            }
        }
    }
}
