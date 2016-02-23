using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _002_marsrovers
{
    public class Rover
    {
        private readonly Guid _id;
        private readonly Position _position;
        private readonly Heading _heading;
        private readonly List<char> _path;

        public Rover(Position position, Heading heading, Guid id, List<char> path)
        {
            _id = id;
            _position = position;
            _heading = heading;
            _path = path;
        }

        public Guid GetId()
        {
            return _id;
        }

        public Position GetPosition()
        {
            return _position;
        }

        public char GetHeading()
        {
            return _heading.GetHeading();
        }
         
        private bool TryMove()
        {
            if (_heading.GetHeading() == ('N'))
            {
                _position.SetPosition(_position.X, _position.Y + 1);
            }
            else if (_heading.GetHeading() == ('S'))
            {
                _position.SetPosition(_position.X, _position.Y - 1);
            }
            else if (_heading.GetHeading() == ('E'))
            {
                _position.SetPosition(_position.X + 1, _position.Y);
            }
            else if (_heading.GetHeading() == ('W'))
            {
                _position.SetPosition(_position.X - 1, _position.Y);
            }
            return RoverStillOperational();
        }

        private bool RoverStillOperational()
        {
            if (!Plateau.IsValidPosition(_position))
            {
                return false;
            }
            return !Plateau.RoverAtPosition(_position);
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
            var roverStillRunning = Plateau.IsValidPosition(_position);
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
