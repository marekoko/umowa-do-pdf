using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umowaDoPDF;
using Xunit;
using RandomTestValues;
using System.Diagnostics;
using System.IO;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void File_should_be_generated_properly()
        {
            var agr = RandomValue.Object<Agreement>();
            
            PDFExporter.SaveAsPDF("umowaNowa.pdf", ".", agr);
            Assert.Equal(true, true);
            true.ShouldBe(true);

            Process.Start("umowaNowa.pdf");
        }

        [Fact]
        public void String_should_be_proper()
        {
            string path = "dane.txt";
            var a = new Agreement();
            //var line = $@"{a.FromDateString()} {a.Client.Name} {a.Client.Address.ToString()} {a.PurchasePriceString()} 
            //                {a.SubjectOfAgreement} {a.BuyoutPriceString()} {a.ToDateString()}";
            var line = $"{a.BuyoutPrice}";
            using (TextWriter tw = new StreamWriter(path, true))
            {
                tw.WriteLine(line);
                Process.Start("dane.txt");
            }
        }
    }
}
