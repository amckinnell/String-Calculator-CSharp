using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorKata.Test
{
    [TestClass]
    public class RegularExpressionLearningTest
    {
        [TestMethod]
        public void ExtractsCustomDelimiter()
        {
            Regex regex = new Regex("//(.*)\n");
            MatchCollection matches = regex.Matches("//xx\n");

            Assert.AreEqual(1, matches.Count);
            Assert.AreEqual("xx", matches[0].Groups[1].Value);
        }

        [TestMethod]
        public void ExtractsNumbers()
        {
            Regex regex = new Regex("//(.*)\n(.*)");
            MatchCollection matches = regex.Matches("//xx\n1xx2");

            Assert.AreEqual(1, matches.Count);
            Assert.AreEqual("1xx2", matches[0].Groups[2].Value);
        }

        [TestMethod]
        public void SplitsExtractedNumbers()
        {
            Regex regex = new Regex("//(.*)\n(.*)");
            MatchCollection matches = regex.Matches("//xx\n1xx2");

            string[] numbers = matches[0].Groups[2].Value
                                                   .Split(new[] {matches[0].Groups[1].Value},
                                                          StringSplitOptions.None);

            Assert.AreEqual(2, numbers.Length);
            Assert.AreEqual("1", numbers[0]);
            Assert.AreEqual("2", numbers[1]);
        }
    }
}
