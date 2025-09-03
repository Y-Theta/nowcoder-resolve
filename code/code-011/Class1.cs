using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_11
{
    internal class Class1
    {

        public static void Main()
        {
            string line = System.Console.ReadLine();
            int count = int.Parse(line);
            string trains = System.Console.ReadLine();
            List<int> trainnumbers = trains.Split().Select(x => int.Parse(x)).ToList();

            int[] stack = new int[1];
            stack[0] = trainnumbers[0];
            Func(trainnumbers, 1, stack, new int[11]);
            finalResult.Sort((a, b) =>
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < b[i])
                        return -1;
                    if (a[i] > b[i])
                        return 1;
                }

                return 0;
            });

            foreach (var item in finalResult)
            {
                var len = item[0];
                for (int i = 0; i < len; i++)
                {
                    Console.Write(item[i + 1]);
                    if (i != len - 1)
                    {
                        Console.Write(' ');
                    }
                }
                Console.Write("\n");
            }
        }

        static List<int[]> finalResult = new List<int[]>();
        private static void Func(List<int> orieles, int current, int[] stack, int[] str)
        {
            if (current > orieles.Count)
                return;

            int[] newstrcopy = new int[11];
            Array.Copy(str, newstrcopy, str.Length);
            for (int i = stack.Length - 1; i >= 0; i--)
            {
                int[] substack = new int[i + 1];
                if (current < orieles.Count)
                {
                    Array.Copy(stack, 0, substack, 0, i);
                    substack[i] = orieles[current];
                }
                newstrcopy[str[0] + stack.Length - i] = stack[i];
                newstrcopy[0]++;
                var newstr = new int[11];
                Array.Copy(newstrcopy, newstr, newstrcopy.Length);
                if (current < orieles.Count)
                {
                    Func(orieles, current + 1, substack, newstr);
                }
                else
                {
                    if (newstr[0] == orieles.Count)
                    {
                        finalResult.Add(newstr);
                    }
                }
            }

            var newstack = new int[stack.Length + 1];
            if (current < orieles.Count)
            {
                Array.Copy(stack, newstack, stack.Length);
                newstack[stack.Length] = orieles[current];
                Func(orieles, current + 1, newstack, str);
            }
        }

    }
}
