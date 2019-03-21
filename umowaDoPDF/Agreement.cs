using System;

namespace umowaDoPDF
{
    public class Agreement
    {
        public DateTime FromDate { get; set; }
        public DateTime To { get; set; }
        public Client Client { get; set; }
        public string SubjectOfAgreement { get; set; }
        public decimal PurchasePrice { private get; set; }
        public string PurchasePriceInWords { get; set; }
        public decimal BuyoutPrice { get; set; }
        public string BuyoutPriceInWords { get; set; }

        public string PurchasePriceString()
        {
            return $"{this.PurchasePrice} zł";
        }
        public string FromDateString()
        {
            return $"{this.FromDate.ToString("dd-MM-yyyy")} r. w Jędrzejowie pomiędzy:";
        }
    }
    
}
