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
        public static void MkDir(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show($"Utworzyłem katalog z danymi klientów:\n\"{path}\"");
                Directory.CreateDirectory(path);
            }
        }

        public static void TextBoxPlaceHolderAction(TextBox sender, bool entering, string pHText, string defaultPHText)
        {
            if (entering)
            {
                if (sender.Text == $"{pHText}")
                {
                    defaultPHText = pHText;
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
                    sender.Text = $"{defaultPHText}";
                    sender.ForeColor = Color.Silver;
                }
            }
        }
    }
}
