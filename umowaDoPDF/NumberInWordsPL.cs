using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umowaDoPDF
{
    class NumberInWordsPL
    {
        public static String ConvertNumberToWordsPL(String Number)
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
                    String place = "";//digit grouping name:hundres,thousand,etc...    
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
                            pos = (numDigits % 3) + 1;
                            place = " sto ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " tysiąc ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " milion ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " miliard ";
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
                                word = ConvertNumberToWordsPL(Number.Substring(0, pos)) + place + ConvertNumberToWordsPL(Number.Substring(pos));
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
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }


        //private static string Hundreds(string Number)
        //{
        //    string intTensNumber = Convert.ToInt32(Number);
        //    string name = null;
        //    switch (intTensNumber)
        //    {
        //        case 10:
        //            name = "dziesięć";
        //            break;
        //        case 11:
        //            name = "jedenaście";
        //            break;
        //        case 12:
        //            name = "dwanaście";
        //            break;
        //        case 13:
        //            name = "trzynaście";
        //            break;
        //        case 14:
        //            name = "czternaście";
        //            break;
        //        case 15:
        //            name = "piętnaście";
        //            break;
        //        case 16:
        //            name = "szesnaście";
        //            break;
        //        case 17:
        //            name = "siedemnaście";
        //            break;
        //        case 18:
        //            name = "osiemnaście";
        //            break;
        //        case 19:
        //            name = "dziewiętnaście";
        //            break;
        //        case 20:
        //            name = "dwadzieścia";
        //            break;
        //        case 30:
        //            name = "trzydzieści";
        //            break;
        //        case 40:
        //            name = "czterdzieści";
        //            break;
        //        case 50:
        //            name = "pięćdziesiąt";
        //            break;
        //        case 60:
        //            name = "sześćdziesiąt";
        //            break;
        //        case 70:
        //            name = "siedemdziesiąt";
        //            break;
        //        case 80:
        //            name = "osiemdziesiąt";
        //            break;
        //        case 90:
        //            name = "dziewięćdziesiąt";
        //            break;
        //        case 300:
        //            name = "trzysta";
        //            break;
        //        default:
        //            if (intTensNumber > 0)
        //            {
        //                name = Tens(Number.Substring(0, 1) + "0") + " " + Ones(Number.Substring(1));
        //            }
        //            break;
        //    }
        //    return name;
        //}
     

        private static string Ones(string Number)
        {
            int intNumber = Convert.ToInt32(Number);
            string name = "";
            switch (intNumber)
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
    }
}
