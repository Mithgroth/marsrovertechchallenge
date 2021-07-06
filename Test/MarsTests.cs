using App;
using NUnit.Framework;

namespace Test
{
    public class MarsTests
    {
        [SetUp]
        public void Setup()
        {
            var rover = new Rover();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}