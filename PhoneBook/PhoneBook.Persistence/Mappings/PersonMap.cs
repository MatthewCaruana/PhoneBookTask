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
    public class PersonMap : IEntityTypeConfiguration<PersonDataModel>
    {
        public void Configure(EntityTypeBuilder<PersonDataModel> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.Property(x=>x.Id).HasColumnName("person_id").IsRequired();
            builder.Property(x => x.FullName).HasColumnName("full_name").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").IsRequired();
            builder.Property(x => x.FullAddress).HasColumnName("full_address").IsRequired();
            builder.Property(x => x.CompanyRef).HasColumnName("company_ref").IsRequired();

            builder.HasOne(x => x.Company).WithMany(x => x.Persons).HasForeignKey(x => x.CompanyRef);
        }
    }
}
