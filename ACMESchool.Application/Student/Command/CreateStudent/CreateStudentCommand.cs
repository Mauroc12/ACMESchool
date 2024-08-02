using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACMESchool.Application.Student.Command.CreateStudent
{
    public class  CreateStudentCommand : IRequest<CreateStudentResponse>
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}
