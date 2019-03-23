﻿using System;

namespace umowaDoPDF
{
    public class Agreement
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Client Client { get; set; }
        public string SubjectOfAgreement { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchasePriceInWords { get; set; }
        public decimal BuyoutPrice { get; set; }
        public string BuyoutPriceInWords { get; set; }

        public string PurchasePriceString()
        {
            return $"{this.PurchasePrice} zł";
        }
        public string BuyoutPriceString()
        {
            return $"{this.BuyoutPrice} zł";
        }
        public string FromDateString()
        {
            return $"{this.FromDate.ToString("dd-MM-yyyy")} r. w Jędrzejowie pomiędzy:";
        }
        public string ToDateString()
        {
            return $"{this.ToDate.ToString("dd-MM-yyyy")}.";
        }
    }
    
}
