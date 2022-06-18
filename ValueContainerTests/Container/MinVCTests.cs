using Xunit;

namespace Hoonisone.ValueContainer.Container.Tests
{
    public class MinCVTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void MinValueTest(int min)
        {
            ConstraintValueContainer<int> vc = new MinVC<int>(min);
            Assert.True(((MinVC<int>)vc).min == min);
        }

        [Theory]
        [InlineData(0, -1, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        public void ValueConstraintErrorTest(int min, int value, bool error)
        {
            // 잘못된 값을 넣으면 에러를 발생하는지 테스트

            ConstraintValueContainer<int> vc = new MinVC<int>(min);
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
        [InlineData(0, -1, false)]
        public void ValueConstraintHandlingTest(int min, int value, bool error)
        {
            // 잘못된 값을 넣어도 적절히 핸들링하여 값을 수정한 뒤 저장해주는지 테스트
            ConstraintValueContainer<int> vc = new MinVC<int>(min, true);
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