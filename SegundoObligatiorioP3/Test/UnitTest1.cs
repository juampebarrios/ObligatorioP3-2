using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    public class Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            [SetUp]
            public void Setup()
            {
                dbContext = new AutomovilesContext();
            }
        }
    }
}
