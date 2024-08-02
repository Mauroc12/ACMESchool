using ACMESchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Queries.GetCoursesWithStudents
{
    public class GetCoursesWithStudentsResponse
    {
        public GetCoursesWithStudentsResponse()
        {
            CoursesWithStudents = new List<CourseWithStudents>();
        }
        public List<CourseWithStudents> CoursesWithStudents { get; set; }
    }
    public class CourseWithStudents
    {
        public CourseWithStudents()
        {
            Students = new List<string>();
        }

        public string CourseName { get; set; }
        public List<string> Students { get; set; }
    }


}
