using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Models
{
    public class CompanyDataModel
    {
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual List<PersonDataModel> Persons { get; set; }
    }
}
