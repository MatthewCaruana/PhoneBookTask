﻿using Microsoft.EntityFrameworkCore;
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

        [TestMethod]
        [DynamicData(nameof(GetTestAddData), DynamicDataSourceType.Method)]
        public void Company_Add(CompanyDTO company)
        {
            //arrange
            SetupDatasets();

            CompanyDataModel expectedDataModel = new CompanyDataModel()
            {
                CompanyName = company.CompanyName,
                RegistrationDate = company.RegistrationDate,
            };

            //act
            _service.AddCompany(company);

            //assert
            _context.Company.Received(1).Add(Arg.Any<CompanyDataModel>());
            _context.Received(1).SaveChanges();
        }

        private static IEnumerable<object[]> GetTestAddData()
        {
            yield return new object[]
            {
                new CompanyDTO()
                {
                    CompanyName = "New Company",
                    RegistrationDate = DateTime.Today
                }
            };
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

            _context = Substitute.For<IPhoneBookDbContext>();
            _context.Company.Returns(mockedCompanies);

            _companyRepository = new CompanyRepository(_context);

            _service = new CompanyServices(_companyRepository);
        }

    }
}
