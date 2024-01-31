using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Datas
{
    /// <summary>
    /// Range class to Store [min;max] data
    /// </summary>
    public class Range
    { 
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public long Count { get => ((MaxValue - MinValue) + 1L); }
        public Range(int min, int max)
        {
            MinValue = min;
            MaxValue = max;
        }

        /// <summary>
        /// Updtate the range
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void UpdateRange(int min, int max)
        {
            MinValue = min;
            MaxValue = max;
        }
    }
}
