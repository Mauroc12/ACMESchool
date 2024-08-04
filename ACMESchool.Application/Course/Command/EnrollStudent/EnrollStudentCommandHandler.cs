using ACMESchool.Application.Course.Command.CreateCourse;
using ACMESchool.ExternalServices.Contract;
using ACMESchool.Persistence.Contract;
using ACMESchool.Persistence.Implementation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACMESchool.Application.Course.Command.EnrollStudent
{
    public class EnrollStudentCommandHandler : IRequestHandler<EnrollStudentCommand, EnrollStudentResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IPaymentGateway _paymentGateway;
        public EnrollStudentCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository, IPaymentGateway paymentGateway)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _paymentGateway = paymentGateway;
        }
        public async Task<EnrollStudentResponse> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByID(request.StudentId);
            if (student == null)
            {
                throw new Exception("Estudiante no encontrado");
            }

            var course = await _courseRepository.GetByID(request.CourseId);
            if (course == null)
            {
                throw new Exception("Curso no encontrado");
            }

            if (course.PaymentRequired())
            {
                bool pagoExitoso = await _paymentGateway.Process();
                if (!pagoExitoso)
                {
                    throw new Exception("Error en el procesamiento del pago");
                }
            }

            course.EnrollStudent(student);

            await _courseRepository.Update(course);

            return new EnrollStudentResponse().Success<EnrollStudentResponse>();
        }
    }
}
