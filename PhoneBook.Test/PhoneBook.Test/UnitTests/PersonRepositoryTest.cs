using Moq;
using PhoneBook.Application.Services;
using PhoneBook.Persistence.Repositories;
using PhoneBook.Persistence.Repositories.Interfaces;
using PhoneBook.Test.Mocks.Manager;

namespace PhoneBook.Test.UnitTests
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private Mock<IPersonRepository> _personRepository;

        public PersonRepositoryTest()
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
        public void Person_Add()
        {

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

        private void SetupMockPhoneBookContext()
        {

        }
    }
}