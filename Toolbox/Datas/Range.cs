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
        public long MinValue { get; private set; }
        public long MaxValue { get; private set; }
        public long Count { get => ((MaxValue - MinValue) + 1L); }
        public Range(long min, long max)
        {
            MinValue = min;
            MaxValue = max;
        }

        /// <summary>
        /// Updtate the range
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void UpdateRange(long min, long max)
        {
            MinValue = min;
            MaxValue = max;
        }

        public bool IsInRange(long value, bool minInclusive = false, bool maxInclusive = false)
        {
            if (!minInclusive && !maxInclusive)
            {
                return MinValue < value && value < MaxValue;
            }
            else if (!minInclusive && maxInclusive)
            {
                return MinValue < value && value <= MaxValue;
            }
            else if (minInclusive && !maxInclusive)
            {
                return MinValue <= value && value < MaxValue;
            }
            else if (minInclusive && maxInclusive)
            {
                return MinValue <= value && value <= MaxValue;
            }
            else
                return false;

        }
    }
}
