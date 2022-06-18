using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer.Container
{
    public class ValueContainer<T> where T : IComparable
    {
        private T _value; // 값

        public virtual T value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    public class ConstraintValueContainer<T> : ValueContainer<T> where T : IComparable
    {
        /* 제약조건이 있는 변수를 나타낸다.
         * 값을 읽고 쓸 수 있으며 제약조건에 위배되는 경우 에러를 발생시킨다.
         * 값을 저장할 때 autoHandling = ture인 경우 제약조건이 위배되면 자동으로 값을 수정하여 제약조건을 만족시키고 저장한다.
         */
        protected Constraint<T> constraint; // 값 제약 사항
        private bool autoHandling;

        public ConstraintValueContainer(Constraint<T> constraint):this(constraint, false){}
        public ConstraintValueContainer(Constraint<T> constraint, bool autoHandling)
        {
            this.constraint = constraint;
            this.autoHandling = autoHandling;
        }

        public override T value
        {
            get
            {
                return base.value;
            }
            set
            {
                if(constraint.Check(value) == false) // 제약조건 충돌 시
                {
                    if (autoHandling)
                    {
                        value = constraint.Handle(value); // 자동으로 제약조건을 충족시킴
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(); // 에러 발생
                    }
                }
                base.value = value;
            }
        }
    }
    /*  public class EventValueContainer<T> where T : IComparable
      {
          public VEvent<T, T> OnChanged; //값이 바뀌었을 때 호출
          public VEvent<T, T> OnSet; //값이 세팅 된 경우
          public VEvent<T> OnGet; //값이 참조 된 경우


          public EventValueContainer(Constraint<T> constraint)
          {
              this.constraint = constraint;
          }

          public T Value
          {
              get
              {
                  OnGet?.Invoke(_value);
                  return _value;
              }
              set
              {
                  T before = _value;
                  _value = value;
                  OnSet?.Invoke(before, _value);  // 무조건 호출
                  if (before.CompareTo(value) != 0) // 값이 바뀐 경우에만 호출
                      OnChanged?.Invoke(before, _value);
              }
          }
      }*/
}
