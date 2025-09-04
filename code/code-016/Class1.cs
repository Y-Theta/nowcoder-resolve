using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_016
{
    internal class Class1
    {

        public static void Main()
        {
            string pass = System.Console.ReadLine();
            int score = 0;
            score += LengthScore(pass);
            score += WordScore(pass);

            if (score >= 90)
                Console.WriteLine("VERY_SECURE");
            else if (score >= 80)
                Console.WriteLine("SECURE");
            else if (score >= 70)
                Console.WriteLine("VERY_STRONG");
            else if (score >= 60)
                Console.WriteLine("STRONG");
            else if (score >= 50)
                Console.WriteLine("AVERAGE");
            else if (score >= 20)
                Console.WriteLine("WEAK");
            else if (score >= 0)
                Console.WriteLine("VERY_WEAK");

        }

        private static int LengthScore(string str)
        {
            return str.Length <= 4 ? 5 : str.Length <= 7 ? 10 : 25;
        }

        private static int WordScore(string str)
        {
            bool lflag = false;
            bool uflag = false;
            int numbers = 0;
            int symbols = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    lflag = true;
                }
                else if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    uflag = true;
                }
                else if (str[i] >= '0' && str[i] <= '9')
                {
                    numbers++;
                }
                else
                {
                    symbols++;
                }
            }

            int a = 0;
            if (lflag && uflag)
                a = 20;
            else if (lflag || uflag)
                a = 10;

            int b = 0;
            if (numbers > 1)
                b = 20;
            else if (numbers == 1)
                b = 10;

            int c = 0;
            if (symbols > 1)
                c = 25;
            else if (symbols == 1)
                c = 10;

            if (a >= 20 && b > 0 && c > 0)
                a += 5;
            else if (a > 0 && b > 0 && c > 0)
                a += 3;
            else if (a > 0 && b > 0)
                a += 2;

            a += b;
            a += c;
            return a;
        }

    }
}
