using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _002_marsrovers;

namespace Tests
{
    [TestClass]
    public class PlateauTests
    {
        [TestMethod]
        public void SetPlateauBounds()
        {
            Plateau.SetPlateauBounds(23, 52);
            var bounds = Plateau.GetPlateauBounds();
            bounds.ShouldBeEquivalentTo(new Position(23, 52));
        }

        [TestMethod]
        public void AddRoversToPlateauAndTestForCollissions()
        {
            Plateau.SetPlateauBounds(10, 10);

            var positionA = new Position(5, 5);
            var headingA = new Heading('N');
            var pathA = new List<char> {'M', 'M'};
            var roverA = new Rover(positionA, headingA, new Guid(), pathA);

            var positionB = new Position(4, 4);
            var headingB = new Heading('N');
            var pathB = new List<char> {'M', 'M'};
            var roverB = new Rover(positionB, headingB, new Guid(), pathB);

            var positionC = new Position(3, 3);
            var headingC = new Heading('N');
            var pathC = new List<char> {'M', 'M'};
            var roverC = new Rover(positionC, headingC, new Guid(), pathC);

            var positionD = new Position(2, 2);

            Plateau.AddRoverToPosition(positionA, roverA);
            Plateau.AddRoverToPosition(positionB, roverB);
            Plateau.AddRoverToPosition(positionC, roverC);

            Plateau.RoverAtPosition(positionA).Should().BeTrue();
            Plateau.RoverAtPosition(positionB).Should().BeTrue();
            Plateau.RoverAtPosition(positionC).Should().BeTrue();
            Plateau.RoverAtPosition(positionD).Should().BeFalse();
        }



        [TestMethod]
        public void TestForValidPositions()
        {
            Plateau.SetPlateauBounds(10, 10);

            Plateau.IsValidPosition(new Position(11, 10)).Should().BeFalse();
            Plateau.IsValidPosition(new Position(10, 11)).Should().BeFalse();
            Plateau.IsValidPosition(new Position(-1, 0)).Should().BeFalse();
            Plateau.IsValidPosition(new Position(10, 10)).Should().BeTrue();
        }
    }
}
