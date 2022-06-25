using Xunit;

namespace Hoonisone.ValueContainer.Container.Tests
{
    public class ValueContainerTests
    {
        [Fact]
        public void ConstructorTest()
        {
            int v = 10;
            ValueContainer<int> vc = new ValueContainer<int>(v);
            Assert.True(vc.v == v);
        }

        [Fact]
        public void GetSetTest()
        {
            int v = 10;
            ValueContainer<int> vc = new ValueContainer<int>(0);
            vc.v = v; 
            Assert.True(vc.v == v);
        }

    }
}