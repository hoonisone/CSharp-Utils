using Xunit;

namespace Hoonisone.ValueContainer.Container.Tests
{
    public class MaxVCTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ConstraintsSettingTest(int max) // 제약조건을 제대로 세팅하는가?
        {
            ConstrainedVC<int> vc = new MaxVC<int>(max, max);
            Assert.True(((MaxVC<int>)vc).max == max);
        }

        [Theory]
        [InlineData(0, -1, false)]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, true)]
        public void ViolationInitErrorTest(int max, int value, bool error) // 위배된 초기화 시 에러가 발생하는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MaxVC<int>(max, value);
            });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, -1, false)]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, true)]
        public void ViolationSetErrorTest(int max, int value, bool error) // 위배된 값 세팅 시 에러가 발생하는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MaxVC<int>(max, max);
                vc.v = value;
            });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, 1, false)]
        public void ViolationInitHandlingTest(int max, int value, bool error) // 위배된 초기화 시 핸들링되는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MaxVC<int>(max, value, true);
            });
            Assert.True(e == error);
        }
        [Theory]
        [InlineData(0, 1, false)]
        public void ViolationSetHandlingTest(int max, int value, bool error) // 위배된 값 세팅 시 핸들링 되는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MaxVC<int>(max, max, true);
                vc.v = value;
            });
            Assert.True(e == error);
        }
    }
}