using System.Collections.Generic;
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
            return $"dowodem osobistym nr: {IDCard} , nr PESEL: {Pesel} ,"; 
        }
        public string FirstNameOnly()
        {
            return Name.Split(' ')[0];
        }
        public string LastNameOnly()
        {
            return Name.Split(' ')[1];
        }
    }
}
