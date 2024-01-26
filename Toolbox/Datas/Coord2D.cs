using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Datas
{
    public class Coord2D<T> where T : IComparable, IComparable<T>, IEquatable<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Coord2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public static bool operator ==(Coord2D<T> a, Coord2D<T> b)
        { 
            return (a.X.Equals(b.X)) && (a.Y.Equals(b.Y));
        }
        public static bool operator !=(Coord2D<T> a, Coord2D<T> b)
        {
            return (!(a.X.Equals(b.X)) || !(a.Y.Equals(b.Y)));
        }
        public override bool Equals(object obj)
        {
            return this == (obj as Coord2D<T>);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }

    }
   
}
