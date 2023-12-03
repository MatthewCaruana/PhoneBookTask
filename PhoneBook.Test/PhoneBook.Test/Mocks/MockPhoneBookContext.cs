using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Test.Mocks
{
    public class MockPhoneBookContext : IPhoneBookDbContext
    {
        private IEnumerable<PersonDataModel> CreateEmptyPersonDataModel()
        {
            return new List<PersonDataModel>();
        }

        private IEnumerable<CompanyDataModel> CreateEmptyCompanyDataModel()
        {
            return new List<CompanyDataModel>();
        }
    }
}
