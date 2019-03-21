using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umowaDoPDF
{
    public static class PDFExporter
    {
        public static void SaveAsPDF(string path, Agreement a)
        {
            PdfDocument AgreementOriginal = PdfReader.Open("umowa.pdf", PdfDocumentOpenMode.Import);
            PdfDocument newAgreement = new PdfDocument();
            newAgreement.AddPage(AgreementOriginal.Pages[0]);
            AgreementOriginal.Dispose();
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);
            XFont font = new XFont("Calibri", 12, XFontStyle.Regular, options);

            XGraphics gfx = XGraphics.FromPdfPage(newAgreement.Pages[0]);
            gfx.DrawString(a.FromDateString(), font, new XSolidBrush(XColor.FromName("black")), 83, 133.5);
            gfx.DrawString(a.Client.Name, font, new XSolidBrush(XColor.FromName("black")), 80, 148.5);
            gfx.DrawString(a.Client.Address.ToString(), font, new XSolidBrush(XColor.FromName("black")), 43, 162.5);
            gfx.DrawString(a.Client.IDCardAndPeselString(), font, new XSolidBrush(XColor.FromName("black")), 240, 176.5);
            gfx.DrawString(a.SubjectOfAgreement, font, new XSolidBrush(XColor.FromName("black")), 60, 225.5);
            gfx.DrawString(a.PurchasePriceString(), font, new XSolidBrush(XColor.FromName("black")), 250, 252);
            gfx.DrawString(a.PurchasePriceInWords, font, new XSolidBrush(XColor.FromName("black")), 100, 266);

            newAgreement.Save(path);
            newAgreement.Dispose();
        }
    }
}
