using FluentAssertions;
using NUnit.Framework;
using _002_marsrovers;

namespace Tests
{
    [TestFixture]
    public class RoverPathTests
    {
        [Test]
        public void CreateRoverPaths()
        {
            var positionA = new Position(5, 5);
            var headingA = new Heading('N');
            var pathA = "MMRLMM";
            var roverPathA = new RoverPath(positionA, headingA, pathA);

            var positionB = new Position(4, 4);
            var headingB = new Heading('S');
            var pathB = "MMMMMMM";
            var roverPathB = new RoverPath(positionB, headingB, pathB);

            roverPathA.GetStartHeading().GetHeading().ShouldBeEquivalentTo('N');
            roverPathA.GetStartPosition().ShouldBeEquivalentTo(new Position(5, 5));

            roverPathB.GetStartHeading().GetHeading().ShouldBeEquivalentTo('S');
            roverPathB.GetStartPosition().ShouldBeEquivalentTo(new Position(4, 4));

        }
    }
}
