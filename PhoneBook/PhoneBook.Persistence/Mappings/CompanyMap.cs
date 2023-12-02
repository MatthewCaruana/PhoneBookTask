using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<CompanyDataModel>
    {
        public void Configure(EntityTypeBuilder<CompanyDataModel> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasColumnName("company_id").IsRequired();
            builder.Property(x => x.CompanyName).HasColumnName("company_name").IsRequired();
            builder.Property(x => x.RegistrationDate).HasColumnName("registration_date").IsRequired();

            builder.HasMany(x=>x.Persons).WithOne(x=>x.Company);
        }
    }
}
