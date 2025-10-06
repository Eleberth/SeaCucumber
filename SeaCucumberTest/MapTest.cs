using SeaCucumber.Domain;

namespace SeaCucumberTest
{
    [TestClass]
    public sealed class MapTest
    {
        [TestMethod]
        public void EastFacingShouldStep()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(0, 0, Herd.EastFacing);
            map.ConsiderStepEast();

            Assert.AreEqual(1, map.SetStep());
            Assert.AreEqual(0, map.SeaCucumbers[0].Row);
            Assert.AreEqual(1, map.SeaCucumbers[0].Column);
        }

        [TestMethod]
        public void EastFacingLastColumnShouldStep()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(0, 1, Herd.EastFacing);
            map.ConsiderStepEast();

            Assert.AreEqual(1, map.SetStep());
            Assert.AreEqual(0, map.SeaCucumbers[0].Row);
            Assert.AreEqual(0, map.SeaCucumbers[0].Column);
        }

        [TestMethod]
        public void EastFacingShouldNotStep()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(0, 0, Herd.EastFacing);
            map.AddSeaCucumber(0, 1, Herd.EastFacing);
            map.ConsiderStepEast();

            Assert.AreEqual(0, map.SetStep());
            Assert.AreEqual(0, map.SeaCucumbers[0].Row);
            Assert.AreEqual(0, map.SeaCucumbers[0].Column);
            Assert.AreEqual(0, map.SeaCucumbers[1].Row);
            Assert.AreEqual(1, map.SeaCucumbers[1].Column);
        }

        [TestMethod]
        public void SouthFacingShouldStep()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(0, 0, Herd.SouthFacing);
            map.ConsiderStepSouth();

            Assert.AreEqual(1, map.SetStep());
            Assert.AreEqual(1, map.SeaCucumbers[0].Row);
            Assert.AreEqual(0, map.SeaCucumbers[0].Column);
        }

        [TestMethod]
        public void SouthFacingLastRowShouldStep()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(1, 0, Herd.SouthFacing);
            map.ConsiderStepSouth();

            Assert.AreEqual(1, map.SetStep());
            Assert.AreEqual(0, map.SeaCucumbers[0].Row);
            Assert.AreEqual(0, map.SeaCucumbers[0].Column);
        }

        [TestMethod]
        public void SouthFacingShouldNotStep()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(0, 0, Herd.SouthFacing);
            map.AddSeaCucumber(1, 0, Herd.SouthFacing);
            map.ConsiderStepSouth();

            Assert.AreEqual(0, map.SetStep());
            Assert.AreEqual(0, map.SeaCucumbers[0].Row);
            Assert.AreEqual(0, map.SeaCucumbers[0].Column);
            Assert.AreEqual(1, map.SeaCucumbers[1].Row);
            Assert.AreEqual(0, map.SeaCucumbers[1].Column);
        }

        [TestMethod]
        public void SameLocationShouldThrowException()
        {
            Map map = new(2, 2);

            map.AddSeaCucumber(0, 0, Herd.SouthFacing);

            Assert.ThrowsException<ArgumentException>(() => map.AddSeaCucumber(0, 0, Herd.SouthFacing));
        }
    }
}
