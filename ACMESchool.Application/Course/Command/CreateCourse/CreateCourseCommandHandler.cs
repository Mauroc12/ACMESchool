using ACMESchool.Application.Student.Command.CreateStudent;
using ACMESchool.Persistence.Contract;
using ACMESchool.Persistence.Implementation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Command.CreateCourse
{

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Course course = new Domain.Entities.Course(request.Name, request.Fee, request.StartDate, request.EndDate);
            await _courseRepository.Add(course);
            return new CreateCourseResponse().Success<CreateCourseResponse>();
        }
    }
}
