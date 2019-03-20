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
            XFont font = new XFont("Calibri", 11, XFontStyle.Regular, options);

            XGraphics gfx = XGraphics.FromPdfPage(newAgreement.Pages[0]);
            gfx.DrawString(a.From.ToString("dd-MM-yyyy"), font, new XSolidBrush(XColor.FromName("black")), 140, 130);
            gfx.DrawString(a.Client.Name, font, new XSolidBrush(XColor.FromName("black")), 140, 145);
            gfx.DrawString(a.Client.Address.ToString(), font, new XSolidBrush(XColor.FromName("black")), 140, 160);
            gfx.DrawString(a.Client.IDCard, font, new XSolidBrush(XColor.FromName("black")), 300, 175);
            gfx.DrawString(a.Client.Pesel, font, new XSolidBrush(XColor.FromName("black")), 400, 175);
            


            newAgreement.Save(path);
            newAgreement.Dispose();
        }
    }
}
