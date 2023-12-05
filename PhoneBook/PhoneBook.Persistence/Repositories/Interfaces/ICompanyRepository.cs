using PhoneBook.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<CompanyDataModel> GetAllCompanies();
        void AddCompany(CompanyDataModel company);
        void SaveChanges();
    }
}
