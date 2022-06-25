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
    public class MaxConstraintTests
    {
        [Theory]
        [InlineData(0, -1, true)]
        [InlineData(0,  0, true)]
        [InlineData(0,  1, false)]
        public void TestCheck(int max, int value, bool effectiveness)
        {
            Constraint<int> c = new MaxConstraint<int>(max);
            Assert.True(c.Check(value) == effectiveness);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void TestGetMax(int max)
        {
            Constraint<int> c = new MaxConstraint<int>(max);
            Assert.True(((MaxConstraint<int>)c).max == max);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(0,  0)]
        [InlineData(0,  1)]
        public void TestHandle (int max, int value)
        {
            Constraint<int> c = new MaxConstraint<int>(max);
            int handled = c.Handle(value);
            Assert.True(c.Check(handled) == true); // 제약조건을 만족해야 한다.
        }


    }
}