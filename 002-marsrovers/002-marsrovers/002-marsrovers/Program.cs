using System;

namespace _002_marsrovers
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case (0):
                    Console.WriteLine(UserFeedback.NoArgumentsSupplied);
                    break;

                case (1):
                    // strip out to method

                    // combine validation and parsing
                    var input = FileParser.Parse(args[0]);
                    var inputIsValid = FileParser.InstructionsAreValid(input);
                    if (inputIsValid)
                    {
                        var instructions = InstructionParser.Parse(input);
                        InstructionParser.Execute(instructions);
                    }
                    break;

                default:
                    Console.WriteLine(UserFeedback.TooManyArgumentsSupplied);
                    break;
            }
            Console.ReadLine();
        }
    }
}
