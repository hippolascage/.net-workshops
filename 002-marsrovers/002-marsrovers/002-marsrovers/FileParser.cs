using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _002_marsrovers
{
    public static class FileParser
    {
        private static readonly List<char> ValidMovesList = new List<char> {'L', 'R', 'M'};
        private static readonly List<char> ValidHeadingsList = new List<char> {'N', 'E', 'W', 'S'};

        public static List<string> Parse(string filePath)
        {
            var input = new List<string>();
            try
            {
                string line;
                var file = new StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    input.Add(line);
                }
                file.Close(); // wrap streamreader in a using statement
            }
            catch (IOException e)
            {
                Console.WriteLine(UserFeedback.FileCouldNotBeRead + e.Message);
            }
            return input; // return within try, throw an exception for partial read 
            // file. readalllines
        }

        public static bool InstructionsAreValid(List<string> instructionsList)
        {
            if (instructionsList.Count % 2 == 0)
            {
                Console.WriteLine(UserFeedback.InvalidFileFormat);
                return false;
            }

            var startingPositionIsValid = ValidBounds(instructionsList[0]);
            if (!startingPositionIsValid) return false;

            for (var i = 1; i < instructionsList.Count; i++)
            {

                switch (i % 2)
                {
                    case (1): // odd numbered rows should be starting positions + headings
                        if (!ValidStartingPosition(instructionsList[i]))
                        {
                            Console.WriteLine($"This is invalid {i}");
                            return false;
                        }
                        break;

                    default: // this is should be movement instructions
                        if (!ValidMovementInstructions(instructionsList[i]))
                        {
                            Console.WriteLine(UserFeedback.InvalidMovementInstructions, i);
                            return false;
                        }
                        break;
                }
                
            }
            return true;
        }


        private static bool ValidStartingPosition(string position)
        {
            var positionArray = position.Split(' ');
            if (positionArray.Length != 3) return false;
            int x;
            int y;
            var heading = Convert.ToChar(positionArray[2]);

            return int.TryParse(positionArray[0], out x) && int.TryParse(positionArray[1], out y)
                   && ValidHeadingsList.Contains(heading);
        }

        private static bool ValidMovementInstructions(string instructions)
        {
            var moves = instructions.ToCharArray();
            return instructions.All(i => ValidMovesList.Contains(i));
        }

        private static bool ValidBounds(string plateauBounds)
        {
            var boundsArray = plateauBounds.Split(' ');
            if (boundsArray.Length != 2) return false;
            int x;
            int y;
            return int.TryParse(boundsArray[0], out x) && int.TryParse(boundsArray[1], out y);
        }
    }
}
