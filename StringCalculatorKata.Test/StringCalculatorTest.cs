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
    }
}
