using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services.Interfaces;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Services
{
    public class CompanyServices : ICompanyServices
    {
        private ICompanyRepository _repository;
        private IPersonRepository _personRepository;

        public CompanyServices(ICompanyRepository repository, IPersonRepository personRepository) 
        { 
            _repository = repository;
            _personRepository = personRepository;
        }

        public void AddCompany(CompanyDTO company)
        {
            _repository.AddCompany(ConvertToDataModel(company));
            _repository.SaveChanges();
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            List<CompanyDTO> companyDTOs = new List<CompanyDTO>();

            List<CompanyDataModel> companiesDMs = _repository.GetAllCompanies().ToList();

            foreach(CompanyDataModel company in companiesDMs)
            {
                CompanyDTO companyDTO = ConvertToDTO(company);
                companyDTO.LinkedPersons = _personRepository.GetLinkedPersons(company.ID);
                companyDTOs.Add(companyDTO);
            }

            return companyDTOs;
        }

        private CompanyDTO ConvertToDTO(CompanyDataModel model)
        {
            CompanyDTO result = new CompanyDTO();

            result.CompanyName = model.CompanyName;
            result.RegistrationDate = model.RegistrationDate;
            if(model.Persons != null)
            {
                result.LinkedPersons = model.Persons.Count();
            }
            else
            {
                result.LinkedPersons = 0;
            }

            return result;
        }

        private CompanyDataModel ConvertToDataModel(CompanyDTO model)
        {
            CompanyDataModel result = new CompanyDataModel();
            result.CompanyName = model.CompanyName;
            result.RegistrationDate = model.RegistrationDate;
            return result;
        }
    }
}
