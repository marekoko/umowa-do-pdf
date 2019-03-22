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
            XFont fontRegular = new XFont("Calibri", 12, XFontStyle.Regular, options);

            XGraphics gfx = XGraphics.FromPdfPage(newAgreement.Pages[0]);
            gfx.DrawString(a.FromDateString(), fontRegular, new XSolidBrush(XColor.FromName("black")), 83, 133.5);
            gfx.DrawString(a.Client.Name, fontRegular, new XSolidBrush(XColor.FromName("black")), 80, 148.2);
            gfx.DrawString(a.Client.Address.ToString(), fontRegular, new XSolidBrush(XColor.FromName("black")), 43, 162.7);
            gfx.DrawString(a.Client.IDCardAndPeselString(), fontRegular, new XSolidBrush(XColor.FromName("black")), 240, 177.4);
            gfx.DrawString(a.SubjectOfAgreement, fontRegular, new XSolidBrush(XColor.FromName("black")), 53.5, 230.5);
            gfx.DrawString(a.PurchasePriceString(), fontRegular, new XSolidBrush(XColor.FromName("black")), 264, 245.5);
            gfx.DrawString(a.PurchasePriceInWords, fontRegular, new XSolidBrush(XColor.FromName("black")), 100, 260.15);
            gfx.DrawString(a.ToDateString(), fontRegular, new XSolidBrush(XColor.FromName("black")), 321, 350.3);
            gfx.DrawString(a.BuyoutPriceString(), fontRegular, new XSolidBrush(XColor.FromName("black")), 348.2, 379.5);
            gfx.DrawString(a.BuyoutPriceInWords, fontRegular, new XSolidBrush(XColor.FromName("black")), 100, 394.2);


            newAgreement.Save(path);
            newAgreement.Dispose();
        }
    }
}
