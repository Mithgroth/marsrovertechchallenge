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
            rover = new Rover();
            initialCoordinates = new Coordinate(0, 0, Direction.North);
        }

        [Test]
        public void SetInitialCoordinate()
        {
            rover.Coordinates = initialCoordinates;
            Assert.AreEqual(rover.Coordinates, initialCoordinates);
        }

        [Test]
        public void CanTurnLeft()
        {
            // reset to initial
            rover.Coordinates = initialCoordinates;
            rover.Turn(App.Way.Left);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.West);
        }

        [Test]
        public void CanTurnRight()
        {
            // reset to initial
            rover.Coordinates = initialCoordinates;
            rover.Turn(App.Way.Right);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.East);
        }
    }
}
}