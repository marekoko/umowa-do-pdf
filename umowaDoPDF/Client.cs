﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umowaDoPDF
{
    public class Client
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string IDCard { get; set; }
        public string Pesel { get; set; }

        public string IDCardAndPeselString()
        {
            return $": {IDCard} , nr PESEL: {Pesel} ,"; 
        }
    }
}
