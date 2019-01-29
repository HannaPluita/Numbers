using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numbers.Logic;

namespace Numbers.Parser
{
    public static class TextParser
    {
        public static string PickOutNumerals(string line)  
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            string result = "";

            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] >= Reader.ZERO_SIGN && line[i] <= Reader.NINE_SIGN)
                {
                    result += line[i];
                }
            }

            return result;
        }

        public static string TrimStartZeros(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return null;
            }

            return number.TrimStart(Reader.ZERO_SIGN);
        }

        public static string TrimEndZero(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return null;
            }

            return number.TrimStart('0');
        }

        public static bool IsNumber(this char ch)
        {
            if (ch >= Reader.ZERO_SIGN || ch <= Reader.NINE_SIGN)
            {
                return true;
            }

            return false;
        }

        public static bool IsUnits(string line)
        {
            if (line.Length == Converter.UNITS_LENGTH)
            {
                return true;
            }

            return false;
        }

        public static bool IsTens(string line)
        {
            if (line.Length == Converter.TENS_LENGTH)
            {
                return true;
            }

            return false;
        }

        public static bool IsHundreds(string line)
        {
            if (line.Length == Converter.HUNDREDS_LENGTH)
            {
                return true;
            }

            return false;
        }

        public static bool IsThousands(string line)
        {
            if ((line.Length <= Converter.THOUSANDS_LENGTH) && (line.Length > Converter.HUNDREDS_LENGTH))
            {
                return true;
            }

            return false;
        }

        public static bool IsMillions(string line)
        {
            if ((line.Length <= Converter.MILLIONS_LENGTH) && (line.Length > Converter.THOUSANDS_LENGTH))
            {
                return true;
            }

            return false;
        }
     
    }
}
