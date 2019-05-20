using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace umowaDoPDF
{
    class ToolsAndStuff
    {   
        
        public static Dictionary<string, string> MakeTextBoxesDictionary(Control.ControlCollection controls)
        //
        // Take out all checkboxes and text from this form and put it into dictionary:
        //
        {
            Dictionary<string, string> TextBoxDict = new Dictionary<string, string>();

            foreach (var item in controls)
            {
                var collectionItem = item as TextBox;
                if (collectionItem != null)
                {
                    TextBoxDict.Add(collectionItem.Name, collectionItem.Text);
                    //check the list in console:
                    //Console.WriteLine(collectionItem.Text);

                }
                // todo: titolowe czary mary - wrzuca przy wejsciu do textboxow akcje placeholder
            }
            foreach (var item in controls)
            {
                var collectionItem = item as TextBox;
                if (collectionItem != null)
                {
                    collectionItem.Enter += (sender, args) =>
                    {
                        TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxDict);
                    };
                }

            }
            ////
            //// testing for printing key-value pairs:
            ////
            //foreach(KeyValuePair<string, string> entry in TextBoxDict)
            //{
            //    Console.WriteLine(entry.Key + " - " + entry.Value);
            //}

            return TextBoxDict;
        }

        public static void MkDir(string path, string infoMessage)
        //
        // Making directory in designated path with messagebox info
        //
        {
            if (!Directory.Exists(path))
            {

                if (infoMessage == null || infoMessage == "")
                {
                    infoMessage = $"Utworzyłem katalog w ścieżce:\n\"{path}\"";
                }
                Directory.CreateDirectory(path);
                MessageBox.Show(infoMessage);
            }
        }
        public static void MkFile(string path, string infoMessage)
        //
        // Make file in designated path
        //
        {

            if (!File.Exists(path))
            {
                if (infoMessage == null || infoMessage == "")
                {
                    infoMessage = $"Utworzyłem plik w ścieżce:\n\"{path}\"";
                }

                // todo: działa jak "File.Create(path);" ale zamyka plik
                MessageBox.Show(infoMessage);
                using (File.Create(path))
                {
                
                }
                
            }
        }
        public static void TextBoxPlaceHolderAction(TextBox sender, bool entering, Dictionary<string, string> defaultTextBoxNames)
        //
        // Makes names of textboxes if they are empty
        //
        {

            if (entering)
            {
                if (sender.Text == $"{defaultTextBoxNames[$"{sender.Name}"]}")
                {
                    //Console.WriteLine("Entering");
                    sender.Text = "";
                    sender.ForeColor = Color.Black;
                }
            }
            else
            {
                if (sender.Text == "")
                {
                    //Console.WriteLine("NOT_Entering");

                    //private System.Windows.Forms.TextBox tName;
                    
                    sender.Text = $"{defaultTextBoxNames[$"{sender.Name}"]}";
                    sender.ForeColor = Color.Silver;
                }
            }
        }
        public static int CheckNameAndLastNameFormat(string textboxString)
        //
        //Checks if there are two words in string in right format:
        //returns 1 if there are two words and they are not whitespace,
        //returns 0 if two words but one of them is whitespace,
        //returns 0 if not two words,
        //returns -1 if there is problem with data (string entered is null)
        //returns 999 if there is invalid character in string
        {
            if (textboxString != null)
            {
                //"<>_:"/\|?*"
                Regex r = new Regex("[<>_:\"/\\|?*]");
                if (r.IsMatch(textboxString))
                {
                    return 999;
                }

                string[] textboxSubstrings = textboxString.Split(' ');
                
                // counting words
                int count = textboxSubstrings.Count();

                if (count == 2)
                {
                    if(textboxSubstrings.Any(x => string.IsNullOrWhiteSpace(x)))
                    {
                        return 888;
                    }
                    //foreach (string text in textboxSubstrings)
                    //{
                    //    if (string.IsNullOrWhiteSpace(text))
                    //    {
                            
                    //    }
                    //}

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
