using Assignment3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApp.UnitTests.Services
{
    [TestFixture]
    internal class CalculationTest
    {
        private Calculations _calculations;

        [SetUp]
        public void Setup()
        {
            _calculations = new Calculations();
        }

        [TestCase(5, 6, 11)]
        [TestCase(10, 6, 16)]
        [TestCase(5, -6, -1)]
        [TestCase(50, 6, 56)]
        public void Add_WhenCalled_ReturnsSumOfNumbers(int x, int y, int expected)
        {
            // Act
            int result = _calculations.Add(x, y);

            // Assert
            Assert.AreEqual(expected, result);
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifferenceOfNumbers()
        {
            // Act
            int result = _calculations.Subtract(5, 6);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
