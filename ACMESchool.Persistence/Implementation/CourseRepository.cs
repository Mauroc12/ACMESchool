using ACMESchool.Domain.Entities;
using ACMESchool.Persistence.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ACMESchoolContext _context;
        public CourseRepository(ACMESchoolContext context)
        {
            _context = context;
        }

        public async Task Add(Course course)
        { 
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<Course> GetByID(int id)
        {
            return  await _context.Courses.AsTracking().Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task< List<Course>> GetCoursesInRange(DateTime startDate, DateTime endDate)
        {
            return await _context.Courses.Include(c => c.Students).Where(c => c.StartDate <= startDate && c.EndDate<= endDate).ToListAsync();
        }
    }
}
