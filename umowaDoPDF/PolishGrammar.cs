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
            /*
             * Poniższa zasada działa w przypadku odmiany wszystkich rzeczowników przy licznikach.
            Pierwszy liczebnik to jedyny wyjątek przy liczbie "1" i słowie "złoty".
            Dla liczb z zakresu 5–14 lub gdy ostatnia cyfra liczby wynosi 1, 5, 6, 7, 8, 9, 0 
            mówi i pisze się „złotych” (np. 18 złotych, 85 złotych). Te liczby łączą się z dopełniaczem. 
            Ostatnia cyfra 2, 3, 4 – mówi i pisze się „złote” (np. 42 złote, 104 złote). Liczby te z kolei 
            podaje się w formie mianownika.
             TRANSLATED TO ENGLISH:
             The following rule works in the case of a variety of all nouns at counters(numerals).
            The first numeral is the only exception to the number "1" and the word "złoty".
            For numbers in the range 5-14 or when the last digit of the number is 1, 5, 6, 7, 8, 9, 0
            says and writes „złotych”(eg 18 złotych, 85 złotych).These numbers connect to the complement.
            The last digit 2, 3, 4 - says and "gold" is written(eg 42 złote, 104 złote). These numbers in turn
            is given in the form of a nominative.
            */
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
