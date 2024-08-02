using ACMESchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Configurations
{

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Fee).IsRequired();
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.EndDate).IsRequired(); 
        }
    }
}
