using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNextIntCalculator;
using System;

namespace MSTestProject
{
    [TestClass]
    public class IntCalculatorTest
    {
        [DataTestMethod]
        [DataRow(0, 1, 1)]
        [DataRow(0, -1, -1)]
        [DataRow(1, -1, 0)]
        [DataRow(-1, 1, 0)]
        [DataRow(0, int.MaxValue, int.MaxValue)]
        [DataRow(0, int.MinValue, int.MinValue)]
        public void AddValidNumber(int initialValue, int x, int expected)
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(initialValue);
            Assert.AreEqual(initialValue, c.Result);

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
