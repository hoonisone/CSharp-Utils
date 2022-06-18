using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer.Container
{
    public class MinMaxVC<T> : ConstraintValueContainer<T> where T : IComparable
    {
        public MinMaxVC(T min, T max, bool autoHandling) : base(new MinMaxConstraint<T>(min, max), autoHandling) { }
        public MinMaxVC(T min, T max) : base(new MinMaxConstraint<T>(min, max)) { }

        public T max { get { return ((MinMaxConstraint<T>)constraint).max; } }
        public T min { get { return ((MinMaxConstraint<T>)constraint).min; } }
    }
}
