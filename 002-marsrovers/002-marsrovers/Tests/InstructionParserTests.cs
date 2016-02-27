using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using _002_marsrovers;

namespace Tests
{
    [TestFixture]
    public class InstructionParserTests
    {
        [Test]
        public void ParseInstructions()
        {
            var instructions = new List<string>
            {
                "6 3",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM",
                "1 2 N",
                "LMLMLMLMM"
            };
            var roverPaths = InstructionParser.Parse(instructions);

            roverPaths.Count().Should().Be(3);
            Plateau.GetPlateauBounds().ShouldBeEquivalentTo(new Position(6, 3));
        }

        [Test]
        public void ExecuteInstructions()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var instructions = new List<string>
            {
                "6 3",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM",
                "1 2 N",
                "LMLMLMLMM",
                "1 9 N",
                "LRLRMMMRL"
            };
            var roverPaths = InstructionParser.Parse(instructions);
            InstructionParser.Execute(roverPaths);

            Plateau.RoverAtPosition(new Position(1, 3)).Should().Be(true);

            /*
            stringWriter.ToString().Should().Be(
                "1 3 N\r\n" +
                "5 1 E\r\n" +
                "1 3 N CRASHED\r\n" +
                "1 9 N CRASHED\r\n");
            */
        }
    }
}