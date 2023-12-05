using PhoneBook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Services.Interfaces
{
    public interface IPersonServices
    {
        List<PersonCompanyDTO> GetAllPersons();

        void AddPerson(NewPersonDTO person);

        void EditPerson(EditPersonDTO editedPerson);

        void DeletePerson(int personID);

        PersonCompanyDTO GetWildcard();
        List<PersonCompanyDTO> Search(string keyword);
    }
}
