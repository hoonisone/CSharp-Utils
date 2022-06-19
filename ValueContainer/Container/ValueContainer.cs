namespace Hoonisone.ValueContainer2.Container
{
    public class ValueContainer<T> where T : IComparable
    {
        private T _value; // 값

        public ValueContainer(T value) { _value = value; }

        public virtual T v
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
