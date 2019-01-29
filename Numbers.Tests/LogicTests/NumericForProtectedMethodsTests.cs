using Numbers.Logic;
using Numbers.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Numbers.Tests.LogicTests
{
    public class NumericForProtectedMethodsTests: Numeric
    {
        public NumericForProtectedMethodsTests()
        :base()
        {
        }

        public NumericForProtectedMethodsTests(string number)
        :base(number)
        {

        }
        
        public bool ClearOutNumber()
        {
            return base.ClearOutNumber();
        }
    }
}
