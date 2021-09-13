using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddValidNumber()
        {
            IIntCalculator c = new IntCalculator();
        }
    }
}
