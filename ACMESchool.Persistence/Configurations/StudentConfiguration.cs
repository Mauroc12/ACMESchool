using ACMESchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Configurations;
 
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.FirstName).IsRequired();
        builder.Property(a => a.LastName).IsRequired();
        builder.Property(a => a.Age).IsRequired();

        builder.Ignore(a => a.FullName);
    }
     
}