﻿using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
using PhoneBook.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private IPhoneBookDbContext _context;

        public CompanyRepository(IPhoneBookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CompanyDataModel> GetAllCompanies()
        {
            return _context.Company.ToList();
        }
    }
}
