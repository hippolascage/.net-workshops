using FluentAssertions;
using NUnit.Framework;
using _002_marsrovers;

namespace Tests
{
    [TestFixture]
    public class HeadingTests
    {
        [Test]
        public void CreateHeading()
        {
            var north = new Heading('N');
            north.GetHeading().Should().Be('N');
        }

        [Test]
        public void CreateHeadingAndDoSomeTurns()
        {
            var heading = new Heading('N');
            heading.TurnRight();
            heading.GetHeading().Should().Be('E');

            heading.TurnLeft();
            heading.TurnRight();
            heading.TurnRight();
            heading.GetHeading().Should().Be('S');

            heading.TurnLeft();
            heading.TurnLeft();
            heading.TurnLeft();
            heading.GetHeading().Should().Be('W');
        }

    }
}
