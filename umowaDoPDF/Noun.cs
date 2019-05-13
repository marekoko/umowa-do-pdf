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
            

            public static string ZlotyOnlyOne { get; set; } = "złoty";
            public static string Zloty234 { get; set; } = "złote";
            public static string Zloty567 { get; set; } = "złotych";
        }
        public class Thousand
        {
            public static string ThousandOnlyOne { get; set; } = "tysiąc";
            public static string Thousand234 { get; set; } = "tysiące";
            public static string Thousand567 { get; set; } = "tysięcy";
        }
    }

}
