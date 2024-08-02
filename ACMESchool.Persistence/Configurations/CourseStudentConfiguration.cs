using ACMESchool.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Configurations
{
  public class CourseStudentConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasMany(c => c.Students)
                .WithMany(a => a.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseStudent",
                    j => j
                        .HasOne<Student>()
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Course>()
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}