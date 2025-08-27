using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_001
{
    public class Class1
    {
        public static void Main()
        {
            string line;
            while ((line = System.Console.ReadLine()) != null)
            { // 注意 while 处理多个 case
                if (int.TryParse(line, out var num))
                {
                    int sum = 0;
                    if (num == 0)
                    {
                        break;
                    }
                    int left = 0;
                    while (num >= 3)
                    {
                        left = num % 3;
                        int newnum = num / 3;
                        sum += newnum;
                        num = newnum + left;
                    }
                    if (num > 1)
                    {
                        sum += 1;
                    }
                    System.Console.WriteLine(sum);
                }
                else
                {
                    System.Console.WriteLine();
                }
            }
        }
    }
}
