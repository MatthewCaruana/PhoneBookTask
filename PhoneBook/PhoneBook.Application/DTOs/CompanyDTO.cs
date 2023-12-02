using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; }
        public DateTime RegistrationDate { get; set; }  
        public int LinkedPersons { get; set; }
    }
}
