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
            initialCoordinates = new(0, 0, Direction.North);
            rover = new Rover(initialCoordinates);
        }

        [Test]
        public void SetInitialCoordinates()
        {
            Assert.AreEqual(rover.Coordinates, initialCoordinates);
        }

        private void ResetRoverPosition()
        {
            rover.Coordinates = initialCoordinates;
        }

        [Test]
        public void CanTurnLeft()
        {
            ResetRoverPosition();
            rover.Turn(Way.Left);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.West);
        }

        [Test]
        public void CanTurnRight()
        {
            ResetRoverPosition();
            rover.Turn(Way.Right);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.East);
        }

        [Test]
        public void CanMove()
        {
            ResetRoverPosition();
            rover.Move();

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 1);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.North);
        }
    }
}