using System;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace RechercheIndexee
{
    [TestFixture]
    public class FinderTests
    {
        [Test]
        public void WhenNotFoundShouldReturnMinusOne()
        {
            var array = new int[]{1, 3, 4};

            var res = Finder.FindIn(array);

            Assert.AreEqual(-1, res);
        }

        [Test]
        public void GivenAnArrayWithOneSolutionShouldReturnIndexOfSolution()
        {
            var array = new int[] { -2, 0, 1, 3, 5, 8 };

            var res = Finder.FindIn(array);

            Assert.AreEqual(3, res);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void WhenGivenAnEmptyArrayShouldThrowException()
        {
            var array = new int[0];

            Finder.FindIn(array);
        }
    }
}
