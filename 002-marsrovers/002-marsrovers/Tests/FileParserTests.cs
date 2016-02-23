using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _002_marsrovers;

namespace Tests
{
    [TestClass]
    public class FileParserTests
    {    
        [TestMethod]
        public void Parse_InvalidFilePath()
        {
            var stringWriter  = new StringWriter();
            Console.SetOut(stringWriter);

            const string filePath = "..\\..\\Instructions\\bogus.txt";
            var parsedInstructions = FileParser.Parse(filePath);
            parsedInstructions.Should().BeEmpty();
            stringWriter.ToString().Should().StartWith(UserFeedback.FileCouldNotBeRead);
        }

        [TestMethod]
        public void Parse_ValidFilePath()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            const string filePath = "..\\..\\Instructions\\example.txt";
            var parsedInstructions = FileParser.Parse(filePath);
            var expectedResult = new List<string> { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"};
            parsedInstructions.Should().BeEquivalentTo(expectedResult);
            stringWriter.ToString().Should().BeEmpty();
        }

        [TestMethod]
        public void InstructionsAreValid_ValidInstructions()
        {
            var instructions = new List<string> { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var instructionsAreValid = FileParser.InstructionsAreValid(instructions);
            instructionsAreValid.Should().BeTrue();
        }
   
        [TestMethod]
        public void InstructionsAreValid_InvalidBounds()
        {
            var instructions = new List<string> { "5 5 3", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var instructionsAreValid = FileParser.InstructionsAreValid(instructions);
            instructionsAreValid.Should().BeFalse();
        }

        [TestMethod]
        public void InstructionsAreValid_InvalidStartingPoint()
        {
            var instructions = new List<string> { "5 5", "1 2 N 4", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var instructionsAreValid = FileParser.InstructionsAreValid(instructions);
            instructionsAreValid.Should().BeFalse();
        }

        [TestMethod]
        public void InstructionsAreValid_InvalidMovementInstructions()
        {
            var instructions = new List<string> { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRNMMRMRRM" };
            var instructionsAreValid = FileParser.InstructionsAreValid(instructions);
            instructionsAreValid.Should().BeFalse();
        }
    }
}
