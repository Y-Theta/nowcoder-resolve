using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_007
{
    internal class Class1
    {
        public static void Main()
        {
            int[] patternkeys = new int[26];
            string line = System.Console.ReadLine();
            { // 注意 while 处理多个 case
                string[] tokens = line.Split();
                var n = int.Parse(tokens[0]);
                string key = tokens[n + 1];
                var numberk = int.Parse(tokens[n + 2]);
                int total = 0;
                for (int i = 0; i < key.Length; i++)
                {
                    patternkeys[key[i] - 'a'] += 1;
                }

                List<string> numberkstr = new List<string>();
                for (int i = 1; i < n + 1; i++)
                {
                    if (tokens[i] == key)
                        continue;

                    if (Match(tokens[i], patternkeys))
                    {
                        total++;
                        numberkstr.Add(tokens[i]);
                    }
                }

                System.Console.WriteLine(total);
                numberkstr.Sort((a, b) =>
                {
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (a[i] < b[i])
                            return -1;
                        if (a[i] > b[i])
                            return 1;
                    }

                    return 0;
                });
                if (numberkstr.Count > (numberk - 1))
                {
                    System.Console.WriteLine(numberkstr[numberk - 1]);
                }
            }
        }

        private static bool Match(string str, int[] pattern)
        {
            int[] mypattern = new int[26];
            var strs = str.ToCharArray();
            foreach (var item in strs)
            {
                mypattern[item - 'a'] += 1;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != mypattern[i])
                    return false;
            }

            return true;
        }
    }
}
