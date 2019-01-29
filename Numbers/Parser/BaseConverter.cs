using System;
using System.Collections.Generic;
using Numbers.Logic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Parser
{
    public class BaseConverter
    {
        #region    Constants
        public const byte UNITS_RANGE_IN_TRINITY = 2;

        public const char NTEENS_SIGN = '1';
        public const char ZERO_SIGN = '0';
        public const char NINE_SIGN = '9';
        public const char EMPTY_SPACE = ' ';
        #endregion

        public static readonly IReadOnlyDictionary<char, string> Units = new Dictionary<char, string>
        {
            { '1', "one" },
            { '2', "two"},
            { '3', "three"},
            { '4', "four"},
            { '5', "five"},
            { '6', "six"},
            { '7', "seven"},
            { '8', "eight"},
            { '9', "nine"},
        };
        public static readonly IReadOnlyDictionary<string, string> Nteens = new Dictionary<string, string>
        {
            { "11", "eleven" },
            { "12", "twelve"},
            { "13", "thirteen"},
            { "14", "fourteen"},
            { "15", "fifteen"},
            { "16", "sixteen"},
            { "17", "seventeen"},
            { "18", "eighteen"},
            { "19", "nineteen"},
        };
        public static readonly IReadOnlyDictionary<char, string> Tens = new Dictionary<char, string>
        {
            { '1', "ten" },
            { '2', "twenty"},
            { '3', "thirty"},
            { '4', "forty"},
            { '5', "fifty"},
            { '6', "sixty"},
            { '7', "seventy"},
            { '8', "eighty"},
            { '9', "ninety"},
        };
        public static readonly IReadOnlyDictionary<string, string> Ranges = new Dictionary<string, string>
        {
            { "1", "hundred" },
            { "2", "thousand"},
            { "3", "million"}
        };

        protected Queue<string> _wordExpression = new Queue<string>();

        protected bool ReadUnits(char digit)
        {
            if(digit == ZERO_SIGN)
            {
                return false;
            }

            _wordExpression.Enqueue(Units[digit]);
            _wordExpression.Enqueue(EMPTY_SPACE.ToString());

            return true;

        }

        protected bool ReadTens(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return false;
            }

            string trimmedStr = TextParser.StartZerosTrim(digits);

            if (string.IsNullOrEmpty(trimmedStr))
            {
                return false;
            }

            if (trimmedStr.Length > Converter.TENS_LENGTH)
            {
                return false;
            }

             if (trimmedStr.Length == Converter.UNITS_LENGTH)
            {
                ReadUnits(trimmedStr[0]);

                return true;
            }

            if ((trimmedStr[0] == NTEENS_SIGN) && (trimmedStr[1] != ZERO_SIGN))
            {
                _wordExpression.Enqueue(Nteens[trimmedStr]);
                _wordExpression.Enqueue(EMPTY_SPACE.ToString());

                return true;
            }

            if (trimmedStr[1] == ZERO_SIGN)
            {
                _wordExpression.Enqueue(Tens[trimmedStr[0]]);
                _wordExpression.Enqueue(EMPTY_SPACE.ToString());

                return true;
            }

            _wordExpression.Enqueue(Tens[trimmedStr[0]]);
            _wordExpression.Enqueue(EMPTY_SPACE.ToString());

            ReadUnits(trimmedStr[1]);
           
            return true;
        }

        protected bool ReadHundreds(char digit)
        {
            if(digit == ZERO_SIGN || !digit.IsNumber())
            {
                return false;
            }
            
            ReadUnits(digit);

            _wordExpression.Enqueue((Rank.Hundred.ToString()).ToLower());
            _wordExpression.Enqueue(EMPTY_SPACE.ToString());

            return true;
        }

        protected bool ReadTripleOfDigits(string digits, Rank rank = Rank.Default)   
        {
            if (string.IsNullOrEmpty(digits))
            {
                return false;
            }

            string trimmedStr = TextParser.StartZerosTrim(digits);

            if (string.IsNullOrEmpty(trimmedStr))
            {
                return false;
            }
        
            if (trimmedStr.Length > Converter.HUNDREDS_LENGTH)
            {
                return false;
            }

            if (trimmedStr.Length == Converter.UNITS_LENGTH && trimmedStr[0].IsNumber())
            {
                ReadUnits(trimmedStr[0]);
                TextRank(rank);

                return true;
            }

            if (trimmedStr.Length == Converter.TENS_LENGTH)
            {
                ReadTens(trimmedStr);
                TextRank(rank);

                return true;
            }

            if ((TextParser.EndZerosTrim(trimmedStr)).Length == 1 && trimmedStr[0].IsNumber())
            {
                ReadHundreds(trimmedStr[0]);
                TextRank(rank);

                return true;
            }
            
            ReadHundreds(trimmedStr[0]);
            ReadTens(trimmedStr.Substring(1));
            TextRank(rank);

            return true;
        }

        private bool TextRank(Rank rank)
        {
            if (rank == Rank.Million || rank == Rank.Thousand)
            {
                _wordExpression.Enqueue(rank.ToString().ToLower());
                _wordExpression.Enqueue(EMPTY_SPACE.ToString());

                return true;
            }

            return false;
        }
    }
}
