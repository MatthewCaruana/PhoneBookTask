﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Services.Interfaces;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private ICompanyServices _companyServices;

        public CompanyController(ILogger<CompanyController> logger, ICompanyServices companyServices)
        {
            _logger = logger;
            _companyServices = companyServices;
        }

        [HttpGet]
        [Route("GetCompanies")]
        public List<CompanyDTO> GetCompanies()
        {
            List<CompanyDTO> result = _companyServices.GetAllCompanies();
            return result;
        }

        [HttpPost]
        [Route("AddCompany")]
        public void AddCompany(CompanyDTO company)
        {
            _companyServices.AddCompany(company);
        }
    }
}
