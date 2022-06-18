using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer.Container
{
    public class MinVC<T> : ConstraintValueContainer<T> where T : IComparable
    {
        public MinVC(T min, bool autoHandling) : base(new MinConstraint<T>(min), autoHandling) { }
        public MinVC(T min) : base(new MinConstraint<T>(min)) { }

        public T min { get { return ((MinConstraint<T>)constraint).min; } }
    }
}
