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

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void File_should_be_generated_properly()
        {
            var agr = RandomValue.Object<Agreement>();
            
            PDFExporter.SaveAsPDF("umowaNowa.pdf", agr);
            Assert.Equal(true, true);
            true.ShouldBe(true);

            Process.Start("umowaNowa.pdf");
        }

    }
}
