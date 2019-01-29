using Numbers.Parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.UI
{
    public static class Output
    {
        #region    Constants
        public const string NOT_UINT = "Your have entered a string of not positive integer numeric format.";
        public const string TRY_AGAIN_WITH_RESTART = "Please, restart the application with entry data as parameter.";
        public const string EMPTY_ARGS = @"The argument line of the application's call is empty.";

        public const string TITLE = "============= Number: =============";
        public const string NUMERIC = "Numeric value in digits";
        public const string VERBAL = "Verbal expression of numeric value";
        public const string FINISH_LINE = "============================================";
        public const string MIDDLE_LINE = "--------------------------------------------";

        public const string FORMAT_REQUIREMENTS = "The input number must be an integer non-negative format.";
        public const string MAX = "Maximum allowable value is ";
        public const string MAX_VALUE = "999999999";
        public const string FINISH_APP = "Application completed.";

        #endregion

        public static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputMessageSet(params string[] strings)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in strings)
            {
                sb.Append(s);
            }

            Console.WriteLine(sb.ToString());
        }

        public static void OutputNumberToConsole(IPrintable view)
        {
            Console.WriteLine(TITLE);
            Console.WriteLine(string.Format("{0}: {1}", NUMERIC, view.NumberInDigits));
            Console.WriteLine(string.Format("{0}; {1}", VERBAL, view.WordExpression));
            Console.WriteLine(FINISH_LINE);
        }

        public static void OutputInstructions()
        {
            string path = @"..\..\Resources\Info.txt";

            try
            {
                if (File.Exists(path))
                {
                    string[] info = File.ReadAllLines(path);

                    foreach (string str in info)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                e.Data.Add("File Path:", path);
                e.Data.Add("File Operation:", "Try to read all lines.");

                Console.WriteLine(e.Message);
                foreach (DictionaryEntry entry in e.Data)
                {
                    Console.WriteLine(string.Format("{0} {1}", entry.Key, entry.Value));
                }
            }

        }

        public static void CorrectFormatInfo()
        {
            Console.WriteLine(FORMAT_REQUIREMENTS);
            Console.WriteLine(String.Concat(MAX, MAX_VALUE));
        }
    }
}
