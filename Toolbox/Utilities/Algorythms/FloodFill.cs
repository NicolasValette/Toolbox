using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Utilities.Algorythms
{
    public class FloodFill<T> : IFloodFill<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Flood fill method.
        /// </summary>
        /// <param name="startingLine"></param>
        /// <param name="startingRow"></param>
        /// <param name="input"></param>
        /// <param name="target">the character we want to replace</param>
        /// <param name="replacement"></param>
        public void Flood(int startingLine, int startingRow, ref T[][] input, T target, T replacement)
        {
            // We need to implemant an internal stack to optimize compute time and avoid stack overflow error.
            Stack<(int, int)> stack = new Stack<(int, int)>();
            if (input[startingLine][startingRow].Equals(target))
            {
                stack.Push((startingLine, startingRow));
                while (stack.Count > 0)
                {
                    (int, int) pair = stack.Pop();
                    input[pair.Item1][pair.Item2] = replacement;

                    if (pair.Item1 - 1 >= 0 && input[pair.Item1 - 1][pair.Item2].Equals(target))
                    {
                        stack.Push((pair.Item1 - 1, pair.Item2));
                    }
                    if (pair.Item1 + 1 < input.Length && input[pair.Item1 + 1][pair.Item2].Equals(target))
                    {
                        stack.Push((pair.Item1 + 1, pair.Item2));
                    }
                    if (pair.Item2 - 1 >= 0 && input[pair.Item1][pair.Item2 - 1].Equals(target))
                    {
                        stack.Push((pair.Item1, pair.Item2 - 1));
                    }
                    if (pair.Item2 + 1 < input[pair.Item1].Length && input[pair.Item1][pair.Item2 + 1].Equals(target))
                    {
                        stack.Push((pair.Item1, pair.Item2 + 1));
                    }
                }
            }
        }

    }
}
