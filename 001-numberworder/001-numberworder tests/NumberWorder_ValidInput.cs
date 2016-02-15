using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _001_numberworder;

namespace _001_numberworder_tests
{
    [TestClass]
    public class NumberWorder_ValidInput
    {
        [TestMethod]
        public void SingleInteger()
        {
            var input = "5";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("FIVE");
        }

        [TestMethod]
        public void MultipleIntegers()
        {
            var input = "465233";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("FOURSIXFIVETWOTHREETHREE");
        }

        [TestMethod]
        public void RepeatingIntegers()
        {
            var input = "55555";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("FIVEFIVEFIVEFIVEFIVE");
        }

        [TestMethod]
        public void ManyIntegers()
        {
            var input = "46523355555112";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("FOURSIXFIVETWOTHREETHREEFIVEFIVEFIVEFIVEFIVEONEONETWO");
        }

    }
}
