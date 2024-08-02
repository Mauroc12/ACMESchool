using ACMESchool.Domain.Entities;
using ACMESchool.Persistence.Contract;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ACMESchoolContext _context;
        public StudentRepository(ACMESchoolContext context) { 
            _context = context; 
        }
        public async Task Add(Student student)
        {       
           await _context.Students.AddAsync(student);
           await _context.SaveChangesAsync();
        }

        public async Task<Student> GetByID(int id)
        {
            return await _context.Students.FindAsync(id);
        }
    }
}
