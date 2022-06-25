using Xunit;

namespace Hoonisone.ValueContainer.Container.Tests
{
    public class EventVCTests
    {
        [Fact]
        public void ValueOnChangedTrueTest() // 호출되야 할 때 제대로 되는가?
        {
            int before = 10;
            int after = 20;
            bool changed = false;
            EventVC<int> vc = new EventVC<int>(before);
            vc.onChanged += (b, a) => {
                changed = true; 
            };
            vc.v = after;
            Assert.True(changed);
        }
        [Fact]
        public void ValueOnChangedFalseTest()// 호출되지 말아야 할 때를 잘 필터링 하는가?
        {
            int v = 10;
            bool call = false;
            EventVC<int> vc = new EventVC<int>(v);
            vc.onChanged += (b, a) => { call = true; };
            vc.v = v;
            Assert.False(call);
        }
        [Fact]
        public void ValueOnChangedValueTest() // 이전 값과 바뀐 값을 잘 전달하는가?
        {
            int before = 10;
            int after = 20;
            int sendedBefore = 0;
            int sendedAfter = 0;
            EventVC<int> vc = new EventVC<int>(before);
            vc.onChanged += (b, a) => {
                sendedBefore = b;
                sendedAfter = a;
            };

            vc.v = after;

            Assert.True(sendedBefore == before);
            Assert.True(sendedAfter == after);
        }
        [Fact]
        public void ValueOnGetCallTest() // Get Evnet가 제대로 호출되는가?
        {
            int v = 10;
            bool get = false;
            EventVC<int> vc = new EventVC<int>(v);
            vc.onGet += (v) => get = true;
            int temp = vc.v;
            Assert.True(get);
        }
        [Fact]
        public void ValueOnGetCountTest() // Get 할 때 마다 잘 호출되는가?
        {
            int v = 10;
            int num = 5;
            int count = 0;
            EventVC<int> vc = new EventVC<int>(v);
            vc.onGet += (v) => count++;
            for (int i = 0; i < num; i++)
            {
                int temp = vc.v;
            }
            Assert.True(count == num);
        }
        [Fact]
        public void ValueOnSetCallTest()
        {
            int v = 10;
            bool set = false;
            EventVC<int> vc = new EventVC<int>(v);
            vc.onSet += (v) => set = true;
            vc.v = v;
            Assert.True(set);
        }
        [Fact]
        public void ValueOnSetCountTest() // Get 할 때 마다 잘 호출되는가?
        {
            int v = 10;
            int num = 5;
            int count = 0;
            EventVC<int> vc = new EventVC<int>(v);
            vc.onSet += (v) => count++;
            for (int i = 0; i < num; i++)
            {
                vc.v = v;
            }
            Assert.True(count == num);
        }
    }
}