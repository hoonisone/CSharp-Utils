using Xunit;

namespace Hoonisone.ValueContainer2.Container.Tests
{
    public class MinVCTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ConstraintsSettingTest(int min)// 제약조건을 제대로 세팅하는가?
        {
            ConstrainedVC<int> vc = new MinVC<int>(min, min);
            Assert.True(((MinVC<int>)vc).min == min);
        }

        [Theory]
        [InlineData(0, -1, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        public void ViolationInitErrorTest(int min, int value, bool error)// 위배된 초기화 시 에러가 발생하는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MinVC<int>(min, value);
            });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, -1, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        public void ViolationErrorTest(int min, int value, bool error)  // 위배된 값 세팅 시 에러가 발생하는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MinVC<int>(min, min);
                vc.v = value;
            });
            Assert.True(e == error);
        }


        [Theory]
        [InlineData(0, -1, false)]
        public void ViolationInitHandlingTest(int min, int value, bool error) // 위배된 초기화 시 핸들링되는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MinVC<int>(min, value, true);
            });
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, -1, false)]
        public void ViolationSetHandlingTest(int min, int value, bool error) // 위배된 값 세팅 시 핸들링 되는가?
        {
            bool e = Test.IsErrorOccur(() =>
            {
                ConstrainedVC<int> vc = new MinVC<int>(min, min, true);
                vc.v = value;
            });
            Assert.True(e == error);
        }
    }
}