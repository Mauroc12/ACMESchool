using ACMESchool.Persistence.Contract;
 using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACMESchool.Application.Student.Command.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<CreateStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Student student = new Domain.Entities.Student(request.FirstName, request.SurName, request.Age);
            await _studentRepository.Add(student);
            return new CreateStudentResponse();
        }
    }
}
