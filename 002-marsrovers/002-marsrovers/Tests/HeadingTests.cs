using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _002_marsrovers;

namespace Tests
{
    [TestClass]
    public class HeadingTests
    {
        [TestMethod]
        public void CreateHeading()
        {
            var north = new Heading('N');
            north.GetHeading().Should().Be('N');
        }

        [TestMethod]
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
