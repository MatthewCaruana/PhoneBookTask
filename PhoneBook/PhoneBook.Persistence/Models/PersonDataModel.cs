using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Models
{
    public class PersonDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyRef { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }

        public virtual CompanyDataModel Company { get; set; }
    }
}
