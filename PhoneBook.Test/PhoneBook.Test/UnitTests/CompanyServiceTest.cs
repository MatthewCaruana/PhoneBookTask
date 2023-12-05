using Microsoft.EntityFrameworkCore;
using NSubstitute;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services;
using PhoneBook.Application.Services.Interfaces;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories;
using PhoneBook.Persistence.Repositories.Interfaces;
using PhoneBook.Test.Mocks;
using PhoneBook.Test.Mocks.Manager;
using PhoneBook.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Test.UnitTests
{
    [TestClass]
    public class CompanyServiceTest
    {
        private ICompanyRepository _companyRepository;
        private ICompanyServices _service;
        private IPhoneBookDbContext _context;

        public CompanyServiceTest() { }

        [TestMethod]
        public void Company_GetAll()
        {
            //arrange
            SetupDatasets();
            List<CompanyDataModel> expectedCompanies = MockSetupManager.GetListOfCompanies();

            //act
            List<CompanyDTO> result = _service.GetAllCompanies();

            //assert
            Assert.AreEqual(expectedCompanies.Count, result.Count);
        }

        private void SetupDatasets()
        {
            List<CompanyDataModel> companiesList = MockSetupManager.GetListOfCompanies();
            IQueryable<CompanyDataModel> company = companiesList.AsQueryable();

            DbSet<CompanyDataModel> mockedCompanies = NSubstituteUtil.CreateMockSet(company);
            mockedCompanies.Add(Arg.Do<CompanyDataModel>(x =>
            {
                companiesList.Add(x);
                company = companiesList.AsQueryable();
            }));

            mockedCompanies.Remove(Arg.Do<CompanyDataModel>(x =>
            {
                companiesList.Remove(x);
                company = companiesList.AsQueryable();
            }));

            mockedCompanies.Update(Arg.Do<CompanyDataModel>(x =>
            {
                CompanyDataModel updatingCompany = companiesList.FirstOrDefault(y => y.ID == x.ID);
                if (updatingCompany != null)
                {
                    updatingCompany.CompanyName = x.CompanyName;
                    updatingCompany.RegistrationDate = x.RegistrationDate;
                }
                company = companiesList.AsQueryable();
            }));

            _context = Substitute.For<IPhoneBookDbContext>();
            _context.Company.Returns(mockedCompanies);

            _companyRepository = new CompanyRepository(_context);

            _service = new CompanyServices(_companyRepository);
        }

    }
}
