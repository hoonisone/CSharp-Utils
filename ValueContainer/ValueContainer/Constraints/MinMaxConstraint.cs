using System;

namespace Hoonisone.ValueContainer.Constraint
{
    public class MinMaxConstraint<T> : Constraint<T> where T : IComparable
    {
        // Constraint range
        private readonly MinConstraint<T> minc;
        private readonly MaxConstraint<T> maxc;

        public MinMaxConstraint(T min, T max)
        {
            minc = new MinConstraint<T>(min);
            if (minc.Check(max) == false){ // max 가 min보다 같거나 크지 못하면
                throw new ArgumentException("min, max 범위 이상");
            }
            maxc = new MaxConstraint<T>(max);
        }

        public override bool Check(T v)
        {
            return minc.Check(v) && maxc.Check(v);
        }

        public override T Handle(T v)
        {
            v = minc.Handle(v);
            v = maxc.Handle(v);
            return v;
        }
        public T min { get => minc.min; }
        public T max { get => maxc.max; }
    }
}