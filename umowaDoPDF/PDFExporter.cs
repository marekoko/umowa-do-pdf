using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

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
            XFont prodNameFont = new XFont("Times New Roman", 9, XFontStyle.Regular, options);

            XGraphics gfx = XGraphics.FromPdfPage(newAgreement.Pages[0]);
            gfx.DrawString(a.From.ToString("dd"));




            newAgreement.Save(path);
            newAgreement.Dispose();
        }
    }
}
