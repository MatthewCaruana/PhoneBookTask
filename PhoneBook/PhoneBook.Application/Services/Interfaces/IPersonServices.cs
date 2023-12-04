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
        List<PersonDTO> GetAllPersons();

        void AddPerson(PersonDTO person);

        void EditPerson(EditPersonDTO editedPerson);

        void DeletePerson(int personID);

        PersonDTO GetWildcard();
        List<PersonDTO> Search(string keyword);
    }
}
