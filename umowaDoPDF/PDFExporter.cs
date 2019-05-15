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
        public static void SaveAsPDF(string path, string pathDraftPDF, Agreement a)
        {
            PdfDocument AgreementOriginal = PdfReader.Open(pathDraftPDF, PdfDocumentOpenMode.Import);
            PdfDocument newAgreement = new PdfDocument();
            newAgreement.AddPage(AgreementOriginal.Pages[0]);
            AgreementOriginal.Dispose();
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);
            XFont fontBold = new XFont("Calibri", 12, XFontStyle.Bold, options);
            XFont fontRegular = new XFont("Calibri", 12, XFontStyle.Regular, options);
            XGraphics gfx = XGraphics.FromPdfPage(newAgreement.Pages[0]);
            gfx.DrawString(a.FromDateString(), fontBold, new XSolidBrush(XColor.FromName("black")), 83, 133.5);
            gfx.DrawString(" w Jędrzejowie pomiędzy:", fontRegular, new XSolidBrush(XColor.FromName("black")), 148, 133.5);
            gfx.DrawString(a.Client.Name, fontBold, new XSolidBrush(XColor.FromName("black")), 80, 148.2);
            gfx.DrawString(a.Client.Address.ToString(), fontBold, new XSolidBrush(XColor.FromName("black")), 43, 162.7);
            gfx.DrawString(a.Client.IDCardAndPeselString(), fontBold, new XSolidBrush(XColor.FromName("black")), 124, 177.4);
            gfx.DrawString(a.SubjectOfAgreement, fontBold, new XSolidBrush(XColor.FromName("black")), 53.5, 230.5);
            gfx.DrawString(a.PurchasePriceString(), fontBold, new XSolidBrush(XColor.FromName("black")), 264, 245.5);
            gfx.DrawString($"{a.PurchasePriceInWords})", fontRegular, new XSolidBrush(XColor.FromName("black")), 100, 260.15);
            gfx.DrawString(a.ToDateString(), fontBold, new XSolidBrush(XColor.FromName("black")), 322, 350.3);
            gfx.DrawString(a.BuyoutPriceString(), fontBold, new XSolidBrush(XColor.FromName("black")), 348.2, 379.5);
            gfx.DrawString($"{a.BuyoutPriceInWords})", fontRegular, new XSolidBrush(XColor.FromName("black")), 100, 394.2);


            newAgreement.Save(path);
            newAgreement.Dispose();
        }
    }
}
