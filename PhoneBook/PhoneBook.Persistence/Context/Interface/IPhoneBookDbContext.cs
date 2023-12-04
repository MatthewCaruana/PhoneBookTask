using Microsoft.EntityFrameworkCore;
using PhoneBook.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Context.Interface
{
    public interface IPhoneBookDbContext
    {
        DbSet<CompanyDataModel> Company { get; set; }
        DbSet<PersonDataModel> Person { get; set; }

        void SaveChanges();
    }
}
