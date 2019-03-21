using System;

namespace umowaDoPDF
{
    public class Agreement
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Client Client { get; set; }
        public string SubjectOfAgreement { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchasePriceInWords { get; set; }
        public decimal BuyoutPrice { get; set; }
        public string BuyoutPriceInWords { get; set; }

    }
}
