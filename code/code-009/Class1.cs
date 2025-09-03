using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_009
{
    internal class Class1
    {
        public static void Main()
        {
            string line = System.Console.ReadLine();
            int count = int.Parse(line);
            string two = System.Console.ReadLine();
            var numbers = two.Split();
            int[] numberarr = new int[count];
            long total = 0;
            long sum = 0;
            for (int i = 0; i < count; i++)
            {
                numberarr[i] = int.Parse(numbers[i]);
                sum += numberarr[i];
            }

            var halfsum = sum / 2;
            long[] rightsums = new long[count];
            rightsums[count - 1] = numberarr[count - 1];
            for (int j = count - 2; j >= 0; j--)
            {
                rightsums[j] = rightsums[j + 1] + numberarr[j];
            }
            long leftsum = 0;
            for (int i = 0; i < count; i++)
            {
                leftsum += numberarr[i];
                if (leftsum > halfsum)
                    break;
                int leftpoint = i + 1;
                int rightpoint = count - 1;
                int midpoint = (leftpoint + rightpoint) / 2;
                long mid = 0;
                while (leftpoint <= rightpoint)
                {
                    if (leftpoint == rightpoint)
                        break;

                    midpoint = (leftpoint + rightpoint) / 2;
                    var rightsum = rightsums[midpoint];
                    mid = sum - leftsum - rightsum;
                    if (mid > leftsum && mid > rightsum)
                    {
                        rightpoint = (leftpoint + rightpoint) / 2;
                    }
                    else
                    {
                        leftpoint = (leftpoint + rightpoint) / 2 + 1;
                    }
                }

                mid = sum - leftsum - rightsums[rightpoint];
                if (mid < leftsum)
                {
                    break;
                }
                total += count - leftpoint;
            }

            System.Console.WriteLine(total);
        }
    }
}
