using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Models
{
    public class Company
    {
        public string CompanyName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Company(string companyName, DateTime registrationDate)
        {
            CompanyName = companyName;
            RegistrationDate = registrationDate;
        }
    }
}
