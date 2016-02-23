using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _002_marsrovers;

namespace Tests
{
    [TestClass]
    public class RoverTests
    {

        [TestMethod]
        public void CreateRoversAndGetPositionsAndHeadings()
        {
            var positionA = new Position(5, 5);
            var headingA = new Heading('N');
            var pathA = new List<char> { 'M', 'M' };
            var roverA = new Rover(positionA, headingA, new Guid(), pathA);

            var positionB = new Position(4, 4);
            var headingB = new Heading('S');
            var pathB = new List<char> { 'M', 'M' };
            var roverB = new Rover(positionB, headingB, new Guid(), pathB);

            roverA.GetHeading().Should().Be('N');
            roverB.GetPosition().ShouldBeEquivalentTo(new Position(4, 4));
        }

        [TestMethod]
        public void MoveRover()
        {
            Plateau.SetPlateauBounds(10, 10);

            var positionA = new Position(5, 5);
            var headingA = new Heading('N');
            var pathA = new List<char> { 'M', 'M', 'L' };
            var roverA = new Rover(positionA, headingA, new Guid(), pathA);

            var successA = roverA.FollowPath();
            successA.Should().BeTrue();
            roverA.GetHeading().Should().Be('W');
            roverA.GetPosition().ShouldBeEquivalentTo(new Position(5, 7));

            var positionB = new Position(4, 4);
            var headingB = new Heading('S');
            var pathB = new List<char> { 'M', 'M', 'M', 'M', 'M' };
            var roverB = new Rover(positionB, headingB, new Guid(), pathB);
            var successB = roverB.FollowPath();
            successB.Should().BeFalse();
            roverB.GetHeading().Should().Be('S');
            roverB.GetPosition().ShouldBeEquivalentTo(new Position(4, -1));
        }
    }
}
