using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Utilities.Algorythms
{
    public class FloodFill
    {
        /// <summary>
        /// Flood fill function
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="inp"></param>
        public static void Execute(int i, int j, ref char[][] inp)
        {
            // We need to implemant an internal stack to optimize compute time and avoid stack overflow error.
            Stack<(int, int)> stack = new Stack<(int, int)>();
            if (inp[i][j] == '#')
            {
                stack.Push((i, j));
                while (stack.Count > 0)
                {
                    (int, int) pair = stack.Pop();
                    inp[pair.Item1][pair.Item2] = '@';

                    if (pair.Item1 - 1 >= 0 && inp[pair.Item1 - 1][pair.Item2] == '#')
                    {
                        stack.Push((pair.Item1 - 1, pair.Item2));
                    }
                    if (pair.Item1 + 1 < inp.Length && inp[pair.Item1 + 1][pair.Item2] == '#')
                    {
                        stack.Push((pair.Item1 + 1, pair.Item2));
                    }
                    if (pair.Item2 - 1 >= 0 && inp[pair.Item1][pair.Item2 - 1] == '#')
                    {
                        stack.Push((pair.Item1, pair.Item2 - 1));
                    }
                    if (pair.Item2 + 1 < inp[pair.Item1].Length && inp[pair.Item1][pair.Item2 + 1] == '#')
                    {
                        stack.Push((pair.Item1, pair.Item2 + 1));
                    }

                }


            }
        }
    }
}
