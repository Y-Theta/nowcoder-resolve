using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_003
{
    internal class Class1
    {
        public static void Main()
        {
            string line;
            while ((line = System.Console.ReadLine()) != null)
            {
                line = line.ToUpper();
                double sum = 0;
                int pow = 0;
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    int num = 0;
                    var c = line[i];
                    if (c >= '0' && c <= '9')
                    {
                        num = c - 48;
                    }
                    if (c >= 'A' && c <= 'F')
                    {
                        num = c - 55;
                    }
                    sum += num * System.Math.Pow(16, pow);
                    pow++;
                    if (c == 'x')
                    {
                        break;
                    }
                }
                System.Console.WriteLine(sum);
            }
        }
    }
}
