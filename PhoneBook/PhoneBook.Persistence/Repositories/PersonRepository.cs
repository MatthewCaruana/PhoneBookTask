using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private PhoneBookContext _context;

        public PersonRepository(PhoneBookContext context) 
        {
            _context = context;
        }


    }
}
