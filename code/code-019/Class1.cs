using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_019
{
    internal class Class1
    {
        public static void Main()
        {
            var brief = System.Console.ReadLine().Split();
            int count = int.Parse(brief[0]);
            Dictionary<int, int> dic = new Dictionary<int, int>(500);
            for (int i = 0; i < count; i++)
            {
                var data = Console.ReadLine().Split();
                var key = int.Parse(data[0]);
                var newval = int.Parse(data[1]);
                if (dic.TryGetValue(key, out var val))
                {
                    dic[key] = val + newval;
                }
                else
                {
                    dic[key] = newval;
                }
            }

            var dl = dic.ToList();
            dl.Sort((a, b) => a.Key - b.Key);
            foreach (var item in dl)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }
    }
}
