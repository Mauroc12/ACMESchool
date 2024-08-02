using ACMESchool.Application.Course.Query.GetCoursesWithStudents;
using ACMESchool.Persistence.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Queries.GetCoursesWithStudents
{
    public class GetCoursesWithStudentsQueryHandler : IRequestHandler<GetCoursesWithStudentsQuery, GetCoursesWithStudentsResponse>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesWithStudentsQueryHandler( ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<GetCoursesWithStudentsResponse> Handle(GetCoursesWithStudentsQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetCoursesInRange(request.StartDate,request.EndDate);

            GetCoursesWithStudentsResponse response = new GetCoursesWithStudentsResponse();
            foreach (var course in courses) {
                CourseWithStudents courseWithStudents = new CourseWithStudents();
                courseWithStudents.CourseName = course.Name;

                foreach (var student in course.Students) {
                    courseWithStudents.Students.Add(student.FullName);
                }
                response.CoursesWithStudents.Add(courseWithStudents);
            }

            return  response;
        }
    }
}
