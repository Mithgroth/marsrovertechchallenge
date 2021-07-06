using App;
using NUnit.Framework;

namespace Test
{
    public class MarsTests
    {
        private Rover rover;

        [SetUp]
        public void Setup()
        {
            rover = new Rover();
        }

        [Test]
        public void SetInitialCoordinate()
        {
            var initialCoordinates = new Coordinate(0, 0, Direction.North);

            rover.Coordinates = initialCoordinates;

            Assert.AreEqual(rover.Coordinates, initialCoordinates);
        }
    }
}