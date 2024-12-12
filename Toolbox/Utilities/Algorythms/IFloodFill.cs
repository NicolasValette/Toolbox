

using System;

namespace Toolbox.Utilities.Algorythms
{
    public interface IFloodFill<T>
    {
        void Flood(int startingRow, int startingCol, ref T[][] input, T target, T replacement);
    }
}
