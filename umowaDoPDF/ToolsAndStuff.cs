using System;
using System.Collections.Generic;
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
            };
        }
    }
}
