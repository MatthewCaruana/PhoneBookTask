using Moq;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services;
using PhoneBook.Persistence.Repositories;
using PhoneBook.Persistence.Repositories.Interfaces;
using PhoneBook.Test.Mocks.Manager;

namespace PhoneBook.Test.UnitTests
{
    [TestClass]
    public class PersonServicesTest
    {
        private Mock<IPersonRepository> _personRepository;

        public PersonServicesTest()
        {
            _personRepository = new Mock<IPersonRepository>();
        }

        #region Tests

        [TestMethod]
        public void Person_GetAll()
        {
            //arrange
            _personRepository.Setup(x => x.GetAllPersons()).Returns(MockSetupManager.GetListOfPersons());
            PersonServices personService = new PersonServices(_personRepository.Object);

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
            PersonServices personServices = new PersonServices(_personRepository.Object);

            //act
            personServices.AddPerson(person);
            List<PersonDTO> PersonList = personServices.GetAllPersons();

            //assert
            Assert.AreEqual(PersonList.Count(), 1);
            Assert.AreEqual(PersonList[0], person);
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
    }
}