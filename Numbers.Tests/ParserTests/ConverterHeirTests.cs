using Numbers.Logic;
using Numbers.Parser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Numbers.Tests.ParserTests
{
    public class ConverterHeirTests: Converter
    {
        public ConverterHeirTests()
        {
        }

        public ConverterHeirTests(Numeric numeric)
        :base(numeric)
        {
        }

        public Queue<char> QueueChars
        {
            get
            {
                Queue<char> buf = new Queue<char>(_queueDigits);

                return buf;
            }
        }

        public bool StrNumberToQueueTests()
        {
            return StrNumberToQueue();
        }

        public byte CountResidueOfTriplesDivTests()
        {
            return CountResidueOfTriplesDiv();
        }

        public byte CountQuotientOfTripleDivTests()
        {
            return CountQuotientOfTripleDiv();
        }

        public bool GetResidueStringTests(out string residueLine)
        {
            string residue = string.Empty;
            bool result = GetResidueString(out residue);
            residueLine = residue;

            return result;
        }
    }
}
