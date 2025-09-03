using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_012
{
    internal class Class1
    {
        public static void Main()
        {
            int count = int.Parse(System.Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string origin = Console.ReadLine();
                string pattern = Console.ReadLine();

                var final = IsMatch(origin, pattern);
                if (final != null)
                {
                    Console.WriteLine("YES");
                    Console.WriteLine(final);
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static string IsMatch(string origin, string pattern)
        {
            if (pattern.Length > origin.Length)
                return null;

            int j = 0;
            char[] newarray = origin.ToCharArray();
            for (int i = 0; i < origin.Length; i++)
            {
                if (j < pattern.Length && newarray[i] == pattern[j])
                {
                    j++;
                    continue;
                }
                else if (origin[i] == '?')
                {
                    if (j < pattern.Length)
                    {
                        newarray[i] = pattern[j];
                        j++;
                    }
                    else
                    {
                        newarray[i] = pattern[0];
                    }
                }
            }

            if (j == pattern.Length)
            {
                return new string(newarray);
            }

            return null;
        }

    }
}
