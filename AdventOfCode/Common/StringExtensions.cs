using System.Text.RegularExpressions;

namespace AdventOfCode.Common;

	public static class StringExtensions
	{
        /// <summary>
        /// Replace the first instance of a string inside another string eg "helloqwerty".Replace("e","X") => "hXlloquerty"
        /// </summary>
        /// <param name="text"></param>
        /// <param name="search"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }


        /// <summary>
        /// Reverse a string - eg "abc" becomes "cba"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Reverse( this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Split a mutli-line string into a collection of strings
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<string>SplitToLines(this string text)
        {
            return text.Split(new[] { '\r', '\n' }).Select(s => s.Trim());
        }


        /// <summary>
        /// Extracts a number from text - eg "blue 5" will return 5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int ExtractNumberFromText(this string text)
        {
            var s = Regex.Match(text, @"\d+").Value;
            return int.Parse(s);
        }


        /// <summary>
        /// Detects if the string is an integer
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string text)
        {
            return int.TryParse(text, out _);
        }
    }
