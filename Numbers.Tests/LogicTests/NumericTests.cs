using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Numbers.Logic;

namespace Numbers.Tests.LogicTests
{
    [TestClass]
    public class NumericTests
    {
        [TestMethod]
        public void IsEmptyProperty_Empty_True()
        {
            Numeric numer = new Numeric();
            Assert.AreEqual(true, numer.IsEmpty);
        }

        [TestMethod]
        public void IsEmptyProperty_NotEmpty_False()
        {
            Numeric numer = new Numeric("789");
            Assert.AreEqual(false, numer.IsEmpty);
        }

        [TestMethod]
        public void ClearOutNumber_Empty_ReturnFalseAndEmptyNumber()
        {
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests();

            Assert.AreEqual(false, numer.ClearOutNumber());
            Assert.AreEqual("", numer.Number);
        }

        [TestMethod]
        public void ClearOutNumber_NotEmpty_True()
        {
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests("789");

            Assert.AreEqual(true, numer.ClearOutNumber());
        }

        [TestMethod]
        public void ClearOutNumber_CleanNumber_ReturnTrueAndNumeber()
        {
            string expectNum = "789";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(expectNum);

            bool actReturn = numer.ClearOutNumber();

            Assert.AreEqual(expectNum, numer.Number);
            Assert.AreEqual(true, actReturn);
        }

        [TestMethod]
        public void ClearOutNumber_NotOnlyNumber_ReturnTrueAndClearNumeber()
        {
            string input = "abc789cd 0 ";
            string expectedNum = "7890";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);

            bool actReturn = numer.ClearOutNumber();

            Assert.AreEqual(expectedNum, numer.Number);
            Assert.AreEqual(true, actReturn);
        }

        [TestMethod]
        public void Init_InitNumeric_ClearNumberAndAssignedRank()
        {
            string input = "abc789cd 0 ";
            string expectedNum = "7890";
            Rank expectedRank = Rank.Thousand;

            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);

            numer.Init();

            Assert.AreEqual(expectedNum, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void Init_InitEmptyNumeric_EmptyNumberAndRankDefault()
        {
            string expectedNum = "";
            Rank expectedRank = Rank.Default;

            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests();

            numer.Init();

            Assert.AreEqual(expectedNum, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }
       
    }
}
