using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services;
using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories;
using PhoneBook.Persistence.Repositories.Interfaces;
using PhoneBook.Test.Mocks;
using PhoneBook.Test.Mocks.Manager;
using PhoneBook.Test.Utils;
using System.Net.Sockets;

namespace PhoneBook.Test.UnitTests
{
    [TestClass]
    public class PersonServicesTest
    {
        private IPersonRepository _personRepository;
        private IPhoneBookDbContext _context;

        public PersonServicesTest()
        {
        }

        #region Tests

        [TestMethod]
        public void Person_GetAll()
        {
            //arrange
            SetupDatasets();
            PersonServices personService = new PersonServices(_personRepository);

            //act
            var result = personService.GetAllPersons();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(MockSetupManager.GetListOfPersons().Count(), result.Count());
        }

        [TestMethod]
        public void Person_Add_Edit_Remove()
        {

        }

        [TestMethod]
        [DynamicData(nameof(GetTestInputPersonData), DynamicDataSourceType.Method)]
        public void Person_Add(PersonDTO person)
        {
            //arrange
            SetupDatasets();
            PersonServices personServices = new PersonServices(_personRepository);
            PersonDataModel expectedModel = new PersonDataModel()
            {
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                FullAddress = person.FullAddress
            };

            //act
            personServices.AddPerson(person);

            //assert
            //_personRepository.Received(1).AddPerson(expectedModel);
            _context.Received(1).Person.Add(expectedModel);
            _context.Received(1).SaveChanges();
        }

        [TestMethod]
        public void Person_Search()
        {

        }

        [TestMethod]
        public void Person_WildCard()
        {

        }
        #endregion

        private static IEnumerable<object[]> GetTestInputPersonData()
        {
            yield return new object[]
            {
                new PersonDTO()
                {
                    FullName = "Andrew Stevens",
                    PhoneNumber = "+35679797979",
                    FullAddress = "99, Grand Street, Valletta, Malta",
                }
            };
        }

        private void SetupDatasets()
        {
            IList<PersonDataModel> personList = MockSetupManager.GetListOfPersons();
            IQueryable<PersonDataModel> persons = personList.AsQueryable();

            DbSet<PersonDataModel> mockedPersons = NSubstituteUtil.CreateMockSet(persons);
            mockedPersons.Add(Arg.Do<PersonDataModel>(x =>
            {
                personList.Add(x);
                persons = personList.AsQueryable();
            }));

            _context = Substitute.For<IPhoneBookDbContext>();
            _context.Person.Returns(mockedPersons);

            _personRepository = new PersonRepository(_context);
        }
    }
}