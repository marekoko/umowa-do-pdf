using System;

namespace umowaDoPDF
{
    public class Agreement
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Client Client { get; set; }
        public string SubjectOfAgreement { get; set; }
        public decimal BuyingPrice { get; set; }
        public string BuyingPriceInWords { get; set; }
        public decimal SellingPrice { get; set; }
        public string SellingPriceInWords { get; set; }
    }
}
