using Xunit;

namespace Hoonisone.ValueContainer2.Tests
{
    public class MinConstraintTests
    {
        [Theory]
        [InlineData(0, -1, false)]
        [InlineData(0,  0, true)]
        [InlineData(0,  1, true)]
        public void TestCheck(int min, int value, bool effectiveness)
        {
            Constraint<int> c = new MinConstraint<int>(min);
            Assert.True(c.Check(value) == effectiveness);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void TestGetMin(int min)
        {
            Constraint<int> c = new MinConstraint<int>(min);
            Assert.True(((MinConstraint<int>)c).min == min);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(0,  0)]
        [InlineData(0,  1)]
        public void TestHandle(int min, int value)
        {
            Constraint<int> c = new MinConstraint<int>(min);
            int handled = c.Handle(value);
            Assert.True(c.Check(handled) == true); // 제약조건을 만족해야 한다.\
        }
    }
}