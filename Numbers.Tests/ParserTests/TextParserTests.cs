using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Numbers.Tests.ParserTests
{
    [TestClass]
    public class TextParserTests
    {
        [DataTestMethod]
        [DataRow("hv0r7v8g9jxchv", "0789")]
        public void PickOutNumerals_PickFromNotNumberString_PickRight(string input, string expect)
        {
            string act = TextParser.PickOutNumerals(input);
            Assert.AreEqual(expect, act);
        }

        [DataTestMethod]
        [DataRow("", "")]
        public void PickOutNumerals_PickFromEmptyString_Empty(string input, string expect)
        {
            string act = TextParser.PickOutNumerals(input);
            Assert.AreEqual(expect, act);
        }

        [DataTestMethod]
        [DataRow("0abcde0", "abcde0")]
        [DataRow("00abcde00", "abcde00")]
        [DataRow("000", "")]
        [DataRow(null, "")]
        [DataRow("", "")]
        public void StartZerosTrim_Trim_CorrectTrim(string input, string expect)
        {
            string act = TextParser.StartZerosTrim(input);
            Assert.AreEqual(expect, act);
        }

        [DataTestMethod]
        [DataRow("0abcde0", "0abcde")]
        [DataRow("00abcde00", "00abcde")]
        [DataRow("000", "")]
        [DataRow(null, "")]
        [DataRow("", "")]
        public void EndZerosTrim_Trim_CorrectTrim(string input, string expect)
        {
            string act = TextParser.EndZerosTrim(input);
            Assert.AreEqual(expect, act);
        }
    }
}
