
using System;

namespace Hoonisone.ValueContainer2
{
    public abstract class Constraint<T>
    {
        /* 변수의 제약조건을 나타내는 객체이다.
         */

        abstract public bool Check(T v);
        /* v가 제약조건을 만족하는지 체크하고 만족 여부를 반환한다.
         */

        abstract public T Handle(T v);
        /* v가 제약조건을 만족하도록 수정하고 그 값을 반환한다.
         */
    }
}