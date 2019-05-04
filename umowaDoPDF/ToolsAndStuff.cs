using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace umowaDoPDF
{
    class ToolsAndStuff
    {   
        
        public static Dictionary<string, string> MakeTextBoxesDictionary(Control.ControlCollection controls)
        //
        // Take out all checkboxes and text from it into dictionary:
        //
        {
            Dictionary<string, string> TextBoxDict = new Dictionary<string, string>();

            foreach (var item in controls)
            {
                var collectionItem = item as TextBox;
                if (collectionItem != null)
                {
                    TextBoxDict.Add(collectionItem.Name, collectionItem.Text);
                    Console.WriteLine(collectionItem.Text);
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

        public static void MkDir(string path)
        //
        // Making directory in designated path with messagebox info
        //
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show($"Utworzyłem katalog z danymi klientów:\n\"{path}\"");
                Directory.CreateDirectory(path);
            }
        }

        public static void TextBoxPlaceHolderAction(TextBox sender, bool entering, Dictionary<string, string> defaultTextBoxNames)
        {

            if (entering)
            {
                if (sender.Text == $"{defaultTextBoxNames[$"{sender.Name}"]}")
                {
                    Console.WriteLine("Entering");
                    sender.Text = "";
                    sender.ForeColor = Color.Black;
                }
            }
            else
            {
                if (sender.Text == "")
                {
                    Console.WriteLine("NOT_Entering");

                    //private System.Windows.Forms.TextBox tName;
                    
                    sender.Text = $"{defaultTextBoxNames[$"{sender.Name}"]}";
                    sender.ForeColor = Color.Silver;
                }
            }
        }
    }
}
