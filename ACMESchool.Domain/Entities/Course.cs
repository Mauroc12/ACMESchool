using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Domain.Entities
{
    public class Course
    {

        public Course(string name, decimal fee, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Fee = fee;
            StartDate = startDate;
            EndDate = endDate;
            Students = new List<Student>();
        }

        public Course()
        {
        }



        public int Id { get; set; }
        public string Name { get; private set; }
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public List<Student> Students { get; private set; }

        public void EnrollStudent(Student student)
        {
            if (Students == null)
                Students = new List<Student>(); 


            if (!Students.Contains(student))
            {
                Students.Add(student);
            }
            else
            {
                throw new InvalidOperationException("El alumno ya está inscrito en este curso.");
            }
        }

        public bool PaymentRequired()
        {
            return Fee > 0;
        }

    }
}
