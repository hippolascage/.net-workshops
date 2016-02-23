using System.Collections.Generic;

namespace _002_marsrovers
{
    public static class Plateau
    {
        private static int _xSize;
        private static int _ySize;
        private static readonly Dictionary<Position, Rover> RoverPositions = new Dictionary<Position, Rover>();

        public static void SetPlateauBounds(int x, int y)
        {
            _xSize = x;
            _ySize = y;
        }

        public static Position GetPlateauBounds()
        {
            return new Position(_xSize, _ySize);
        }

        public static void AddRoverToPosition(Position position, Rover rover)
        {
            RoverPositions.Add(position, rover);
        }

        public static bool RoverAtPosition(Position newRoverPosition)
        {
            var roverCrashed = false;
            foreach (var existingRoverPosition in RoverPositions)
            {
                if (!newRoverPosition.PositionIsDisctinct(existingRoverPosition.Key))
                {
                    roverCrashed = true;
                }
            }
            return roverCrashed;
        }

        public static bool IsValidPosition(Position position)
        {
            return position.X <= _xSize && position.Y <= _ySize && position.X >= 0 && position.Y >= 0;
        }
    }
}
