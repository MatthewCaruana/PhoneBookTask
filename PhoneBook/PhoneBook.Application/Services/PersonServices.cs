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
        public List<PersonCompanyDTO> GetAllPersons()
        {
            List<PersonCompanyDTO> personDTOs = new List<PersonCompanyDTO>();

            List<PersonDataModel> personsDMs = _repository.GetAllPersons();

            foreach (PersonDataModel person in personsDMs)
            {
                personDTOs.Add(ConvertToPersonCompanyDTO(person));
            }

            return personDTOs;
        }

        public void AddPerson(NewPersonDTO person)
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
                _repository.SaveChanges();
            }
        }

        public PersonCompanyDTO GetWildcard()
        {
            PersonDataModel person = _repository.GetWildcard();

            return ConvertToPersonCompanyDTO(person);
        }

        public List<PersonCompanyDTO> Search(string keyword)
        {
            List<PersonCompanyDTO> personDTOs = new List<PersonCompanyDTO>();

            List<PersonDataModel> persons = _repository.Search(keyword);

            foreach (PersonDataModel person in persons)
            {
                personDTOs.Add(ConvertToPersonCompanyDTO(person));
            }

            return personDTOs;
        }
        #endregion


        #region Private Functions
        private PersonCompanyDTO ConvertToPersonCompanyDTO(PersonDataModel model)
        {
            PersonCompanyDTO result = new PersonCompanyDTO();

            result.FullName = model.FullName;
            result.PhoneNumber = model.PhoneNumber;
            result.FullAddress = model.FullAddress;
            result.Company = ConvertToCompanyDTO(model.Company);

            return result;
        }

        private PersonDataModel ConvertToDataModel(NewPersonDTO dto)
        {
            PersonDataModel result = new PersonDataModel();

            result.FullName = dto.FullName;
            result.PhoneNumber = dto.PhoneNumber;
            result.FullAddress = dto.FullAddress;
            result.CompanyRef = dto.CompanyRef;

            return result;
        }

        private CompanyDTO ConvertToCompanyDTO(CompanyDataModel model)
        {
            CompanyDTO result = new CompanyDTO();

            result.CompanyName = model.CompanyName;
            result.RegistrationDate = model.RegistrationDate;
            result.LinkedPersons = model.Persons.Count();

            return result;
        }
        #endregion


    }
}
