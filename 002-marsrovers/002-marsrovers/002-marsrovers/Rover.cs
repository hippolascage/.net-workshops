using System;
using System.Collections.Generic;

namespace _002_marsrovers
{
    public class Rover
    {
        private readonly Guid _id;
        public Position Position { get; private set; } // expose property directly instead of getter and setter methods
        private readonly Heading _heading;
        private readonly List<char> _path;

        // path shouldn't be part of the constructor, the rover can exist without it

        // convert _path to an enum to reduce the possible valid ideas
        // extension methods 

        public Rover(Position position, Heading heading, Guid id, List<char> path)
        {
            // generate id within this class
            _id = id;
            Position = position;
            _heading = heading;
            _path = path;
        }

        public Guid GetId()
        {
            return _id;
        }


        public char GetHeading()
        {
            return _heading.GetHeading();
        }
         
        
        private bool TryMove()
        {
            var movements = new Dictionary<char, Action<Position>>();
            movements['N'] = (Position p) => p.SetPosition(p.X, p.X + 1);
            movements[_heading.GetHeading()](Position);

            switch (_heading.GetHeading())
            {
                case ('N'):
                    Position.SetPosition(Position.X, Position.Y + 1);
                    break;
                case ('S'):
                    Position.SetPosition(Position.X, Position.Y - 1);
                    break;
                case ('E'):
                    Position.SetPosition(Position.X + 1, Position.Y);
                    break;
                case ('W'):
                    Position.SetPosition(Position.X - 1, Position.Y);
                    break;
                    //default: throw something
            }
            return RoverStillOperational();
        }

        private bool RoverStillOperational()
        {
            if (!Plateau.IsValidPosition(Position))
            {
                return false;
            }
            return !Plateau.RoverAtPosition(Position);
        }

        private void TurnRight()
        {
            _heading.TurnRight();
        }

        private void TurnLeft()
        {
            _heading.TurnLeft();
        }

        public bool FollowPath()
        {
            var roverStillRunning = Plateau.IsValidPosition(Position);
            foreach (var step in _path)
            {
                if (roverStillRunning)
                {
                    if (step == ('M'))
                    {
                        roverStillRunning = TryMove();
                    }
                    else if (step == ('R'))
                    {
                        TurnRight();
                    }
                    else if (step == ('L'))
                    {
                        TurnLeft();
                    }
                }
                else
                {
                    return false;
                }           
            }
            return roverStillRunning;
        }
    }
}
