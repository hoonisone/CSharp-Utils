using Hoonisone.ValueContainer.Constraint;

namespace Hoonisone.ValueContainer.Container
{
    public class MinVC<T> : ConstrainedVC<T> where T : IComparable
    {
        public MinVC(T min, T value, bool autoHandling) : base(new MinConstraint<T>(min), value, autoHandling) { }
        public MinVC(T min, T value) : base(new MinConstraint<T>(min), value) { }

        public T min { get { return ((MinConstraint<T>)constraint).min; } }
    }
}
