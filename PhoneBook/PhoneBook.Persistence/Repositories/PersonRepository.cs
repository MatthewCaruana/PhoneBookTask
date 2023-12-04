using PhoneBook.Persistence.Context;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Models;
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
        private IPhoneBookDbContext _context;

        public PersonRepository(IPhoneBookDbContext context) 
        {
            _context = context;
        }

        public List<PersonDataModel> GetAllPersons()
        {
            return _context.Person.ToList();
        }

        public void AddPerson(PersonDataModel person)
        {
            _context.Person.Add(person);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
