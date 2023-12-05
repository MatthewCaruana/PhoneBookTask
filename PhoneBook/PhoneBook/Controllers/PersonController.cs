using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services.Interfaces;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonServices _personServices;

        public PersonController(ILogger<PersonController> logger, IPersonServices personServices)
        {
            _logger = logger;
            _personServices = personServices;
        }

        [HttpGet]
        [Route("GetAllPersons")]
        public List<PersonDTO> GetAllPersons()
        {
            List<PersonDTO> result = _personServices.GetAllPersons();
            return result;
        }

        [HttpPost]
        [Route("AddPerson")]
        public void AddPerson(PersonDTO person)
        {
            _personServices.AddPerson(person);
        }

        [HttpGet]
        [Route("SearchByKeyword")]
        public List<PersonDTO> SearchByKeyword(string keyword)
        {
            List<PersonDTO> result = _personServices.Search(keyword);
            return result;
        }

        [HttpPut]
        [Route("EditPerson")]
        public void EditPerson(EditPersonDTO editPersonDTO)
        {
            _personServices.EditPerson(editPersonDTO);
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public void DeletePerson(int id)
        {
            _personServices.DeletePerson(id);
        }

        [HttpGet]
        public PersonDTO GetWildcard()
        {
            return _personServices.GetWildcard();
        }
    }
}
