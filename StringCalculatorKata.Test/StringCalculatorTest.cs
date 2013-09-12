using System;
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

        [TestMethod]
        public void AddsMultipleNumbersToSumWhenNewlineDelimiter()
        {
            Assert.AreEqual(6, sut.Add("1,2\n3"));
        }

        [TestMethod]
        public void AddsMultipleNumbersToSumWhileIgnoringLargeNumbers()
        {
            Assert.AreEqual(1999, sut.Add("999,1000,1001"));
        }

        [TestMethod]
        public void AddsMultipleNumbersToSumWhenCustomDelimiter()
        {
            Assert.AreEqual(3, sut.Add("//;\n1;2"));
            Assert.AreEqual(6, sut.Add("//x\n1x2x3"));
        }

        [TestMethod]
        public void AddsMultipleNumbersToSumWhenMultiCharacterCustomDelimiter()
        {
            Assert.AreEqual(5, sut.Add("//xx\n2xx3"));
            Assert.AreEqual(6, sut.Add("//***\n2***4"));
            Assert.AreEqual(12, sut.Add("//yyy\n2yyy4yyy6"));
        }

        [TestMethod]
        public void FailsToAddNegativeNumbers()
        {
            try
            {
                sut.Add("-1,2,-3,-4");
                Assert.Fail("Expected an exception because of negative numbers");
            }
            catch (SystemException expected)
            {
                Assert.AreEqual(expected.Message, "Negatives not allowed: -1,-3,-4");
            }
        }

        [TestMethod]
        public void AddsMultipleNumbersToSumWhenMultipleCustomDelimiters()
        {
            Assert.AreEqual(6, sut.Add("//[;][xx]\n1;2xx3"));
            Assert.AreEqual(9, sut.Add("//[xx][yyy]\n2xx3yyy4"));
        }
    }
}
