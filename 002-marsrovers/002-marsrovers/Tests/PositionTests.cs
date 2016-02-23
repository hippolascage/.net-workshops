using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _002_marsrovers;

namespace Tests
{
    [TestClass]
    public class PositionTests
    {

        [TestMethod]
        public void CreateAndSetPosition()
        {
            var position = new Position(5, 3);
            position.GetPosition().ShouldBeEquivalentTo(new Position(5, 3));

            position.SetPosition(6,2);
            position.GetPosition().ShouldBeEquivalentTo(new Position(6, 2));
        }

        [TestMethod]
        public void PositionToString()
        {
            var position = new Position(3, 1);
            position.ToString().Should().Be("3, 1");
        }

        [TestMethod]
        public void PositionIsDistinct()
        {
            var positionA = new Position(5, 5);
            var positionB = new Position(3, 3);
            positionA.PositionIsDisctinct(positionB).Should().BeTrue();

            var positionC = new Position(5, 3);
            var positionD = new Position(5, 3);
            positionC.PositionIsDisctinct(positionD).Should().BeFalse();
        }
    }
}
