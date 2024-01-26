using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Utilities
{
    /// <summary>
    /// This class contains multiple mathematical function
    /// </summary>
    public class MathUtilities
    {
        /// <summary>
        /// This method return the list of the prime number, from 1 to max
        /// </summary>
        /// <param name="max">We compute prime until this number</param>
        /// <returns>The list of the prime number from 1 to max</returns>
        public static List<long> Primes(long max)
        {
            List<long> primes = new List<long>();
            for (int i = 2; i <= max; i++)
                if (!primes.Any(p => i % p == 0))
                    primes.Add(i);
            return primes;
        }

        /// <summary>
        /// Give Least Common Multiples of the given numbers
        /// </summary>
        /// <param name="numbers">List of numbers to compute LCM</param>
        /// <returns>The list of LCM of given numbers</returns>
        public static long LCM(List<long> numbers)
        {
            List<(long, long)> factors = new List<(long, long)>();
            for (int i = 0; i < numbers.Count; i++)
            {
                List<(long, long)> factor = Factor(numbers[i]);
                for (int j = 0; j < factor.Count; j++)
                {
                    if (factors.Exists(x => x.Item1 == factor[j].Item1))
                    {
                        int ind = factors.FindIndex(x => x.Item1 == factor[j].Item1);
                        if (factors[ind].Item2 < factor[j].Item2)
                        {
                            factors[ind] = factor[j];
                        }
                    }
                    else
                    {
                        factors.Add(factor[j]);
                    }
                }

            }
            long ppcm = 1;
            for (int i = 0; i < factors.Count; i++)
            {
                ppcm *= (long)System.Math.Pow(factors[i].Item1, factors[i].Item2); ;
            }
            return ppcm;
        }

        /// <summary>
        /// Give the list of the prime factor of one number
        /// </summary>
        /// <param name="number">the number that we want to facorize</param>
        /// <returns>The list of the prime factor of the given number</returns>
        public static List<(long, long)> Factor(long number)
        {
            List<(long, long)> factor = new List<(long, long)>();
            List<long> primes = Primes(number);
            long actual = number;
            for (int i = 0; i < primes.Count; i++)
            {
                if (actual % primes[i] == 0)
                {
                    int exp = 1;
                    actual = actual / primes[i];
                    while (actual % primes[i] == 0)
                    {
                        exp++;
                        actual = actual / primes[i];
                    }
                    factor.Add((primes[i], exp));
                }
                if (actual <= 1)
                {
                    break;
                }
            }
            return factor;
        }
    }
}
