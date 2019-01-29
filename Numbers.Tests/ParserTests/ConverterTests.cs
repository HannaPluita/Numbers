using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Numbers.Logic;

namespace Numbers.Tests.ParserTests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void StrNumberToQueue_ConvertEmpty_False()
        {
            ConverterHeirTests converter = new ConverterHeirTests();
            bool act = converter.StrNumberToQueueTests();

            Assert.AreEqual(false, act);
        }

        [DataTestMethod]
        [DataRow("123456")]
        public void StrNumberToQueue_ConvertNumber_ReturnTrueNumber(string number)
        {
            Numeric numeric = new Numeric(number);
            ConverterHeirTests converter = new ConverterHeirTests(numeric);

            bool act = converter.StrNumberToQueueTests();

            Queue<char> expected = new Queue<char>();

            for(int i = 0; i < number.Length; ++i)
            {
                expected.Enqueue(number[i]);
            }

            CollectionAssert.AreEqual(expected, converter.QueueChars);
            Assert.AreEqual(true, act);
        }

        [TestMethod]
        public void StrNumberToQueue_ConvertEmptyNumber_ReturnFalse()
        {
            Numeric numeric = new Numeric();
            ConverterHeirTests converter = new ConverterHeirTests(numeric);

            bool act = converter.StrNumberToQueueTests();
           
            Assert.AreEqual(false, act);
        }

        [DataTestMethod]
        [DataRow("123456789")]
        [DataRow("123456")]
        [DataRow("123")]
        public void CountResidueOfTriplesDiv_NumberWithoutResidue_Return0(string number)
        {
            Numeric numeric = new Numeric(number);
            ConverterHeirTests converter = new ConverterHeirTests(numeric);

            byte act = converter.CountResidueOfTriplesDivTests();

            Assert.AreEqual(0, act);
        }

        [DataTestMethod]
        [DataRow("12345678", 2)]
        [DataRow("1234567", 1)]
        [DataRow("12345", 2)]
        [DataRow("1234", 1)]
        [DataRow("12", 2)]
        [DataRow("1", 1)]
        public void CountResidueOfTriplesDiv_NumberWithResidue_ReturnResidue(string number, int expected)
        {
            Numeric numeric = new Numeric(number);
            ConverterHeirTests converter = new ConverterHeirTests(numeric);
            converter.StrNumberToQueueTests();

            int act = converter.CountResidueOfTriplesDivTests();

            Assert.AreEqual(expected, act);
        }

        [DataTestMethod]
        [DataRow("123456789", 3)]
        [DataRow("12345678", 2)]
        [DataRow("1234567", 2)]
        [DataRow("12345", 1)]
        [DataRow("1234", 1)]
        [DataRow("12", 0)]
        [DataRow("1", 0)]
        public void CountQuotientOfTripleDiv_Numbers_ReturnQuotient(string number, int expected)
        {
            Numeric numeric = new Numeric(number);
            ConverterHeirTests converter = new ConverterHeirTests(numeric);
            converter.StrNumberToQueueTests();

            int act = converter.CountQuotientOfTripleDivTests();

            Assert.AreEqual(expected, act);
        }
    }
}
