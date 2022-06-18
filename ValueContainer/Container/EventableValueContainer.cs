namespace Hoonisone.ValueContainer.Container
{
    public class EventableValueContainer<T> : SimpleValueContainer<T> where T : IComparable
    {
        public delegate void OnChanged(T before, T after) ; //값이 바뀌었을 때 호출
        public delegate void OnSet(T value); //값이 세팅 된 경우
        public delegate void OnGet(T value); //값이 참조 된 경우
        public OnChanged? onChanged = null;
        public OnSet? onSet = null;
        public OnGet? onGet = null; 

        public override T value
        {
            get
            {
                onGet?.Invoke(base.value);
                return base.value;
            }
            set
            {
                T before = base.value;
                base.value = value;
                onSet?.Invoke(base.value);  // 무조건 호출
                if (before.CompareTo(value) != 0) // 값이 바뀐 경우에만 호출
                    onChanged?.Invoke(before, base.value);
            }
        }
    }
}
