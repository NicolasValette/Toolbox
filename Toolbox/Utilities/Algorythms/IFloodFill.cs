

using System;

namespace Toolbox.Utilities.Algorythms
{
    public interface IFloodFill<T>
    {
        void Flood(int startingLine, int startingRow, ref T[][] input, T target, T replacement);
    }
}
