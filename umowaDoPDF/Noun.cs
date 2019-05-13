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
            public static Dictionary<short, string> ZlotyWithNumeralsDict = new Dictionary<short, string>
            {
                {1, "złoty" },
                {234, "złote" },
                {567, "złotych" }
            };
        }
        public class Thousand
        {
            public static Dictionary<short, string> ThousandWithNumeralsDict = new Dictionary<short, string>
            {
                {1, "tysiąc" },
                {234, "tysiące" },
                {567, "tysięcy" }
            };

        }public class Million
        {
            public static Dictionary<short, string> MillionWithNumeralsDict = new Dictionary<short, string>
            {
                {1, "milion" },
                {234, "miliony" },
                {567, "milionów" }
            };

        }
    }

}
