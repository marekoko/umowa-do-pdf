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
        // todo: add button to manage clientlist
        // todo: add button to manage SubjectsOfAgreements Source list
        // todo: make clientlist manager
        // todo: make SubjectsOfAgreements Source list manager
        

        private readonly string ClientsDir = Path.Combine(Directory.GetCurrentDirectory(), "Clients");
        private readonly string DataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        private readonly string PDFdraftsDir = Path.Combine(Directory.GetCurrentDirectory(), "PDFdrafts");
        private readonly string AgreementDraftFile = "Agreement_Draft.pdf";
        private readonly string SOASourceDir = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SOA");
        private readonly string SOASourceFile = "SubjectsOfAgreements.txt";

        private Dictionary<string, string> TextBoxesDefaults = null;
        private List<string> ClientList = new List<string>();
        private List<string> SOAList = new List<string>();

        public AddCustomerForm()
        {
            InitializeComponent();
            InitializeAppDirs();
            ClientListUpdateSource();
            SOAUpdateListSource();

            TextBoxesDefaults = ToolsAndStuff.MakeTextBoxesDictionary(this.Controls);
            var today = DateTime.Now;
            dtpFrom.Value = today;
            dtpTo.Value = today.AddMonths(1);
        }
        private void InitializeAppDirs()
        {
            ToolsAndStuff.MkDir(ClientsDir, null);
            ToolsAndStuff.MkDir(DataDir, null);
            ToolsAndStuff.MkDir(PDFdraftsDir, null);
            ToolsAndStuff.MkDir(SOASourceDir, null);
        }
        private void SOAUpdateListSource()
        {
            SOAList.Clear();

            string SOAFullPath = Path.Combine(SOASourceDir, SOASourceFile);
            string Message = $"Brak pliku źródłowego: \"SubjectsOfAgreements.txt\"\n " +
                $"Stworzyłem go ścieżce: {Path.Combine(SOASourceDir, SOASourceFile)}";

            ToolsAndStuff.MkFile(SOAFullPath, Message);
            string[] linesSOASourceFile = File.ReadAllLines(Path.Combine(SOASourceDir, SOASourceFile), Encoding.UTF8);
            //Console.WriteLine(linesSOASourceFile.Count());
            if (linesSOASourceFile != null)
            {
                foreach (string SOA in linesSOASourceFile)
                {
                    //Console.WriteLine(SOA);
                    tSubjectOfAgreemnt.AutoCompleteCustomSource.Add(SOA);

                }
            }
        }
        private void SOAAddNew(string SOA)
        {
            IEnumerable<string> SOASourceList = tSubjectOfAgreemnt.AutoCompleteCustomSource.Cast<string>();

            if (!SOASourceList.Any(x => x.ToLower().Trim() == SOA.ToLower().Trim()))
            {
                //if didnt find SOA in AutocompleteList then adds it to SOAListSourceFile and refreshes the AutocompleteList

                using (TextWriter tw = new StreamWriter(Path.Combine(SOASourceDir, SOASourceFile), true)) //add SOA to file
                {
                    tw.WriteLine($"{SOA}");
                }
                Console.WriteLine($"SOA:\"{SOA}\" dodany do AutoCompleteList"); // refresh autocomplete list

                SOAUpdateListSource();
                
            }
            else
            {
                Console.WriteLine("SOA jest już na liście\nNie dodaję do listy");
            }
            
        }
        public void ClientListUpdateSource()
        {
            cBoxClientsList.Items.Clear();
            tName.AutoCompleteCustomSource.Clear();
            ClientList.Clear();

            string[] txtClientFiles = Directory.GetFiles(ClientsDir);
            foreach (string filePath in txtClientFiles)
            {
                cBoxClientsList.Items.Add(Path.GetFileNameWithoutExtension(filePath));
                tName.AutoCompleteCustomSource.Add(Path.GetFileNameWithoutExtension(filePath));
                ClientList.Add(Path.GetFileNameWithoutExtension(filePath));
            }

                    //    // todo: titolowe czary mary objectcollection do stringa
                    //    var x = cBoxClientsList.Items;
                    //    foreach (var c in x)
                    //    {
                    //        var element = (string)c;
                    //        var element2 = c.ToString();
                    //    }

                    //    var list = x.Cast<string>();
                    //    TwojaStara("");
                    //    TwojaStara(1);
                    //}
                    //void TwojaStara<t>(t x)
                    //{
                    //    // todo: titolowe czary mary - metoda generyczna - zależy od rodzaju zmiennej
                    //    if(x.GetType() == typeof(int))
                    //    {
                    //        Console.WriteLine(x.GetType());
                    //    }
        }
        public void SaveDataToTextFile(Agreement a)
        {
            {
                // todo: get rid of that bSaveData_Click button, and make savings to txt while generating pdfs

                //var a = new Agreement();
                a.FromDate = dtpFrom.Value;

                string TxtFile = $"dane_{a.FromDate:dd.MM.yyyy}.txt";
                string TxtFilePath = Path.Combine(DataDir, TxtFile);

                a.ToDate = dtpTo.Value;
                a.PurchasePrice = nudPurchasePrice.Value;
                a.BuyoutPrice = nudBuyoutPrice.Value;
                a.PurchasePriceInWords = tPurchasePriceInWords.Text;
                a.BuyoutPriceInWords = tBuyoutPriceInWords.Text;
                a.SubjectOfAgreement = tSubjectOfAgreemnt.Text;
                //a.Client = new Client();
                a.Client.IDCard = tIDCard.Text;
                a.Client.Name = tName.Text;
                a.Client.Pesel = tPesel.Text;
                var address = a.Client.Address;
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
                using (TextWriter tw = new StreamWriter(TxtFilePath, true))
                {
                    tw.WriteLine(line);
                    //MessageBox.Show("Zapisano do pliku txt");
                    //try { Process.Start("notepad++.exe", TxtFilePath); }
                    //catch { Process.Start(TxtFilePath); }
                }
            }
        }
        private void bGeneratePDF_Click(object sender, EventArgs e)
        {
            string PathDraft = Path.Combine(PDFdraftsDir, AgreementDraftFile);

            Agreement a = new Agreement();
            a.FromDate = dtpFrom.Value;
            a.ToDate = dtpTo.Value;
            a.PurchasePrice = nudPurchasePrice.Value;
            a.BuyoutPrice = nudBuyoutPrice.Value;
            a.PurchasePriceInWords = tPurchasePriceInWords.Text;
            a.BuyoutPriceInWords = tBuyoutPriceInWords.Text;
            a.SubjectOfAgreement = tSubjectOfAgreemnt.Text;

            SOAAddNew(a.SubjectOfAgreement);

            a.Client = new Client();
            a.Client.IDCard = tIDCard.Text;
            a.Client.Name = tName.Text;
            a.Client.Pesel = tPesel.Text;

            int checkName = ToolsAndStuff.CheckNameAndLastNameFormat(a.Client.Name);
            Console.WriteLine(checkName);

            Address address = a.Client.Address = new Address();
            address.City = tCity.Text;
            address.Street = tStreet.Text;
            address.ZipCode = tZipCode.Text;

            if (checkName == 1)
            {
                if (File.Exists(PathDraft))
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    sfd.Filter = "PDF|*.pdf";
                    sfd.FileName = $"Umowa_Lombardowa_{DateTime.Now:ddMMyyyy}_{a.Client.FirstNameOnly()}_{a.Client.LastNameOnly()}";

                    if (!cBoxSaveOnDesktop.Checked)
                    {
                        DialogResult dr = sfd.ShowDialog();
                        if (dr == DialogResult.Cancel)
                        {

                        }
                        PDFExporter.SaveAsPDF(sfd.FileName, PathDraft, a);
                        MessageBox.Show($"Zapisano plik *.pdf w ścieżce:\n{sfd.FileName}");
                        Process.Start(sfd.FileName);
                    }
                    else
                    {
                        string DefaultFileName = $"{sfd.FileName}.pdf";
                        string defaultPath = Path.Combine(sfd.InitialDirectory, DefaultFileName);

                        int count = 1;
                        while (File.Exists(defaultPath))
                        {
                            DefaultFileName = $"{sfd.FileName}_{count++}.pdf";
                            if (!File.Exists(Path.Combine(sfd.InitialDirectory, DefaultFileName)))
                            {
                                defaultPath = Path.Combine(sfd.InitialDirectory, DefaultFileName);
                                break;
                            }
                        }
                        PDFExporter.SaveAsPDF(defaultPath, PathDraft, a);
                        MessageBox.Show($"Zapisano plik *.pdf w ścieżce:\n{defaultPath}");
                        Process.Start(defaultPath);
                    }
                }
                else
                {
                    MessageBox.Show($"Brak szablonu pliku \"{AgreementDraftFile}\" w ścieżce: \"{PDFdraftsDir}\"! \n\nBez szablonu nie można \nwygenerować nowego dokumentu");
                }
                SaveDataToTextFile(a); 
            }
            else if (checkName == -1)
            {
                MessageBox.Show("In TextBox tName field=null");
            }
            else if (checkName == 999)
            {
                MessageBox.Show("Niedozwolony znak (\"<>_:\" /\\|?*\") w polu z imieniem i nazwiskiem");
            }
            else
            {
                MessageBox.Show("Żle wpisane imię i nazwisko!");
            }
        }
        private void BSaveClient_Click(object sender, EventArgs e)
        {
            // check if text in textbox is a default text, if so messagebox appear, if not saving client process starts
            if (tName.Text == $"{TextBoxesDefaults[tName.Name]}" || string.IsNullOrWhiteSpace(tName.Text))
            {
                MessageBox.Show("Wpisz Imię i Nazwisko klienta");
                ;
            }
            else
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

                using (TextWriter tw = new StreamWriter($"{ClientsDir}\\{clientTextFile}", false))
                {
                    tw.WriteLine(clientData);
                    MessageBox.Show("Zapisano klienta w bazie");
                    //Process.Start($"{clientsDir}\\{clientTextFile}");
                }
                ClientListUpdateSource();
            }
        }

        private void CBoxClientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxClientsList.SelectedItem = cBoxClientsList.Text;
        }

        private void BChooseClientFromCBox_Click(object sender, EventArgs e)
        {
            if (cBoxClientsList.Text == "")
            {
                Console.WriteLine("Error - client not chosen from list");
                MessageBox.Show("Wybierz klienta z listy");
            }
            else
            {
                string[] linesTxtClient = File.ReadAllLines(Path.Combine(ClientsDir, $"{cBoxClientsList.Text}.txt"), Encoding.UTF8);

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
            // wyłączony aby sprawdzić czy działa metoda dodająca zachowanie dla wszystich textboxow
            //ToolsAndStuff.TextBoxPlaceHolderAction((TextBox) sender, true, TextBoxesDefaults);
        }

        private void TName_Leave(object sender, EventArgs e)
        {

            ToolsAndStuff.TextBoxPlaceHolderAction((TextBox)sender, false, TextBoxesDefaults);
        }

        private void TName_KeyDown(object sender, KeyEventArgs e)
        {
            // if the key pressed is Enter:
            if (e.KeyCode == Keys.Return)
            {
                if (ClientList.Any(x => x.ToLower() == tName.Text.ToLower()))
                {
                    string[] linesTxtClient = File.ReadAllLines($"{ClientsDir}\\{tName.Text}.txt", Encoding.UTF8);

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
            string niwPL = NumberInWordsPL.ConvertNumberToWordsPL(nudPurchaseValue.ToString("0"));
            string zlotyFormPurchase = PolishGrammar.NounsWithNumeralsVariety(nudPurchaseValue.ToString("0"), Noun.Zloty.ZlotyWithNumeralsDict);
            tPurchasePriceInWords.ForeColor = Color.Black;
            tPurchasePriceInWords.Text = $"{niwPL} {zlotyFormPurchase}";


        }

        private void NudBuyoutPrice_ValueChanged(object sender, EventArgs e)
        {
            decimal nudBuyoutPriceValue = nudBuyoutPrice.Value;
            string niwPL = NumberInWordsPL.ConvertNumberToWordsPL(nudBuyoutPriceValue.ToString("0"));
            string zlotyFormBuyout = PolishGrammar.NounsWithNumeralsVariety(nudBuyoutPriceValue.ToString("0"), Noun.Zloty.ZlotyWithNumeralsDict);
            tBuyoutPriceInWords.ForeColor = Color.Black;
            tBuyoutPriceInWords.Text = $"{niwPL} {zlotyFormBuyout}";
        }

        private void bAddOneDay_Click(object sender, EventArgs e)
        {
            dtpTo.Value = dtpTo.Value.AddDays(1);
        }

        private void bAddOneWeek_Click(object sender, EventArgs e)
        {
            dtpTo.Value = dtpTo.Value.AddDays(7);
        }

        private void bAddOneMonth_Click(object sender, EventArgs e)
        {
            dtpTo.Value = dtpTo.Value.AddMonths(1);
        }
        private void bSubtractOneDay_Click(object sender, EventArgs e)
        {
            dtpTo.Value = dtpTo.Value.AddDays(-1);
        }

        private void bSubtractOneWeek_Click(object sender, EventArgs e)
        {
            dtpTo.Value = dtpTo.Value.AddDays(-7);
        }

        private void bSubtractOneMonth_Click(object sender, EventArgs e)
        {
            dtpTo.Value = dtpTo.Value.AddMonths(-1);
        }

        private void BFromDateMakeToday_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today;
        }

        private void BToDateMakeToday_Click(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Today;
        }

    }
}
