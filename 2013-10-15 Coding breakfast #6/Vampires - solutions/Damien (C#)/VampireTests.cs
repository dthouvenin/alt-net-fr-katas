using System.Linq;
using MbUnit.Framework;

namespace Vampires
{
    [TestFixture]
    public class VampireTests
    {
        [Test]
        public void DigitsAreExtractedCorrectly()
        {
            var number = 17650;
            var expectedDigits = new[] {0, 5, 6, 7, 1};

            var digits = Program.Digits(number);
            
            Assert.AreElementsEqual(expectedDigits, digits);
        }

        [Test]
        public void ExtractedDigitsSortedCorrectly()
        {
            var number = 17250;
            var expectedDigits = new[] { 0, 1, 2, 5, 7 };

            var digits = Program.SortedDigits(number);

            Assert.AreElementsEqual(expectedDigits, digits);
        }

        [Test]
        public void CombinedDigitsSortedCorrectly()
        {
            var a = 172;
            var b = 501;
            var expectedDigits = new[] { 0, 1, 1, 2, 5, 7 };

            var digits = Program.SortedDigits(a, b);

            Assert.AreElementsEqual(expectedDigits, digits);
        }
    }
}
