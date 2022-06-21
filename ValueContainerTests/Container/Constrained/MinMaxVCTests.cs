using Xunit;

namespace Hoonisone.ValueContainer.Container.Tests
{
    public class MinMaxVCTests
    {
        [Theory]
        [InlineData(-1, 1)]
        public void ConstraintsSettingTest(int min, int max) // 제약조건을 제대로 세팅하는가?
        {
            ConstrainedVC<int> vc = new MinMaxVC<int>(min, max, min);
            Assert.True(((MinMaxVC<int>)vc).min == min);
            Assert.True(((MinMaxVC<int>)vc).max == max);
        }

        [Theory]
        [InlineData(0, 10, -1, true)]
        [InlineData(0, 10, 0, false)]
        [InlineData(0, 10, 5, false)]
        [InlineData(0, 10, 10, false)]
        [InlineData(0, 10, 11, true)]
        public void ViolationInitErrorTest(int min, int max, int value, bool error) // 위배된 초기화 시 에러가 발생하는가?
        {
            bool e = Test.IsErrorOccur(() => {
                ConstrainedVC<int> vc = new MinMaxVC<int>(min, max, value);
            });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, 10, -1, true)]
        [InlineData(0, 10, 0, false)]
        [InlineData(0, 10, 5, false)]
        [InlineData(0, 10, 10, false)]
        [InlineData(0, 10, 11, true)]
        public void ViolationSetErrorTest(int min, int max, int value, bool error) // 위배된 값 세팅 시 에러가 발생하는가?
        {
            bool e = Test.IsErrorOccur(() => {
                ConstrainedVC<int> vc = new MinMaxVC<int>(min, max, min);
                vc.v = value;
            });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, 10, -1, false)]
        [InlineData(0, 10, 0, false)]
        [InlineData(0, 10, 5, false)]
        [InlineData(0, 10, 10, false)]
        [InlineData(0, 10, 11, false)]
        public void InitViolationHandlingTest(int min, int max, int value, bool error)// 위배된 초기화 시 핸들링되는가?
        {
            bool e = Test.IsErrorOccur(() => { ConstrainedVC<int> vc = new MinMaxVC<int>(min, max, value, true); });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, 10, -1, false)]
        [InlineData(0, 10, 0, false)]
        [InlineData(0, 10, 5, false)]
        [InlineData(0, 10, 10, false)]
        [InlineData(0, 10, 11, false)]
        public void SetViolationHandlingTest(int min, int max, int value, bool error)// 위배된 값 세팅 시 핸들링 되는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MinMaxVC<int>(min, max, min, true);
                vc.v = value;
            });
            Assert.True(e == error);
        }

        
    }
}