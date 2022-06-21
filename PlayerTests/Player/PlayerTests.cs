using Xunit;
using Hoonisone.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoonisone.Player.Tests
{
    public class PlayerTests
    {
        [Theory]
        [InlineData(1)]
        public void SetSpeedTest(float speed)
        {
            Player p = new Player();
            //p.speed.v = speed;

            Assert.True(true, "This test needs an implementation");
        }

/*        [Fact()]
        public void PauseTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void InitTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SetSpeedTest()
        {
            Assert.True(false, "This test needs an implementation");
        }*/
    }
}