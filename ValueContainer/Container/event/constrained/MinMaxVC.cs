using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer2.Container
{
    public class MinMaxVC<T> : ConstrainedVC<T> where T : IComparable
    {
        public MinMaxVC(T min, T max, T value, bool autoHandling) : base(new MinMaxConstraint<T>(min, max), value, autoHandling) { }
        public MinMaxVC(T min, T max, T value) : base(new MinMaxConstraint<T>(min, max), value) { }

        public T max { get { return ((MinMaxConstraint<T>)constraint).max; } }
        public T min { get { return ((MinMaxConstraint<T>)constraint).min; } }
    }
}
