using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_013
{
    internal class Class1
    {
        public static void Main()
        {
            string[] line = System.Console.ReadLine().Split();
            int count = int.Parse(line[0]);
            int head = int.Parse(line[1]);
            int delete = int.Parse(line[line.Length - 1]);

            int[] linkedlist = new int[10000];
            for (int i = 2; i < line.Length - 1; i += 2)
            {
                var th = int.Parse(line[i]);
                var tt = int.Parse(line[i + 1]);

                if (linkedlist[tt] == 0)
                {
                    linkedlist[tt] = th;
                }
                else
                {
                    var next = linkedlist[tt];
                    linkedlist[th] = next;
                    linkedlist[tt] = th;
                }
            }

            var temps = head;
            string str = "";
            while (temps > 0)
            {
                if (temps != delete)
                {
                    str += $"{temps} ";
                }
                temps = linkedlist[temps];
            }

            Console.WriteLine(str.Trim());
        }
    }
}
