using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services.Interfaces;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Services
{
    public class PersonServices : IPersonServices
    {
        private IPersonRepository _repository;

        public PersonServices(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<PersonDTO> GetAllPersons()
        {
            List<PersonDTO> personDTOs = new List<PersonDTO>();

            List<PersonDataModel> personsDMs = _repository.GetAllPersons().ToList();

            foreach (PersonDataModel person in personsDMs)
            {
                personDTOs.Add(ConvertToDTO(person));
            }

            return personDTOs;
        }

        private PersonDTO ConvertToDTO(PersonDataModel model)
        {
            PersonDTO result = new PersonDTO();

            result.FullName = model.FullName;
            result.PhoneNumber = model.PhoneNumber;
            result.FullAddress = model.FullAddress;

            return result;
        }
    }
}
