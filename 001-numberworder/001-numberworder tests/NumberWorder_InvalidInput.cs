using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _001_numberworder;

namespace _001_numberworder_tests
{
    [TestClass]
    public class NumberWorder_InvalidInput
    {
        [TestMethod]
        public void InvalidCharacterAlphanumeric()
        {
            var input = "12A34";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("ONETWO>> \"A\" invalid character supplied. Integers only, please.<<THREEFOUR");
        }

        [TestMethod]
        public void InvalidCharacterNonAlpha()
        {
            var input = "12#34";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("ONETWO>> \"#\" invalid character supplied. Integers only, please.<<THREEFOUR");
        }

        [TestMethod]
        public void InvalidCharacterNonAscii()
        {
            var input = "12¡34";
            var numberWorder = new NumberWorder(input);
            var output = numberWorder.GetOutput();
            output.Should().Be("ONETWO>> \"¡\" invalid character supplied. Integers only, please.<<THREEFOUR");
        }

    }
}
