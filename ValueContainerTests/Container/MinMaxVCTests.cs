using Xunit;

namespace Hoonisone.ValueContainer.Container.Tests
{
    public class MinMaxCVTests
    {
        [Theory]
        [InlineData(-1,  1)]
        public void MinMaxValueTest(int min, int max)
        {
            ConstraintValueContainer<int> vc = new MinMaxVC<int>(min, max);
            Assert.True(((MinMaxVC<int>)vc).min == min);
            Assert.True(((MinMaxVC<int>)vc).max == max);
        }

        [Theory]
        [InlineData(0, 10, -1, true)]
        [InlineData(0, 10,  0, false)]
        [InlineData(0, 10,  5, false)]
        [InlineData(0, 10, 10, false)]
        [InlineData(0, 10, 11, true)]
        public void ValueConstraintErrorTest(int min, int max, int value, bool error)
        {
            // 잘못된 값을 넣으면 에러를 발생하는지 테스트

            ConstraintValueContainer<int> vc = new MinMaxVC<int>(min, max);
            bool e = false; // 에러 발생 여부
            try
            {
                vc.value = value;
            }
            catch (System.Exception)
            {
                e = true;
            }
            Assert.True(e == error);
        }

        [Theory]
        [InlineData(0, 10, -1, false)]
        [InlineData(0, 10,  0, false)]
        [InlineData(0, 10,  5, false)]
        [InlineData(0, 10, 10, false)]
        [InlineData(0, 10, 11, false)]
        public void ValueConstraintHandlingTest(int min, int max, int value, bool error)
        {
            // 잘못된 값을 넣어도 적절히 핸들링하여 값을 수정한 뒤 저장해주는지 테스트
            ConstraintValueContainer<int> vc = new MinMaxVC<int>(min, max, true);
            bool e = false; // 에러 발생 여부
            try
            {
                vc.value = value;
            }
            catch (System.Exception)
            {
                e = true;
            }
            Assert.True(e == error);
        }
    }
}