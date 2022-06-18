using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer.Container
{
    public class MaxVC<T> : ConstraintValueContainer<T> where T : IComparable
    {
        public MaxVC(T max, bool autoHandling) : base(new MaxConstraint<T>(max), autoHandling) {}
        public MaxVC(T max) : base(new MaxConstraint<T>(max)){}

        public T max { get { return ((MaxConstraint<T>)constraint).max; } }
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
