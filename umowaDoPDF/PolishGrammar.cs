using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umowaDoPDF
{
    class PolishGrammar
    {
        public static string NounsWithNumeralsVariety(string Number, Dictionary<short, string> NounsWithNumeralsDict)
        {
            string NounCorrectForm = "";
            int intNumber = Convert.ToInt32(Number);

            List<int> ListFor1 = new List<int>() { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            List<int> ListFor567 = new List<int>() { 0, 1, 5, 6, 7, 8, 9 };
            List<int> ListFor234 = new List<int>() { 2, 3, 4 };

            if (intNumber == 1 && Number.Trim().Length == 1)
            {
                NounCorrectForm = NounsWithNumeralsDict[1];
            }
            else if (ListFor1.Any(x => x == intNumber) || ListFor567.Any(x => x == intNumber % 10))
            {
                NounCorrectForm = NounsWithNumeralsDict[567];
            }
            else if (ListFor234.Any(x => x == intNumber % 10))
            {
                NounCorrectForm = NounsWithNumeralsDict[234];
            }
            return NounCorrectForm;
        }
    }
}
