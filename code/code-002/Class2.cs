using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_002
{
    internal class Class2
    {
        public static void Main()
        {
            string line;
            line = System.Console.ReadLine();
            var count = int.Parse(line);
            bool[] newsize = new bool[1001];
            while ((line = System.Console.ReadLine()) != null)
            { // 注意 while 处理多个 case
                var num = int.Parse(line);
                newsize[num] = true;
            }

            for (int i = 0; i < newsize.Length; i++)
            {
                if (newsize[i])
                {
                    System.Console.WriteLine(i);
                }
            }
        }
    }
}
