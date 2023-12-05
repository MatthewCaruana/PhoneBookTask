using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Models
{
    public class CompanyDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual List<PersonDataModel> Persons { get; set; }
    }
}
