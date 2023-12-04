using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Persistence.Context.Interface;
using PhoneBook.Persistence.Mappings;
using PhoneBook.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Context
{
    public class PhoneBookContext : DbContext, IPhoneBookDbContext 
    {
        protected readonly IConfiguration Configuration;

        public PhoneBookContext() { }

        public PhoneBookContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
        }

        public DbSet<CompanyDataModel> Company { get; set; }
        public DbSet<PersonDataModel> Person { get; set; }

        public new void SaveChanges()
        {
            var a = this.ChangeTracker.Entries().ToArray();
            base.SaveChanges();
        }
    }
}
