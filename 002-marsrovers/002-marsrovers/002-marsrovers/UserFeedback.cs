namespace _002_marsrovers
{
    public static class UserFeedback
    {
        public const string NoArgumentsSupplied =
            "You have not supplied instructions for the Rovers. Call MarsRovers with a single argument. " +
            "This argument should be the path to a text file containing instructions.";

        public const string TooManyArgumentsSupplied =
            "You have supplied too many arguments. Call MarsRovers with a single argument. " +
            "This argument should be the path to a text file containing instructions.";

        public const string FileCouldNotBeRead = "The file could not be read: ";

        public const string InvalidStartingPoint = "The starting point provided in line {0} was invalid.";

        public const string InvalidMovementInstructions =
            "The movement instructions provided in line {0} were invalid.";

        public const string InvalidFileFormat =
            "The file supplied was not formatted correctly. For one, the file should contain an odd number of lines.";

        public const string RoverMovementCompleted = "{0} {1} {2}";

        public const string RoverMovementAbandoned =
            "{0} {1} {2} CRASHED";
    }
}
