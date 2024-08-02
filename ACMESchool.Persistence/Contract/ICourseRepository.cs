using ACMESchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Contract
{
    public interface ICourseRepository
    {
        Task Add(Course course);
        Task Update(Course course);
        Task<Course> GetByID(int id);
        Task<List<Course>> GetCoursesInRange(DateTime startDate, DateTime endDate);
    }
}
