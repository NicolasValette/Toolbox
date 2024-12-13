using System;

namespace Toolbox.Datas
{
    /// <summary>
    /// System of two equastion oàf the form :
    /// 
    /// | C  = Ax  + By
    /// | C' = A'x + B'y
    ///
    /// </summary>
    public class TwoEquationSystem
    {
        
        public long A { get;  set; }
        public long APrime { get;  set; }
        public long B { get;  set; }
        public long BPrime { get;  set; }
        public long C { get;  set; }
        public long CPrime { get;  set; }

        public TwoEquationSystem(long a, long ap, long b, long bp, long c, long cp)
        {
            A = a;
            APrime = ap;
            B = b;
            BPrime = bp;
            C = c;
            CPrime = cp;
        }

        public bool Resolve(out (long, long) solution)
        {

           long det = A * BPrime - APrime * B;
           if (det == 0)
           {
               solution.Item1 = 0;
               solution.Item2 = 0;
               return false;
           };
            
            long solutionX = ((BPrime*C) - (B*CPrime)) / ((A*BPrime - APrime*B));
            long solutionY = (A * CPrime - APrime * C) / (A * BPrime - APrime * B);
            solution.Item1 = (long)solutionX;
            solution.Item2 = (long)solutionY;
            if ((C == solution.Item1 * A + solution.Item2 * B) && (CPrime == solution.Item1 * APrime + solution.Item2 * BPrime))
            {
                return true;
            }
            return false;
        }
    }
}