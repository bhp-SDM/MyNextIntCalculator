using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNextIntCalculator;
using System;

namespace MSTestProject
{
    [TestClass]
    public class IntCalculatorTest
    {
        [TestMethod]
        public void AddValidNumber()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();

            int x = 1234;
            int oldResult = c.Result;
            int expected = oldResult + x;

            // Act
            c.Add(x);

            // Assert
            Assert.AreEqual(expected, c.Result);
        }

        [TestMethod]
        public void AddNumberWithOverflowExpectExceptionToBeThrown()
        {
            IIntCalculator c = new IntCalculator();
            c.Add(int.MaxValue);
            int oldResult = c.Result;

            var ex = Assert.ThrowsException<InvalidOperationException>(() => c.Add(1));

            Assert.AreEqual("Overflow while adding", ex.Message);
            Assert.AreEqual(oldResult, c.Result);
        }

        [TestMethod]
        public void AddNumberWithUnderflowExpectExceptionToBeThrown()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            
            c.Add(int.MinValue);
            int oldResult = c.Result;

            // Act + Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(() => c.Add(-1));

            Assert.AreEqual("Underflow while adding", ex.Message);
            Assert.AreEqual(oldResult, c.Result);
        }
    }
}
