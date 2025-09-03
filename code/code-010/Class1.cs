using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_010
{
    internal class Class1
    {
        public static void Main()
        {
            string line = System.Console.ReadLine();
            string dec = System.Console.ReadLine();

            long sum = 0;
            var code = line.Split('.');
            for (int i = 0; i < code.Length; i++)
            {
                var codee = long.Parse(code[i]);
                sum += codee * (long)System.Math.Pow(2, 8 * (3 - i));
            }
            Console.WriteLine(sum);

            var codedec = long.Parse(dec);
            for (int i = 0; i <= 3; i++)
            {
                var part = codedec & 0xFF000000;
                var num = part >> 24;
                Console.Write(num);
                if (i < 3)
                {
                    Console.Write('.');
                }
                codedec = codedec << 8;
            }
        }
    }
}
