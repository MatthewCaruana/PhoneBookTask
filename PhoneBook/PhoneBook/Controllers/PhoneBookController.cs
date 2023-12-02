using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services.Interfaces;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("PhoneBook")]
    public class PhoneBookController : ControllerBase
    {
        private readonly ILogger<PhoneBookController> _logger;
        private ICompanyServices _companyServices;

        public PhoneBookController(ILogger<PhoneBookController> logger, ICompanyServices companyServices)
        {
            _logger = logger;
            _companyServices = companyServices;
        }

        [HttpGet(Name ="GetAllCompanies")]
        public List<CompanyDTO> GetAllCompanies()
        {
            List<CompanyDTO> result = _companyServices.GetAllCompanies();
            return result;
        }
    }
}
