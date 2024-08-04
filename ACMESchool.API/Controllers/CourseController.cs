using ACMESchool.Application.Course.Command.CreateCourse;
using ACMESchool.Application.Course.Command.EnrollStudent;
using ACMESchool.Application.Course.Queries.GetCoursesWithStudents;
using ACMESchool.Application.Course.Query.GetCoursesWithStudents;
using ACMESchool.Application.Student.Command.CreateStudent;
using ACMESchool.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ACMESchool.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<OkResult> Create([FromBody] CreateCourseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("enrollStudent")]
        public async Task<OkResult> EnrollStudent([FromBody] EnrollStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("coursesWithStudents")]
        public async Task<ActionResult<GetCoursesWithStudentsResponse>> Create(DateTime StartDate, DateTime EndDate)
        {
            GetCoursesWithStudentsQuery query = new GetCoursesWithStudentsQuery()
            {
                StartDate = StartDate,
                EndDate = EndDate
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}