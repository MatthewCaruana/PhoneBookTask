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

        public CompanyServices(ICompanyRepository repository) 
        { 
            _repository = repository;
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            List<CompanyDTO> companyDTOs = new List<CompanyDTO>();

            List<CompanyDataModel> companiesDMs = _repository.GetAllCompanies().ToList();

            foreach(CompanyDataModel company in companiesDMs)
            {
                companyDTOs.Add(ConvertToDTO(company));
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
    }
}
