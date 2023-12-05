using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs
{
    public class PersonCompanyDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
