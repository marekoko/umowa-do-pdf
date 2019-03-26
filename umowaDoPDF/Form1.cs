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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var today = DateTime.Now;
            dtpFrom.Value = today;
            dtpTo.Value = today.AddDays(30);
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
{decimal.Round(a.PurchasePrice, 2, MidpointRounding.AwayFromZero)}
{a.SubjectOfAgreement}
{a.BuyoutPrice}
{a.ToDateString()}";
            using (TextWriter tw = new StreamWriter(path, true))
            {
                tw.WriteLine(line);
                MessageBox.Show("Zapisano do pliku txt");
                try {Process.Start("notepad++.exe", "dane.txt");}
                catch {Process.Start("dane.txt");}
            }
        }
    }
}
