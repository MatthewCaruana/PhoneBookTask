using PhoneBook.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        List<PersonDataModel> GetAllPersons();
        void AddPerson(PersonDataModel person);
        void SaveChanges();
        PersonDataModel FindById(int id);
        void UpdatePerson(PersonDataModel person);
        void RemovePerson(PersonDataModel person);
        PersonDataModel GetWildcard();
        List<PersonDataModel> Search(string keyword);
    }
}
