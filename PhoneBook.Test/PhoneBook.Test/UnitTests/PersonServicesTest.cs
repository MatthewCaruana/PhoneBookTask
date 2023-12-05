using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services;
using PhoneBook.Application.Services.Interfaces;
using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories;
using PhoneBook.Persistence.Repositories.Interfaces;
using PhoneBook.Test.Mocks;
using PhoneBook.Test.Mocks.Manager;
using PhoneBook.Test.Utils;
using System.Diagnostics;
using System.Net.Sockets;

namespace PhoneBook.Test.UnitTests
{
    [TestClass]
    public class PersonServicesTest
    {
        private IPersonRepository _personRepository;
        private IPhoneBookDbContext _context;
        private IPersonServices _services;

        public PersonServicesTest()
        {
        }

        #region Tests

        [TestMethod]
        public void Person_GetAll()
        {
            //arrange
            SetupDatasets();

            //act
            var result = _services.GetAllPersons();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(MockSetupManager.GetListOfPersons().Count(), result.Count());
        }

        [TestMethod]
        [DynamicData(nameof(GetTestAddEditRemovePersonData), DynamicDataSourceType.Method)]
        public void Person_Add_Edit_Remove(PersonDTO person, EditPersonDTO editedPerson, int removedId)
        {
            //arrange
            SetupDatasets();

            PersonDataModel expectedAddModel = new PersonDataModel()
            {
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                FullAddress = person.FullAddress
            };

            PersonDataModel expectedUpdateModel = new PersonDataModel()
            {
                Id = editedPerson.Id,
                FullName = editedPerson.FullName,
                PhoneNumber = editedPerson.PhoneNumber,
                FullAddress= editedPerson.FullAddress,
                CompanyRef= editedPerson.CompanyRef,
            };

            PersonDataModel expectedRemovalModel = MockSetupManager.GetListOfPersons().FirstOrDefault(x => x.Id == removedId);

            //act
            _services.AddPerson(person);
            _services.EditPerson(editedPerson);
            _services.DeletePerson(removedId);


            //assert
            _context.Person.Received(1).Add(Arg.Any<PersonDataModel>());
            _context.Person.Received(1).Update(Arg.Any<PersonDataModel>());
            _context.Person.Received(1).Remove(Arg.Any<PersonDataModel>());

            _context.Received(3).SaveChanges();

        }

        [TestMethod]
        [DynamicData(nameof(GetTestInputPersonData), DynamicDataSourceType.Method)]
        public void Person_Add(PersonDTO person)
        {
            //arrange
            SetupDatasets();

            PersonDataModel expectedModel = new PersonDataModel()
            {
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                FullAddress = person.FullAddress
            };

            //act
            _services.AddPerson(person);

            //assert
            _context.Person.Received(1).Add(expectedModel);
            _context.Received(1).SaveChanges();
        }

        [TestMethod]
        [DynamicData(nameof(GetTestSearchData), DynamicDataSourceType.Method)]
        public void Person_Search(string keyword, List<int> expectedIds)
        {
            //arrange
            SetupDatasets();

            //act
            var result = _services.Search(keyword);

            //assert
            Assert.AreEqual(expectedIds.Count(), result.Count());
        }

        [TestMethod]
        public void Person_WildCard()
        {
            //arrange
            SetupDatasets();

            //act
            var result = _services.GetWildcard();

            //assert
            Assert.IsNotNull(result);
        }
        #endregion

        #region InputData
        private static IEnumerable<object[]> GetTestInputPersonData()
        {
            yield return new object[]
            {
                new PersonDTO()
                {
                    FullName = "Andrew Stevens",
                    PhoneNumber = "+35679797979",
                    FullAddress = "99, Grand Street, Valletta, Malta"
                }
            };
        }

        private static IEnumerable<object[]> GetTestAddEditRemovePersonData()
        {
            yield return new object[]
            {
                new PersonDTO()
                {
                    FullName = "Andrew Stevens",
                    PhoneNumber = "+35679797979",
                    FullAddress = "99, Grand Street, Valletta, Malta"
                },
                new EditPersonDTO()
                {
                    Id = 1,
                    FullName = "Matthew Caruana",
                    FullAddress = "123456",
                    PhoneNumber = "+35611111111",
                    CompanyRef = 1
                },
                2
            };
        }

        private static IEnumerable<object[]> GetTestSearchData()
        {
            yield return new object[]
            {
                "Malta",
                new List<int>() { 1, 2, 3 }
            };

            yield return new object[]
            {
                "Albert",
                new List<int>() { 2 }
            };

            yield return new object[]
            {
                "11",
                new List<int>() { 1, 2 }
            };
        }

        #endregion

        private void SetupDatasets()
        {
            List<PersonDataModel> personList = MockSetupManager.GetListOfPersons();
            IQueryable<PersonDataModel> persons = personList.AsQueryable();

            DbSet<PersonDataModel> mockedPersons = NSubstituteUtil.CreateMockSet(persons);
            mockedPersons.Add(Arg.Do<PersonDataModel>(x =>
            {
                personList.Add(x);
                persons = personList.AsQueryable();
            }));

            mockedPersons.Remove(Arg.Do<PersonDataModel>(x =>
            {
                personList.Remove(x);
                persons = personList.AsQueryable();
            }));

            mockedPersons.Update(Arg.Do<PersonDataModel>(x =>
            {
                PersonDataModel updatingPerson = personList.FirstOrDefault(y => y.Id == x.Id);
                if(updatingPerson != null)
                {
                    updatingPerson.FullName = x.FullName;
                    updatingPerson.FullAddress = x.FullAddress;
                    updatingPerson.PhoneNumber = x.PhoneNumber;
                    updatingPerson.CompanyRef = x.CompanyRef;
                }
                persons = personList.AsQueryable();
            }));

            _context = Substitute.For<IPhoneBookDbContext>();
            _context.Person.Returns(mockedPersons);

            _personRepository = new PersonRepository(_context);

            _services = new PersonServices(_personRepository);
        }
    }
}