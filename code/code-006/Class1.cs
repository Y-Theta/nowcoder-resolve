using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_006
{
    internal class Class1
    {
        public static void Main()
        {
            string line = System.Console.ReadLine();
            string[] tokens = line.Split();
            var total = int.Parse(tokens[0]);
            var select = int.Parse(tokens[1]);

            if (total == 0 || select == 0)
            {
                System.Console.WriteLine("0");
                return;
            }

            string line1 = System.Console.ReadLine();
            string[] tokens1 = line1.Split();
            List<long> numbers = new List<long>();
            foreach (var item in tokens1)
            {
                numbers.Add(int.Parse(item));
            }
            numbers.Sort();

            if (select == 1)
            {
                System.Console.WriteLine(numbers.Min());
                return;
            }

            List<long> decs = new List<long>();
            for (int i = 1; i < total; i++)
            {
                decs.Add((long)Math.Pow(numbers[i], 2) - (long)Math.Pow(numbers[i - 1], 2));
            }

            long window = 0;
            for (int i = 0; i < select - 1; i++)
            {
                window += decs[i];
            }
            long min = window;
            for (int i = select - 1; i < decs.Count; i++)
            {
                window -= decs[i - (select - 1)];
                window += decs[i];
                min = System.Math.Min(min, window);
            }

            Console.WriteLine(min);
        }
    }
}
