using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numbers.Logic;
using Numbers.UI;

namespace Numbers.Parser
{
    public class NumberReader: IReadable
    {
        public string IS_EMPTY = "There is no data to process.";
        private string _number;
        private Converter _converter;

        public NumberReader()
        :this("")
        {
        }

        public NumberReader(string number)
        {
            _number = number;
        }

        public NumberReader(NumberReader reader)
        :this(reader._number)
        {
        }

        public string NumberInDigits
        {
            get { return _converter.NumberInDigits; }
        }

        public string NumberInWords
        {
            get { return _converter.NumberInWords; }
        }

        public bool IsEmpty
        {
            get { return string.IsNullOrEmpty(_number); }
        }

        public bool OutputNumberToConsole()
        {
            return _converter.OutputNumberToConsole(); ;
        }

        public bool Read()
        {
            if (string.IsNullOrEmpty(_number))
            {
                Output.OutputMessage(IS_EMPTY);
                return false;
            }

            Numeric numer = new Numeric(_number);
            numer.Init();

            if (numer.IsEmpty)
            {
                Output.OutputMessage(Output.EMPTY_ARGS);
                return false;
            }

            IConvertable iconvert = numer as IConvertable;
            _converter = new Converter(iconvert);

            if (_converter.Init())
            {
                return _converter.Read();
            }

            return false;
        }
    }
}
