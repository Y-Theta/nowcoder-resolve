using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_022
{
    internal class Class1
    {
        public class Stu
        {
            public string name { get; set; }

            public int grade { get; set; }
        }

        public static void Main()
        {
            int total = int.Parse(System.Console.ReadLine());
            bool up = int.Parse(System.Console.ReadLine()) == 1;

            List<Stu> stus = new List<Stu>();
            for (int i = 0; i < total; i++)
            {
                var info = System.Console.ReadLine().Split();
                Stu s = new Stu();
                s.name = info[0];
                s.grade = int.Parse(info[1]);
                stus.Add(s);
            }

            if (up)
            {
                var ordered = stus.OrderBy(s => s.grade);
                foreach (var item in ordered)
                {
                    Console.WriteLine($"{item.name} {item.grade}");
                }
            }
            else
            {
                var ordered = stus.OrderByDescending(s => s.grade);
                foreach (var item in ordered)
                {
                    Console.WriteLine($"{item.name} {item.grade}");
                }
            }
        }
    }
}
