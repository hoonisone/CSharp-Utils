namespace Hoonisone.ValueContainer.Container
{
    public class SimpleValueContainer<T> where T : IComparable
    {
        private T _value; // 값

        public virtual T value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
