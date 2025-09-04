using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_020
{
    internal class Class1
    {
        public static void Main()
        {
            int data = int.Parse(System.Console.ReadLine());

            int left = data % 7;
            int need7 = data / 7;
            if (left == 0)
            {
                Console.WriteLine(need7);
                return;
            }

            if (left > 5)
            {
                Console.WriteLine(need7 + 1 + (left - 5));
                return;
            }
            else
            {
                int remain1 = need7 + left;
                for (int i = 0; i < left; i++)
                {
                    int remain5 = (left + 7 * i) / 5 + (left + 7 * i) % 5 + need7 - i;
                    remain1 = Math.Min(remain1, remain5);
                }

                Console.WriteLine(remain1);
            }
        }
    }
}
