using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.UI
{
    static public class Input
    {
        public const string EMPTY = "You have entered an empty string.";
        public const string EXPECTED_FORMAT = "A positive integer not exceeding nine characters in dimension is expected to be entered.";
        public const string INCORRECT = "Entry data is incorrect: to long number value.";
        public const string ENTERED_LOWER = "You have entered the number: ";
        public const string PLEASE_ENTER = "Please enter a positive integer not exceeding nine characters in dimension.";
        public const string CONTINUE = "Do you want to continue?      Y|y  -  YES,   other  - NO";
        public const string TRY_AGAIN = "Please, try again to enter a number.";
        public const byte MAX_LENGTH = 9;

        public static readonly char[] TRIM_CHARS = new char[]{ ' ', '\t', ',' };

        public static bool ConsoleInputParameter(out uint result, string inviteMessage)
        {
            if (inviteMessage != "")
            {
                Console.WriteLine(inviteMessage);
                Console.WriteLine("{0}{1}",Output.MAX, Output.MAX_VALUE);
            }

            result = 0;

            string input = "";

            Console.WriteLine(EXPECTED_FORMAT);

            bool assigned = false;

            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(EMPTY);
                return false;
            }

            if(input.Length > MAX_LENGTH)
            {
                Console.WriteLine(INCORRECT);
                return false;
            }

            assigned = uint.TryParse(input, out result);

            if (!assigned)
            {
                Console.WriteLine(INCORRECT);
                return false;
            }

            return assigned;
        }

        public static bool ConsoleInputParameter(out string result, string inviteMessage = "")
        {
            if (inviteMessage != "")
            {
                Console.WriteLine(inviteMessage);
            }

            Console.WriteLine(EXPECTED_FORMAT);

            result = string.Empty;

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(EMPTY);
                return false;
            }

            if (input.Length > MAX_LENGTH)
            {
                Console.WriteLine(INCORRECT);
                return false;
            }

            result = input;
            return true;
        }

        public static bool Continue()
        {
            Console.WriteLine(CONTINUE);

            bool contin = false;

            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                return contin;
            }

            input = input.Trim(TRIM_CHARS);

            if(input.ToLower() == "y" || input.ToLower() == "yes")
            {
                contin = true;
            }

            return contin;
        }

        public static void Wait()
        {
            Console.ReadKey();
        }
    }
}
