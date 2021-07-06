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

        [Test]
        public void CanTurnLeft()
        {
            rover.Turn(Way.Left);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.West);
        }

        [Test]
        public void CanTurnRight()
        {
            rover.Turn(Way.Right);

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 0);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.East);
        }

        [Test]
        public void CanMove()
        {
            rover.Move();

            Assert.IsTrue(rover.Coordinates.X == 0);
            Assert.IsTrue(rover.Coordinates.Y == 1);
            Assert.IsTrue(rover.Coordinates.Direction == Direction.North);
        }

        [Test]
        public void Expedition()
        {
            var expedition = new Expedition();

            expedition.Command("5 5");
            expedition.Command("1 2 N");
            expedition.Command("LMLMLMLMM");
            expedition.Command("3 3 E");
            expedition.Command("MMRMMRMRRM");

            var rover1 = expedition.Rovers[0];
            var rover2 = expedition.Rovers[1];

            Assert.IsTrue(rover1.Coordinates.X == 1);
            Assert.IsTrue(rover1.Coordinates.Y == 3);
            Assert.IsTrue(rover1.Coordinates.Direction == Direction.North);

            Assert.IsTrue(rover2.Coordinates.X == 5);
            Assert.IsTrue(rover2.Coordinates.Y == 1);
            Assert.IsTrue(rover2.Coordinates.Direction == Direction.East);
        }
    }
}