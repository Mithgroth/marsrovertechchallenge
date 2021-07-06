using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Rover
    {
        public Coordinate Coordinates { get; set; }

        public Rover(Coordinate initialCoordinates)
        {
            Coordinates = initialCoordinates;
        }

        public void Turn(Way way)
        {
            var path = (int)Coordinates.Direction + (int)way;
            var numberOfDirections = Enum.GetNames(typeof(Direction)).Length;

            // if we are turning from north (0) to west (3), path will be -1.
            // handle this by manually offsetting the value to positive plane.
            // we'll apply reminder operation anyway.
            if (path < 0)
            {
                var distanceToZero = path / numberOfDirections;
                path += (distanceToZero * numberOfDirections) + numberOfDirections;
            }

            var newDirection = path % numberOfDirections;

            Coordinates.Direction = (Direction)newDirection;
        }
    }
}