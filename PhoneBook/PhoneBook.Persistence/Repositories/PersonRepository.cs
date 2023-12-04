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

        public PersonDataModel FindById(int id)
        {
            return _context.Person.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdatePerson(PersonDataModel person)
        {
            _context.Person.Update(person);
        }

        public void RemovePerson(PersonDataModel person)
        {
            _context.Person.Remove(person);
        }

        public PersonDataModel GetWildcard()
        {
            return _context.Person.OrderBy(_ => Guid.NewGuid()).Take(1).Single();
        }
    }
}
