using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_024
{
    internal class Class1
    {
        static int L = 0;
        static int R = 0;
        public static void Main()
        {
            var briefs = System.Console.ReadLine().Split();
            int count = int.Parse(briefs[0]);
            L = int.Parse(briefs[1]);
            R = int.Parse(briefs[2]);
            var strs = Console.ReadLine();
            int[] count0 = new int[count];
            int[] count1 = new int[count];
            if (strs[0] == '0')
            {
                count0[0] = 1;
            }
            else
            {
                count1[0] = 1;
            }
            int count1sum = 0;
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i] == '0')
                {
                    count0[i] = count0[i - 1] + 1;
                    count1[i] = count1[i - 1];
                }
                else
                {
                    count1sum++;
                    count0[i] = count0[i - 1];
                    count1[i] = count1[i - 1] + 1;
                }
            }

            for (int i = 0; i < strs.Length; i++)
            {
                count1[i] = count1sum - count1[i];
            }

            var max = Split(count1, count0, strs, 0, strs.Length - 1);
            Console.WriteLine(max);
        }

        private static int Split(int[] count1, int[] count0, string strs, int start, int end)
        {
            int n = 0;
            if (start == end)
                return n;
            int count0start = strs[start] == '0' ? 1 : 0;
            int count0offset = count0[start];
            int count1offset = count1[end - 1];
            for (int i = start; i < end; i++)
            {
                int val = count1[i] - count1offset - (count0[i] - count0offset + count0start);
                if ((val >= L && val <= R) || (val <= -L && val >= -R))
                {
                    int k = 0;
                    k += Split(count1, count0, strs, start, i);
                    k += Split(count1, count0, strs, i + 1, end);
                    n = Math.Max(k + 1, n);
                }
            }
            return n;
        }
    }
}
