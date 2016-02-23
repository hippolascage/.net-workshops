using System.Collections.Generic;

namespace _002_marsrovers
{
    public class RoverPath
    {
        private readonly Position _startPosition;
        private readonly Heading _startHeading;
        private readonly List<char> _movementInstructions = new List<char>();

        public RoverPath(Position startPosition, Heading startHeading, string movementInstructions)
        {
            _startHeading = startHeading;
            _startPosition = startPosition;

            foreach (var move in movementInstructions)
            {
                _movementInstructions.Add(move);
            }
        }

        public Position GetStartPosition()
        {
            return _startPosition;
        }

        public Heading GetStartHeading()
        {
            return _startHeading;
        }

        public List<char> GetMovementInstructions()
        {
            return _movementInstructions;
        } 
    }
}
