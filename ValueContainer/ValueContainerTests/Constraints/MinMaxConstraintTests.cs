using Xunit;
using Hoonisone.ValueContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoonisone.ValueContainer.Constraint;

namespace Hoonisone.ValueContainer.Tests
{

    public class MinMaxConstraintTests
    {
        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(0, -1, true)]
        public void TestConstructor(int min, int max, bool error)
        {
            bool e = false; // 에러가 발생했는가?
            try
            {
                Constraint<int> c = new MinMaxConstraint<int>(min, max);
            }
            catch (Exception)
            {
                e = true;
            }
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(-1, 1)]
        public void TestGetMinMax(int min, int max)
        {
            Constraint<int> c = new MinMaxConstraint<int>(min, max);
            Assert.True(((MinMaxConstraint<int>)c).min == min);
            Assert.True(((MinMaxConstraint<int>)c).max == max);
        }

        [Theory]
        [InlineData(0, 10, -1, false)]
        [InlineData(0, 10, 0, true)]
        [InlineData(0, 10, 5, true)]
        [InlineData(0, 10, 10, true)]
        [InlineData(0, 10, 11, false)]
        public void TestCheck(int min, int max, int value, bool effectiveness)
        {
            Constraint<int> c = new MinMaxConstraint<int>(min, max);
            Assert.True(c.Check(value) == effectiveness);
        }

        [Theory]
        [InlineData(0, 10, -1)]
        [InlineData(0, 10,  0)]
        [InlineData(0, 10,  5)]
        [InlineData(0, 10, 10)]
        [InlineData(0, 10, 11)]
        public void TestHandle(int min, int max, int value)
        {
            Constraint<int> c = new MinMaxConstraint<int>(min, max);
            Assert.True(c.Check(c.Handle(value)) == true); // 제약조건을 만족해야 한다.
        }
    }
}