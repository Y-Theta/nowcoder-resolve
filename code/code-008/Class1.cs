using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_008
{
    internal class Class1
    {
        public static void Main()
        {
            string line = System.Console.ReadLine();
            string[] tokens = line.Split();
            int keylen = int.Parse(tokens[0]);
            int opttime = int.Parse(tokens[1]);
            var tokenpattern = System.Console.ReadLine().ToList();
            var iindexleft = tokenpattern.IndexOf('I');
            var iindexright = iindexleft;
            for (int i = 0; i < opttime; i++)
            {
                var opt = System.Console.ReadLine();
                if (opt[0] == 'b')
                {
                    if (iindexleft == 0)
                        continue;
                    if (iindexright + 1 < tokenpattern.Count && tokenpattern[iindexleft - 1] == '(' && tokenpattern[iindexright + 1] == ')')
                    {
                        tokenpattern[iindexleft - 1] = ' ';
                        tokenpattern[iindexright + 1] = ' ';
                        iindexleft = iindexleft - 1;
                        iindexright = iindexright + 1;
                    }
                    else
                    {
                        tokenpattern[iindexleft - 1] = ' ';
                        iindexleft = iindexleft - 1;
                    }
                }
                else
                {
                    if (iindexright + 1 < tokenpattern.Count)
                    {
                        tokenpattern[iindexright + 1] = ' ';
                        iindexright = iindexright + 1;
                    }
                }
            }

            foreach (var item in tokenpattern)
            {
                if (item == ' ')
                    continue;
                Console.Write(item);
            }
        }
    }
}
