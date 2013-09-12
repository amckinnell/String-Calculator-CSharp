using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorKata.Test
{
    [TestClass]
    public class StringCalculatorTest
    {
        private readonly StringCalculator sut = new StringCalculator();

        [TestMethod]
        public void AddsEmptyNumbersToZero()
        {
            Assert.AreEqual(0, sut.Add(""));
        }

        [TestMethod]
        public void AddsSingleNumberToItself()
        {
            Assert.AreEqual(1, sut.Add("1"));
            Assert.AreEqual(2, sut.Add("2"));
        }

        [TestMethod]
        public void AddsMultipleNumbersToSum()
        {
            Assert.AreEqual(3, sut.Add("1,2"));
            Assert.AreEqual(5, sut.Add("2,3"));
            Assert.AreEqual(10, sut.Add("1,2,3,4"));
        }
    }
}
