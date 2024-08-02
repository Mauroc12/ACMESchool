using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Command.EnrollStudent
{
    public class EnrollStudentCommand :IRequest<EnrollStudentResponse>
    {
        public int CourseId  { get; set; } 
        public int StudentId { get; set; }
    }
}
