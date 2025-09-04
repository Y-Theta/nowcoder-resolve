using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_021
{
    internal class Class1
    {
        public static void Main()
        {
            int data = int.Parse(System.Console.ReadLine());
            int[] mindic = new int[301];
            for (int i = 0; i < data; i++)
            {
                var eles = System.Console.ReadLine().Split();
                int steps = 0;
                foreach (var item in eles)
                {
                    var num = int.Parse(item);
                    if (mindic[num] > 0)
                    {
                        steps += mindic[num];
                    }
                    else
                    {
                        int sss = mindic[num] = GetMinStep(10, num);
                        steps += mindic[num];
                    }
                }
                Console.WriteLine(steps);
            }
        }

        private static int GetMinStep(int current, int aim)
        {
            if (current == aim)
                return 0;

            if (Math.Abs(aim - current) == 1 || Math.Abs(aim - current) == 10 || Math.Abs(aim - current) == 100 || aim == 300)
                return 1;

            int min = 0;
            int dec = aim - current;
            if (dec > 55)
            {
                int pre = current;
                for (int i = 1; i < 4; i++)
                {
                    var num = current + 100 * i;
                    if (num > aim)
                    {
                        if (num >= 300)
                        {
                            min = GetMinStep(300, aim) + 1;
                        }
                        else
                        {
                            min = GetMinStep(num, aim) + i;
                            if (num >= 200)
                            {
                                min = Math.Min(min, GetMinStep(300, aim) + 1);
                            }
                        }
                        if (i > 1)
                        {
                            int b = GetMinStep(pre, aim) + i - 1;
                            if (b < min)
                                min = b;
                        }
                        break;
                    }
                    pre = num;
                }
                //min = Math.Min(min, GetMinStep(300, aim) + 1);
            }
            else if (dec > 5)
            {
                int pre = current;
                for (int i = 1; i < 10; i++)
                {
                    var num = current + 10 * i;
                    if (num > aim)
                    {
                        if (num >= 300)
                        {
                            min = GetMinStep(300, aim) + 1;
                        }
                        else
                        {
                            min = GetMinStep(num, aim) + i;
                        }
                        if (i > 1)
                        {
                            int b = GetMinStep(pre, aim) + i - 1;
                            if (b < min)
                                min = b;
                        }
                        break;
                    }
                    pre = num;
                }
            }
            else if (dec > 0)
            {
                min = dec;
            }
            else if (dec < -50)
            {
                min = GetMinStep(current - 100, aim) + 1;
            }
            else if (dec < -5)
            {
                min = GetMinStep(current - 10, aim) + 1;
            }
            else
            {
                min = -dec;
            }


            //if (dec > 50)
            //{
            //    min = GetMinStep(300, aim) + 1;
            //    var num2 = GetMinStep(current + 100, aim) + 1;
            //    if (num2 < min)
            //        min = num2;
            //    if (current + 200 <= 300)
            //    {
            //        var num3 = GetMinStep(current + 200, aim) + 2;
            //        if (num3 < min)
            //            min = num3;
            //    }
            //}
            //else if (dec < -100)
            //{
            //    min = GetMinStep(current - 100, aim) + 1;
            //}
            //else if (dec > 5)
            //{
            //    min = GetMinStep(current + 10, aim) + 1;
            //    if (current + 20 <= 300)
            //    {
            //        var num3 = GetMinStep(current + 20, aim) + 2;
            //        if (num3 < min)
            //            min = num3;
            //    }
            //    var num2 = GetMinStep(300, aim) + 1;
            //    if (num2 < min)
            //        min = num2;
            //}
            //else if (dec < -10)
            //{
            //    min = GetMinStep(current - 10, aim) + 1;
            //    if (current - 10 >= 10)
            //    {
            //        var num3 = GetMinStep(current - 20, aim) + 2;
            //        if (num3 < min)
            //            min = num3;
            //    }
            //}
            //else if (dec > 0)
            //{
            //    min = dec;
            //}
            //else
            //{
            //    min = -dec;
            //}

            return min;
        }
    }
}
