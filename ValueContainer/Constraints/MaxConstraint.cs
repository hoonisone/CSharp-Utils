using System;
using System.Diagnostics;

namespace Hoonisone.ValueContainer.Constraint
{
    public class MaxConstraint<T> : Constraint<T> where T : IComparable
    {
        /* 최대값 제약조건을 나타낸다.
         */

        public readonly T max ; // 최댓값

        public MaxConstraint(T max)
        {
            this.max = max;
        }
        public override bool Check(T v)
        {
            return (v.CompareTo(max) <= 0);
        }

        public override T Handle(T v)
        {
            return Check(v) ? v : max;
        }
    }
}