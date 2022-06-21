namespace Hoonisone.ValueContainer.Container
{
    public class EventVC<T> : ValueContainer<T> where T : IComparable
    {
        //변수 값에 대한 이벤트 구독 기능을 제공한다.


        public delegate void OnChanged(T before, T after); //값이 바뀌었을 때 호출
        public delegate void OnSet(T value); //값이 세팅 된 경우
        public delegate void OnGet(T value); //값이 참조 된 경우
        public OnChanged? onChanged = null;
        public OnSet? onSet = null;
        public OnGet? onGet = null;

        public EventVC(T value) : base(value) { }

        public override T v
        {
            get
            {
                onGet?.Invoke(base.v);
                return base.v;
            }
            set
            {
                T before = base.v;
                base.v = value;
                onSet?.Invoke(base.v);  // 무조건 호출
                if (before.CompareTo(value) != 0) // 값이 바뀐 경우에만 호출
                    onChanged?.Invoke(before, base.v);
            }
        }
    }
}
