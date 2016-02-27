using System;
using System.Collections.Generic;
using System.Linq;

namespace _002_marsrovers
{
    public static class InstructionParser
    {
        static readonly List<RoverPath> RoverPathList = new List<RoverPath>();

        public static IEnumerable<RoverPath> Parse(List<string> instructions)
        {
            var bounds = instructions[0].Split(' ');
            int boundsX;
            int boundsY;

            int.TryParse(bounds[0], out boundsX);
            int.TryParse(bounds[1], out boundsY);
            Plateau.SetPlateauBounds(boundsX, boundsY);

            for (var i = 1; i < instructions.Count; i += 2)
            {
                var currentInstruction = instructions[i].Split(' ');
                var x = int.Parse(currentInstruction[0]);
                var y = int.Parse(currentInstruction[1]);
                var heading = char.Parse(currentInstruction[2]);

                var startPosition = new Position(x, y);
                var startHeading = new Heading(heading);
                var path = instructions[i + 1];

                var roverPath = new RoverPath(startPosition, startHeading, path);
                RoverPathList.Add(roverPath);
            }
            return RoverPathList;
        }
        
        public static void Execute(IEnumerable<RoverPath> instructions)
        {
            foreach (var rover in instructions.Select(instruction => new Rover(instruction.GetStartPosition(), 
                instruction.GetStartHeading(), Guid.NewGuid(), instruction.GetMovementInstructions())))
            {
                var success = rover.FollowPath();
                if (success)
                {
                    Console.WriteLine(UserFeedback.RoverMovementCompleted, rover.Position.X, rover.Position.Y,
                        rover.GetHeading());
                }
                else
                {
                    Console.WriteLine(UserFeedback.RoverMovementAbandoned, rover.Position.X, rover.Position.Y,
                        rover.GetHeading());
                }
                Plateau.AddRoverToPosition(rover.Position, rover);
            }
        }
    }
}