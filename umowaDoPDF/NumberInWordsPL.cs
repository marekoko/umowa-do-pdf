using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umowaDoPDF
{
    class NumberInWordsPL
    {
        public static string ConvertNumberToWordsPL(string Number)
        {
            string word = "";

            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    string placeName = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = Ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = Tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            word = Hundreds(Number);
                            isDone = true;
                            //pos = (numDigits % 3) + 1; //Old code
                            //place = " sto ";  //Old code
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            //placeName = " tysiąc ";
                            //Number = Convert.ToInt32(Number);
                            dblAmt = dblAmt / 1000;
                            placeName = $" {PolishGrammar.NounsWithNumeralsVariety(dblAmt.ToString("0"), Noun.Thousand.ThousandWithNumeralsDict)} ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            //placeName = " milion ";
                            dblAmt = dblAmt / 1000000;
                            placeName = $" {PolishGrammar.NounsWithNumeralsVariety(dblAmt.ToString("0"), Noun.Million.MillionWithNumeralsDict)} ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            placeName = " miliard ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertNumberToWordsPL(Number.Substring(0, pos)) + placeName + ConvertNumberToWordsPL(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertNumberToWordsPL(Number.Substring(0, pos)) + ConvertNumberToWordsPL(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    //if (word.Trim().Equals(place.Trim())) word = "asdasdasd";
                }
            }
            catch { }
            //Console.WriteLine("asd" + "\"" + word + "\"" + "asdasd");
            return word.Trim();
        }

        //public static string ZlotyVariety(string Number)
        //{
        //    /*
        //     * Poniższa zasada działa w przypadku odmiany wszystkich rzeczowników przy licznikach.
        //    Pierwszy liczebnik to jedyny wyjątek przy liczbie "1" i słowie "złoty".
        //    Dla liczb z zakresu 5–14 lub gdy ostatnia cyfra liczby wynosi 1, 5, 6, 7, 8, 9, 0 
        //    mówi i pisze się „złotych” (np. 18 złotych, 85 złotych). Te liczby łączą się z dopełniaczem. 
        //    Ostatnia cyfra 2, 3, 4 – mówi i pisze się „złote” (np. 42 złote, 104 złote). Liczby te z kolei 
        //    podaje się w formie mianownika.
        //     TRANSLATED TO ENGLISH:
        //     The following rule works in the case of a variety of all nouns at counters(numerals).
        //    The first numeral is the only exception to the number "1" and the word "złoty".
        //    For numbers in the range 5-14 or when the last digit of the number is 1, 5, 6, 7, 8, 9, 0
        //    says and writes „złotych”(eg 18 złotych, 85 złotych).These numbers connect to the complement.
        //    The last digit 2, 3, 4 - says and "gold" is written(eg 42 złote, 104 złote). These numbers in turn
        //    is given in the form of a nominative.
        //    */
        //    string ZlotyCorrectForm = "";
        //    int intNumber = Convert.ToInt32(Number);
            
        //    List<int> listZlotych = new List<int>() { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        //    List<int> listZlotychLastDigit = new List<int>() { 0, 1, 5, 6, 7, 8, 9 };
        //    List<int> listZloteLastDigit = new List<int>() { 2, 3, 4 };

        //    if (intNumber == 1 && Number.Trim().Length == 1)
        //    {
        //        ZlotyCorrectForm = "złoty";
        //    }
        //    else if (listZlotych.Any(x => x == intNumber) || listZlotychLastDigit.Any(x => x == intNumber % 10))
        //    {
        //        ZlotyCorrectForm = "złotych";
        //    }
        //    else if (listZloteLastDigit.Any(x => x == intNumber % 10))
        //    {
        //        ZlotyCorrectForm = "złote";
        //    }
        //    return ZlotyCorrectForm;
        //}


        private static string Ones(string Number)
        {
            int intOnesNumber = Convert.ToInt32(Number);
            string name = null;
            switch (intOnesNumber)
            {

                case 1:
                    name = "jeden";
                    break;
                case 2:
                    name = "dwa";
                    break;
                case 3:
                    name = "trzy";
                    break;
                case 4:
                    name = "cztery";
                    break;
                case 5:
                    name = "pięć";
                    break;
                case 6:
                    name = "sześć";
                    break;
                case 7:
                    name = "siedem";
                    break;
                case 8:
                    name = "osiem";
                    break;
                case 9:
                    name = "dziewięć";
                    break;
            }
            return name;
        }
        private static string Tens(string Number)
        {
            int intTensNumber = Convert.ToInt32(Number);
            string name = null;
            switch (intTensNumber)
            {
                case 10:
                    name = "dziesięć";
                    break;
                case 11:
                    name = "jedenaście";
                    break;
                case 12:
                    name = "dwanaście";
                    break;
                case 13:
                    name = "trzynaście";
                    break;
                case 14:
                    name = "czternaście";
                    break;
                case 15:
                    name = "piętnaście";
                    break;
                case 16:
                    name = "szesnaście";
                    break;
                case 17:
                    name = "siedemnaście";
                    break;
                case 18:
                    name = "osiemnaście";
                    break;
                case 19:
                    name = "dziewiętnaście";
                    break;
                case 20:
                    name = "dwadzieścia";
                    break;
                case 30:
                    name = "trzydzieści";
                    break;
                case 40:
                    name = "czterdzieści";
                    break;
                case 50:
                    name = "pięćdziesiąt";
                    break;
                case 60:
                    name = "sześćdziesiąt";
                    break;
                case 70:
                    name = "siedemdziesiąt";
                    break;
                case 80:
                    name = "osiemdziesiąt";
                    break;
                case 90:
                    name = "dziewięćdziesiąt";
                    break;
                default:
                    if (intTensNumber > 0)
                    {
                        name = Tens(Number.Substring(0, 1) + "0") + " " + Ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static string Hundreds(string Number)
        {
            int intHundredsNumber = Convert.ToInt32(Number);
            Console.WriteLine(Number);
            Console.WriteLine(intHundredsNumber);
            //return "sto jeden";
            string name = null;
            switch (intHundredsNumber)
            {
                case 100:
                    name = "sto";
                    break;
                case 200:
                    name = "dwieście";
                    break;
                case 300:
                    name = "trzysta";
                    break;
                case 400:
                    name = "czterysta";
                    break;
                case 500:
                    name = "pięćset";
                    break;
                case 600:
                    name = "sześćset";
                    break;
                case 700:
                    name = "siedemset";
                    break;
                case 800:
                    name = "osiemset";
                    break;
                case 900:
                    name = "dziewięćset";
                    break;
                default:
                    if (intHundredsNumber > 0)
                    {
                        name = Hundreds(Number.Substring(0, 1) + "00") + " " + Tens(Number.Substring(1, 1) + "0") + " " + Ones(Number.Substring(2));
                    }
                    break;
            }
            return name;
        }
    }
}
