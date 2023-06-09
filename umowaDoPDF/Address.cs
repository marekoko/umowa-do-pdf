﻿namespace umowaDoPDF
{
    public class Address
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{ZipCode} {City}, {Street}";
        }
    }
}
