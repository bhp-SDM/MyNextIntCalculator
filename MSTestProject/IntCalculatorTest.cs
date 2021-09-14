using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNextIntCalculator;
using System;

namespace MSTestProject
{
    [TestClass]
    public class IntCalculatorTest
    {
        [TestMethod]
        public void CreateNewIntCalculator()
        {
            // Arrange
            IIntCalculator c = null;
            
            // Act
            c = new IntCalculator();
            
            // Assert
            Assert.IsNotNull(c);
            Assert.IsTrue(c is IntCalculator);
            Assert.AreEqual(0, c.Result);
        }

        [TestMethod]
        public void ResetResultIsZero()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(1);
            Assert.AreNotEqual(0, c.Result);
            
            // Act
            c.Reset();

            // Assert
            Assert.AreEqual(0, c.Result);
        }

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
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(int.MaxValue);
            int oldResult = c.Result;

            // Act
            void action() => c.Add(1);

            // Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(action);

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
            
            // Act
            void action() => c.Add(-1);

            // Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(action);
            Assert.AreEqual("Underflow while adding", ex.Message);
            Assert.AreEqual(oldResult, c.Result);
        }

        [DataTestMethod]
        [DataRow(0, 1, -1)]
        [DataRow(0, -1, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(-1, -1, 0)]
        [DataRow(0, -int.MaxValue, int.MaxValue)]
        [DataRow(-1, int.MaxValue, int.MinValue)]
        public void SubValidNumber(int initialValue, int x, int expected)
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(initialValue);
            Assert.AreEqual(initialValue, c.Result);

            // Act
            c.Sub(x);

            // Assert
            Assert.AreEqual(expected, c.Result);
        }

        [TestMethod]
        public void SubNumberWithUnderflowExpectExceptionToBeThrown()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(-int.MaxValue);
            c.Add(-1);
            int oldResult = c.Result;

            // Act
            void action() => c.Sub(1);

            // Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(action);
            Assert.AreEqual("Underflow while subtracting", ex.Message);
            Assert.AreEqual(oldResult, c.Result);
        }
        [TestMethod]

        public void SubNumberWithOverflowExpectExceptionToBeThrown()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();

            c.Add(int.MaxValue);
            int oldResult = c.Result;

            // Act
            void action() => c.Sub(-1);

            // Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(action);

            Assert.AreEqual("Overflow while subtracting", ex.Message);
            Assert.AreEqual(oldResult, c.Result);
        }

        [DataTestMethod]
        //[DataRow(0,int.MaxValue, 0)]
        //[DataRow(int.MaxValue, 0, 0)]
        //[DataRow(1234, 1, 1234)]
        //[DataRow(1234, -1, -1234)]
        //[DataRow(-1234, -1, 1234)]
        //[DataRow(int.MaxValue / 2, 2, (int.MaxValue / 2) * 2)]
        [DataRow(int.MinValue / 2, 2, (int.MinValue / 2) * 2)]
        public void MulValidResult(int initialValue, int x, int expected)
        { 
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(initialValue);
            Assert.AreEqual(initialValue, c.Result);

            // Act
            c.Mul(x);

            // Assert
            Assert.AreEqual(expected, c.Result);
        }

        [TestMethod]
        public void MulOverflowExpectExceptionToBeThrown()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(int.MaxValue / 2 + 1);
            int oldValue = c.Result;
            
            // Act
            void action() => c.Mul(2);

            // Assert
            var ex = Assert.ThrowsException<InvalidOperationException>(action);
            Assert.AreEqual("Overflow while multiplying", ex.Message);
            Assert.AreEqual(oldValue, c.Result);
        }

        [DataTestMethod]
        [DataRow(13, 3, 4)]
        [DataRow(-13, 3, -4)]
        [DataRow(13, -3, -4)]
        [DataRow(-13, -3, 4)]
        [DataRow(0, int.MaxValue, 0)]
        [DataRow(0, int.MinValue, 0)]
        [DataRow(int.MaxValue, int.MaxValue, 1)]
        [DataRow(int.MinValue, int.MinValue, 1)]
        public void DivValidNumber(int initialValue, int x, int expected)
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(initialValue);
            Assert.AreEqual(initialValue, c.Result);

            // Act
            c.Div(x);

            //Arrange
            Assert.AreEqual(expected, c.Result);
        }

        [TestMethod]
        public void DivWithZeroExpectExceptionToBeThrown()
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(1234);
            int oldValue = c.Result;

            // Act
            void action() => c.Div(0);

            //Arrange
            var ex = Assert.ThrowsException<InvalidOperationException>(action);
            Assert.AreEqual("Division by zero is undefined", ex.Message);
            Assert.AreEqual(oldValue, c.Result);
        }

        [DataTestMethod]
        [DataRow(12, 3, 0)]
        [DataRow(13, 3, 1)]
        [DataRow(14, 3, 2)]
        [DataRow(13, -3, 1)]
        [DataRow(-13, 3, -1)]
        [DataRow(-13, -3, -1)]
        public void ModTest(int initialValue, int x, int expected)
        {
            // Arrange
            IIntCalculator c = new IntCalculator();
            c.Add(initialValue);
            Assert.AreEqual(initialValue, c.Result);

            // Act
            c.Mod(x);

            //Arrange
            Assert.AreEqual(expected, c.Result);
        }
    }
}
