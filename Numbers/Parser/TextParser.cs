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
                return string.Empty;
            }

            string result = "";

            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] >= BaseConverter.ZERO_SIGN && line[i] <= BaseConverter.NINE_SIGN)
                {
                    result += line[i];
                }
            }

            return result;
        }

        public static string StartZerosTrim(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return string.Empty;
            }

            return number.TrimStart(BaseConverter.ZERO_SIGN);
        }

        public static string EndZerosTrim(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return string.Empty;
            }

            return number.TrimEnd('0');
        }

        public static bool IsNumber(this char ch)
        {
            if (ch >= BaseConverter.ZERO_SIGN || ch <= BaseConverter.NINE_SIGN)
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
