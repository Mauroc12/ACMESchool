using ACMESchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Persistence.Contract
{
    public interface IStudentRepository
    {
        Task Add(Student student);
        Task<Student> GetByID(int id);
    }
}
