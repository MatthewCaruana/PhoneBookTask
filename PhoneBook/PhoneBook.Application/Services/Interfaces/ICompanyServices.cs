using PhoneBook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Services.Interfaces
{
    public interface ICompanyServices
    {
        List<CompanyDTO> GetAllCompanies(); 
        void AddCompany(CompanyDTO company);
    }
}
