using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umowaDoPDF
{
    class Noun
    {
        public class Zloty
        {
            private static Dictionary<short, string> zlotyWithNumeralsDict = new Dictionary<short, string>
            {
                {1, "złoty" },
                {234, "złote" },
                {567, "złotych" }
            };

            public static Dictionary<short, string> ZlotyWithNumeralsDict { get => zlotyWithNumeralsDict; set => zlotyWithNumeralsDict = value; }
        }
        public class Thousand
        {
            private static Dictionary<short, string> thousandWithNumeralsDict = new Dictionary<short, string>
            {
                {1, "tysiąc" },
                {234, "tysiące" },
                {567, "tysięcy" }
            };

            public static Dictionary<short, string> ThousandWithNumeralsDict { get => thousandWithNumeralsDict; set => thousandWithNumeralsDict = value; }
        }
        public class Million
        {
            private static Dictionary<short, string> millionWithNumeralsDict = new Dictionary<short, string>
            {
                {1, "milion" },
                {234, "miliony" },
                {567, "milionów" }
            };

            public static Dictionary<short, string> MillionWithNumeralsDict { get => millionWithNumeralsDict; set => millionWithNumeralsDict = value; }
        }
    }

}
