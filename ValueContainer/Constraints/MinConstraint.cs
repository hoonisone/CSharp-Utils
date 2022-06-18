using System;

namespace Hoonisone.ValueContainer2
{
    public class MinConstraint<T> : Constraint<T> where T : IComparable
    {
        // Constraint range
        public readonly T min;

        public MinConstraint(T min)
        {
            this.min = min;
        }
        public override bool Check(T v)
        {
            return (min.CompareTo(v) <= 0); // 범위 안에 있는가?
        }

        public override T Handle(T v)
        {
            return Check(v) ? v : min;
        }
    }
}