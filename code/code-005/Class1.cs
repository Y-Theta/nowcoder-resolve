using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.code_005
{
    internal class Class1
    {

        public class NodeInfo
        {
            public int Pos { get; set; }

            public int Value { get; set; }

            public int Number { get; set; }
        }

        public static void Main()
        {
            string line = System.Console.ReadLine();
            var total = int.Parse(line);
            while ((line = System.Console.ReadLine()) != null)
            {
                // 注意 while 处理多个 case
                string[] tokens = line.Split(new char[] { ' ' });
                var row = int.Parse(tokens[0]);
                var col = int.Parse(tokens[1]);
                int sum = 0;
                NodeInfo[] nodedic = new NodeInfo[row * col];
                for (int i = 0; i < row; i++)
                {
                    line = System.Console.ReadLine();
                    tokens = line.Split(new char[] { ' ' });
                    for (int j = 0; j < tokens.Length; j++)
                    {
                        var num = int.Parse(tokens[j]);
                        var pos = i * col + j;
                        nodedic[pos] = new NodeInfo
                        {
                            Pos = pos,
                            Number = num,
                        };
                        sum += num;
                    }
                }
                int max = GetMaxNumber(row, col, nodedic, sum);
                System.Console.WriteLine(max);

                total--;
                if (total == 0)
                {
                    break;
                }
            }
        }

        private static int GetMaxNumber(int row, int col, NodeInfo[] matrix, int sum)
        {
            int max = 0;
            var stack = new Stack<int>();
            for (int i = 0; i < 2 && i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    stack.Clear();
                    stack.Push(i * col + j);
                    matrix[i * col + j].Value = matrix[i * col + j].Number;
                    int tempmax = matrix[i * col + j].Value;
                    Dfs(row, col, i * col + j, matrix, stack, ref tempmax);
                    max = System.Math.Max(max, tempmax);
                }
            }
            return max;
        }

        private static void Dfs(int row, int col, int top, NodeInfo[] matrix, Stack<int> posval, ref int max)
        {
            if (posval.Count == 0)
                return;

            var next = FindNext(row, col, matrix, top, posval);
            if (next > 0)
            {
                if (posval.TryPeek(out var forenode))
                {
                    matrix[next].Value = matrix[forenode].Value + matrix[next].Number;
                    max = System.Math.Max(matrix[next].Value, max);
                }
                posval.Push(next);
                Dfs(row, col, top, matrix, posval, ref max);
                top = posval.Pop();
                matrix[top].Value = 0;
                Dfs(row, col, top, matrix, posval, ref max);
            }
        }

        private static int FindNext(int row, int col, NodeInfo[] matrix, int start, Stack<int> posval)
        {
            var aim = start + 1;
            while (aim < matrix.Length)
            {
                bool flag = true;
                foreach (var item in posval)
                {
                    if (!IsValid(row, col, aim, item))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return aim;
                }
                aim++;
            }

            return -1;
        }

        private static bool IsValid(int row, int col, int aim, int current)
        {
            var crow = current / col;
            var ccol = current % col;

            var arow = aim / col;
            if (arow > row)
                return false;
            var acol = aim % col;

            if (System.Math.Abs(ccol - acol) < 2 && System.Math.Abs(crow - arow) < 2)
                return false;

            return true;
        }
    }
}
