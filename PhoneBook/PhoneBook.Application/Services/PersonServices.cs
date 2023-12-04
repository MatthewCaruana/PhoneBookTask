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

        #region Interface Implementations
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

        public void AddPerson(PersonDTO person)
        { 
            _repository.AddPerson(ConvertToDataModel(person));
            _repository.SaveChanges();
        }

        public void EditPerson(EditPersonDTO editedPerson)
        {
            PersonDataModel person = _repository.FindById(editedPerson.Id);

            if(person != null)
            {
                person.FullName = editedPerson.FullName;
                person.PhoneNumber = editedPerson.PhoneNumber;
                person.FullAddress = editedPerson.FullAddress;
                person.CompanyRef = editedPerson.CompanyRef;

                _repository.UpdatePerson(person);
                _repository.SaveChanges();
            }
        }

        public void DeletePerson(int personID)
        {
            PersonDataModel person = _repository.FindById(personID);
            if(person != null)
            {
                _repository.RemovePerson(person);
            }
        }
        #endregion


        #region Private Functions
        private PersonDTO ConvertToDTO(PersonDataModel model)
        {
            PersonDTO result = new PersonDTO();

            result.FullName = model.FullName;
            result.PhoneNumber = model.PhoneNumber;
            result.FullAddress = model.FullAddress;

            return result;
        }

        private PersonDataModel ConvertToDataModel(PersonDTO dto)
        {
            PersonDataModel result = new PersonDataModel();

            result.FullName = dto.FullName;
            result.PhoneNumber = dto.PhoneNumber;
            result.FullAddress = dto.FullAddress;

            return result;
        }


        #endregion

        
    }
}
