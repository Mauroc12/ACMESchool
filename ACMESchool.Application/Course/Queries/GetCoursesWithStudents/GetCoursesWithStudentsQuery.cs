using ACMESchool.Application.Course.Queries.GetCoursesWithStudents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Query.GetCoursesWithStudents
{
    public  class GetCoursesWithStudentsQuery : IRequest<GetCoursesWithStudentsResponse>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
