using NUnit.Framework.Internal;
using System.Diagnostics;
using Assignment4;
namespace Assignment4Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddTest()
        {
            int result = MathClass.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SubtractTest()
        {
            int result = MathClass.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void MultiplyTest()
        {
            int result = MathClass.Multiply(3, 2);
            Assert.AreEqual(6, result);
        }
    }
   






}