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

        public AddCustomerForm()
        {
            InitializeComponent();
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
                tZipCode.Text = linesTxtClient[3];
                tCity.Text = linesTxtClient[4];
                tStreet.Text = linesTxtClient[5];
                tIDCard.Text = linesTxtClient[6];
                tPesel.Text = linesTxtClient[7];
            }

        }

        private void TName_Enter(object sender, EventArgs e)
        {
            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, true, " -- Wpisz Imię i Nazwisko --");
        }
    }
}
