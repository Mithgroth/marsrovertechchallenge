using App;
using NUnit.Framework;

namespace Test
{
    public class MarsTests
    {
        private Rover rover;
        private Coordinate initialCoordinates;

        [SetUp]
        public void Setup()
        {
            initialCoordinates = new Coordinate(0, 0, Direction.North);
            rover = new Rover(initialCoordinates);
        }

        [Test]
        public void SetInitialCoordinate()
        {
            Assert.AreEqual(rover.Coordinates, initialCoordinates);
        }

        [Test]
        public void CanTurnLeft()
        {
            // reset to initial
            rover.Coordinates = initialCoordinates;
            rover.Turn(Way.Left);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.West);
        }

        [Test]
        public void CanTurnRight()
        {
            // reset to initial
            rover.Coordinates = initialCoordinates;
            rover.Turn(Way.Right);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.East);
        }
    }
}