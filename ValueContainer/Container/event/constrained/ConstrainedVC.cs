using Hoonisone.ValueContainer2;
using System;

namespace Hoonisone.ValueContainer2.Container
{

    public class ConstrainedVC<T> : EventVC<T> where T : IComparable
    {
        /* 제약조건이 있는 변수를 나타낸다.
         * 값을 읽고 쓸 수 있으며 제약조건에 위배되는 경우 에러를 발생시킨다.
         * 값을 저장할 때 autoHandling = ture인 경우 제약조건이 위배되면 자동으로 값을 수정하여 제약조건을 만족시키고 저장한다.
         */


        protected Constraint<T> constraint; // 값 제약 사항
        private bool autoHandling;

        public ConstrainedVC(Constraint<T> constraint, T value) : this(constraint, value, false) { }
        public ConstrainedVC(Constraint<T> constraint, T value, bool autoHandling) : base(value)
        {
            this.constraint = constraint;
            this.autoHandling = autoHandling;
            v = value;
        }

        public override T v
        {
            get
            {
                return base.v;
            }
            set
            {
                if (constraint.Check(value) == false) // 제약조건 충돌 시
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
                base.v = value;
            }
        }
    }
}
