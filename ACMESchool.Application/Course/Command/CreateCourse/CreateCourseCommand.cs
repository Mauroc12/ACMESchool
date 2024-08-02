using ACMESchool.Application.Student.Command.CreateStudent;
using MediatR;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Command.CreateCourse
{
    public class CreateCourseCommand : IRequest<CreateCourseResponse> 
    {
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
} 