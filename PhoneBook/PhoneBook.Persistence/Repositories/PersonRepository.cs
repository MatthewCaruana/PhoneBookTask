using Microsoft.EntityFrameworkCore;
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
            return _context.Person.Include(x=>x.Company).ToList();
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
            return _context.Person.Include(x => x.Company).Where(x => x.Id == id).FirstOrDefault();
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
            return _context.Person.Include(x=>x.Company).OrderBy(_ => Guid.NewGuid()).Take(1).Single();
        }

        public List<PersonDataModel> Search(string keyword)
        {
            return _context.Person.Include(x=>x.Company).Where(x=>x.FullName.Contains(keyword) || x.FullAddress.Contains(keyword) || x.PhoneNumber.Contains(keyword) || x.Company.CompanyName.Contains(keyword)).Distinct().ToList();
        }

        public int GetLinkedPersons(int companyID)
        {
            return _context.Person.Count(x=>x.CompanyRef == companyID);
        }
    }
}
