using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_004
{
    internal class Class1
    {
        public static void Main()
        {
            string line = System.Console.ReadLine();
            int[] strs = new int[128];
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                strs[c]++;
            }

            for (int i = 0; i < 128; i++)
            {
                for (int k = strs[i]; k > 0; k--)
                {
                    System.Console.Write((char)i);
                }
            }
        }
    }
}
