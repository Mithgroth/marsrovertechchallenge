using System;
using System.Collections.Generic;

namespace App
{
    public class Expedition
    {
        private List<string> _commands;
        private Coordinate _bounds;
        public List<Rover> Rovers { get; set; }

        public Expedition()
        {
            _commands = new List<string>();
            Rovers = new List<Rover>();
        }

        public void Command(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("Command cannot be null.");
            }

            if (_commands.Count == 0) // initial command, defines the area
            {
                var commandDetails = command.Split(" ");
                if (commandDetails.Length == 2
                    && int.TryParse(commandDetails[0], out int commandDetail1)
                    && int.TryParse(commandDetails[1], out int commandDetail2))
                {
                    _bounds = new Coordinate(commandDetail1, commandDetail2, Direction.North);
                    _commands.Add(command);
                }
                else
                {
                    throw new ArgumentException("Invalid command");
                }
            }
            else if (_commands.Count % 2 == 1) // #1 command, defines rover's position
            {
                var commandDetails = command.Split(" ");
                var validDirections = new List<string>() { "N", "E", "S", "W" };
                if (commandDetails.Length == 3
                    && int.TryParse(commandDetails[0], out int commandDetail1)
                    && int.TryParse(commandDetails[1], out int commandDetail2)
                    && validDirections.Contains(commandDetails[2].ToUpper()))
                {
                    Rovers.Add(
                        new Rover(
                            new Coordinate(
                                commandDetail1,
                                commandDetail2,
                                (Direction)validDirections.IndexOf(commandDetails[2])
                                )
                            )
                        );
                    _commands.Add(command);
                }
                else
                {
                    throw new ArgumentException("Invalid command");
                }
            }
            else if (_commands.Count % 2 == 0) // #2 command, defines rover's movement
            {
                var commandDetails = command.ToCharArray();
                var lastRover = Rovers.FindLast(r => r is not null);
                var isCommandValid = false;

                foreach (var commandDetail in commandDetails)
                {
                    switch (commandDetail)
                    {
                        case 'L':
                            lastRover.Turn(Way.Left);
                            isCommandValid = true;
                            break;

                        case 'R':
                            lastRover.Turn(Way.Right);
                            isCommandValid = true;
                            break;

                        case 'M':
                            lastRover.Move();
                            isCommandValid = true;
                            break;

                        default:
                            throw new InvalidOperationException("Invalid Command");
                    }
                }

                if (isCommandValid)
                {
                    _commands.Add(command);
                }
            }
        }
    }
}