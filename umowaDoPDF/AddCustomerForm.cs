using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace umowaDoPDF
{
    public partial class AddCustomerForm : Form
    {

        private readonly string clientsDir = Directory.GetCurrentDirectory() + "\\Clients";
        private Dictionary<string, string> TextBoxesDefaults = null;
        public AddCustomerForm()
        {
            InitializeComponent();
            TextBoxesDefaults = ToolsAndStuff.MakeTextBoxesDictionary(this.Controls);
            var today = DateTime.Now;
            dtpFrom.Value = today;
            dtpTo.Value = today.AddDays(30);
            GetClientsToComboBox();
        }

        public void GetClientsToComboBox()
        {
            cBoxClientsList.Items.Clear();

            ToolsAndStuff.MkDir(clientsDir);
            string[] txtClientFiles = Directory.GetFiles(clientsDir);
            foreach (string filePath in txtClientFiles) cBoxClientsList.Items.Add(Path.GetFileNameWithoutExtension(filePath));

        }

        private void bGeneratePDF_Click(object sender, EventArgs e)
        {
            var a = new Agreement();
            a.FromDate = dtpFrom.Value;
            a.ToDate = dtpTo.Value;
            a.PurchasePrice = nudPurchasePrice.Value;
            a.BuyoutPrice = nudBuyoutPrice.Value;
            a.PurchasePriceInWords = tPurchasePriceInWords.Text;
            a.BuyoutPriceInWords = tBuyoutPriceInWords.Text;
            a.SubjectOfAgreement = tSubjectOfAgreemnt.Text;
            a.Client = new Client();
            a.Client.IDCard = tIDCard.Text;
            a.Client.Name = tName.Text;
            a.Client.Pesel = tPesel.Text;
            var address = a.Client.Address = new Address();
            address.City = tCity.Text;
            address.Street = tStreet.Text;
            address.ZipCode = tZipCode.Text;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Filter = "PDF|*.pdf";
            sfd.FileName = $"Umowa Lombardowa {DateTime.Now:ddMMyyyy}";
            var dr = sfd.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }



            PDFExporter.SaveAsPDF(sfd.FileName, a);

            MessageBox.Show("Zapisano PDF!");

            Process.Start(sfd.FileName);

        }

        private void bSaveData_Click(object sender, EventArgs e)
        {
            string path = "dane.txt";
            var a = new Agreement();
            a.FromDate = dtpFrom.Value;
            a.ToDate = dtpTo.Value;
            a.PurchasePrice = nudPurchasePrice.Value;
            a.BuyoutPrice = nudBuyoutPrice.Value;
            a.PurchasePriceInWords = tPurchasePriceInWords.Text;
            a.BuyoutPriceInWords = tBuyoutPriceInWords.Text;
            a.SubjectOfAgreement = tSubjectOfAgreemnt.Text;
            a.Client = new Client();
            a.Client.IDCard = tIDCard.Text;
            a.Client.Name = tName.Text;
            a.Client.Pesel = tPesel.Text;
            var address = a.Client.Address = new Address();
            address.City = tCity.Text;
            address.Street = tStreet.Text;
            address.ZipCode = tZipCode.Text;
            var line = $@"
{a.FromDate:dd.MM.yyyy}
{a.Client.Name} {a.Client.Address.ToString()}
{a.PurchasePrice.ToString("0.00")}
{a.SubjectOfAgreement}
{a.Client.IDCard}
{a.Client.Pesel}
{a.BuyoutPrice.ToString("0.00")}
{a.ToDate:dd.MM.yyyy}";
            using (TextWriter tw = new StreamWriter(path, true))
            {
                tw.WriteLine(line);
                MessageBox.Show("Zapisano do pliku txt");
                try {Process.Start("notepad++.exe", "dane.txt");}
                catch {Process.Start("dane.txt");}
            }
        }

        private void BSaveClient_Click(object sender, EventArgs e)
        {
            var a = new Agreement();
            a.FromDate = dtpFrom.Value;
            a.ToDate = dtpTo.Value;
            a.PurchasePrice = nudPurchasePrice.Value;
            a.BuyoutPrice = nudBuyoutPrice.Value;
            a.PurchasePriceInWords = tPurchasePriceInWords.Text;
            a.BuyoutPriceInWords = tBuyoutPriceInWords.Text;
            a.SubjectOfAgreement = tSubjectOfAgreemnt.Text;
            a.Client = new Client();
            a.Client.IDCard = tIDCard.Text;
            a.Client.Name = tName.Text;
            a.Client.Pesel = tPesel.Text;
            var address = a.Client.Address = new Address();
            address.City = tCity.Text;
            address.Street = tStreet.Text;
            address.ZipCode = tZipCode.Text;

            //string clientsPath = $"{Directory.GetCurrentDirectory()}\\Clients\\";
            string clientTextFile = $"{a.Client.Name}_{a.Client.Pesel}.txt";
            string clientData = $@"
{a.Client.FirstNameOnly()}
{a.Client.LastNameOnly()}
{a.Client.Address.ZipCode}
{a.Client.Address.City}
{a.Client.Address.Street}
{a.Client.IDCard}
{a.Client.Pesel}";
            ToolsAndStuff.MkDir(clientsDir);

            using (TextWriter tw = new StreamWriter($"{clientsDir}\\{clientTextFile}", false))
            {
                tw.WriteLine(clientData);
                MessageBox.Show("Zapisano klienta w bazie");
                //Process.Start($"{clientsDir}\\{clientTextFile}");
            }
        }

        private void CBoxClientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxClientsList.SelectedItem = cBoxClientsList.Text;
        }

        private void CBoxClientsList_DropDown(object sender, EventArgs e)
        {
            GetClientsToComboBox();

        }

        private void BChooseClientFromCBox_Click(object sender, EventArgs e)
        {
            if(cBoxClientsList.Text == "")
            {
                Console.WriteLine("Błont");
                MessageBox.Show("Wybierz klienta z listy");
            }
            else
            {
                string[] linesTxtClient = File.ReadAllLines($"{clientsDir}\\{cBoxClientsList.Text}.txt", Encoding.UTF8);
                Console.WriteLine(linesTxtClient.Count());
                foreach (string clientData in linesTxtClient)
                {
                    Console.WriteLine(clientData);
                }
                
                tName.Text = $"{linesTxtClient[1]} {linesTxtClient[2]}";
                tName.ForeColor = Color.Black;

                tZipCode.Text = linesTxtClient[3];
                tZipCode.ForeColor = Color.Black;

                tCity.Text = linesTxtClient[4];
                tCity.ForeColor = Color.Black;

                tStreet.Text = linesTxtClient[5];
                tStreet.ForeColor = Color.Black;

                tIDCard.Text = linesTxtClient[6];
                tIDCard.ForeColor = Color.Black;

                tPesel.Text = linesTxtClient[7];
                tPesel.ForeColor = Color.Black;

            }

        }

        private void TName_Enter(object sender, EventArgs e)
        {

            //Process.Start(@"c:\users\marek\source\repos\numbertowords\numbertowords\bin\debug\numbertowords.exe");
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox) sender, true, TextBoxesDefaults);
        }

        private void TName_Leave(object sender, EventArgs e)
        {
            
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox) sender, false, TextBoxesDefaults);

        }

        private void TZipCode_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TZipCode_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TCity_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TCity_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TStreet_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TStreet_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TIDCard_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TIDCard_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TPesel_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TPesel_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TSubjectOfAgreemnt_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TSubjectOfAgreemnt_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TPurchasePriceInWords_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TPurchasePriceInWords_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }

        private void TBuyoutPriceInWords_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, TextBoxesDefaults);

        }

        private void TBuyoutPriceInWords_Leave(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);

        }// <-------------------------------- Placeholder things

        private void NudPurchasePrice_ValueChanged(object sender, EventArgs e)
        {
            decimal nudPurchaseValue = nudPurchasePrice.Value;
            string niwPL = NumberInWordsPL.ConvertNumberToWordsPL(nudPurchaseValue.ToString());
            tPurchasePriceInWords.ForeColor = Color.Black;
            tPurchasePriceInWords.Text = niwPL;
        }

        private void NudBuyoutPrice_ValueChanged(object sender, EventArgs e)
        {
            decimal nudBuyoutPriceValue = nudBuyoutPrice.Value;
            string niwPL = NumberInWordsPL.ConvertNumberToWordsPL(nudBuyoutPriceValue.ToString());
            tBuyoutPriceInWords.ForeColor = Color.Black;
            tBuyoutPriceInWords.Text = niwPL;
        }
    }
}
