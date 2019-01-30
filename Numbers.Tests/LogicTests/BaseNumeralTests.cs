using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Numbers.Tests.LogicTests
{
    [TestClass]
    public class BaseNumeralTests
    {
        [TestMethod]
        public void GetRank_Empty_RankDefault()
        {
            string expectedNumber = "";
            Rank expectedRank = Rank.Default;

            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests();
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_ZeroNumber_RankDefault()
        {
            string expectedNumber = "";
            Rank expectedRank = Rank.Default;

            string input = "0";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_SeveralZeroNumber_RankDefault()
        {
            string expectedNumber = "";
            Rank expectedRank = Rank.Default;

            string input = "000";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankUnitNumberWithRightZeros_RankUnit()
        {
            string expectedNumber = "6";
            Rank expectedRank = Rank.Unit;

            string input = "06";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankUnitNumberWithTwoLeftZeros_RankHundred()
        {
            string expectedNumber = "600";
            Rank expectedRank = Rank.Hundred;

            string input = "0600";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankHundredNumberWithMiddleZeros_RankHundred()
        {
            string expectedNumber = "9009";
            Rank expectedRank = Rank.Thousand;

            string input = "9009";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankUnitNumber_RankUnit()
        {
            string expectedNumber = "9";
            Rank expectedRank = Rank.Unit;

            string input = "9";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankTenNumberNTeens_RankTen()
        {
            string expectedNumber = "19";
            Rank expectedRank = Rank.Ten;

            string input = "19";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankTenNumberNTy_RankTen()
        {
            string expectedNumber = "90";
            Rank expectedRank = Rank.Ten;

            string input = "90";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankTenNumber_RankTen()
        {
            string expectedNumber = "99";
            Rank expectedRank = Rank.Ten;

            string input = "99";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        public void GetRank_RankHundredNumber_RankHundred()
        {
            string expectedNumber = "987";
            Rank expectedRank = Rank.Hundred;

            string input = "987";
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();
            Assert.AreEqual(expectedNumber, numer.Number);
            Assert.AreEqual(expectedRank, numer.Rank);
        }

        [TestMethod]
        [DataRow(new string[]{"9876", "98765", "987654"})]
        public void GetRank_RankThousandNumber_RankThousand(string[] inputs)
        {
            Rank[] expectedRanks = new Rank[]{ Rank.Thousand , Rank.Thousand , Rank.Thousand };
            Rank[] actRanks = new Rank[inputs.Length];

            NumericForProtectedMethodsTests[] numers = new NumericForProtectedMethodsTests[]
            {
                new NumericForProtectedMethodsTests(inputs[0]),
                new NumericForProtectedMethodsTests(inputs[1]),
                new NumericForProtectedMethodsTests(inputs[2]),
            };

            for(int i = 0; i < inputs.Length; ++i)
            {
                numers[i].Init();
                actRanks[i] = numers[i].Rank;
            }

            CollectionAssert.AreEqual(expectedRanks, actRanks);
        }

        [TestMethod]
        [DataRow("98760008", Rank.Million)]
        [DataRow("98760089", Rank.Million)]
        [DataRow("9876089", Rank.Million)]
        [DataRow("09876089", Rank.Million)]
        public void GetRank_RankMillionNumber_RankMillion(string input, Rank expectedRank)
        {
            NumericForProtectedMethodsTests numer = new NumericForProtectedMethodsTests(input);
            numer.Init();

            Assert.AreEqual(expectedRank, numer.Rank);
        }
    }
}
