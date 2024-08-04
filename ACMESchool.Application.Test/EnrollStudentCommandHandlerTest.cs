using ACMESchool.Application.Course.Command.EnrollStudent;
using ACMESchool.ExternalServices.Contract;
using ACMESchool.Persistence.Contract;
using ACMESchool.Domain.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ACMESchool.Application.Test
{
    public class EnrollStudentCommandHandlerTests
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly Mock<IPaymentGateway> _paymentGatewayMock;
        private readonly EnrollStudentCommandHandler _handler; 


        public EnrollStudentCommandHandlerTests()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _paymentGatewayMock = new Mock<IPaymentGateway>();
            _handler = new EnrollStudentCommandHandler(
                _courseRepositoryMock.Object,
                _studentRepositoryMock.Object,
                _paymentGatewayMock.Object
            );
        }

        [Fact]
        public async Task Handle_Student_NotFound_Should_Throw_Exception()
        {
            // Arrange
            var command = new EnrollStudentCommand { StudentId = 1, CourseId = 1 };
            _studentRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                  .Returns(Task.FromResult<Domain.Entities.Student>(null));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Estudiante no encontrado", exception.Message);
        }

        [Fact]
        public async Task Handle_Course_NotFound_Should_Throw_Exception()
        {
            // Arrange
            var command = new EnrollStudentCommand { StudentId = 1, CourseId = 1 };
            _studentRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                  .ReturnsAsync(new Domain.Entities.Student("Mauro", "Castro", 20));

            _courseRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                   .Returns(Task.FromResult<Domain.Entities.Course>(null));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Curso no encontrado", exception.Message);
        }

        [Fact]
        public async Task Handle_PaymentFails_Should_Throw_Exception()
        {
            // Arrange
            var command = new EnrollStudentCommand { StudentId = 1, CourseId = 1 };
            var course = new Domain.Entities.Course("Matematica", 100, DateTime.Now, DateTime.Now.AddMonths(6));
            _studentRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                  .ReturnsAsync(new Domain.Entities.Student("Mauro", "Castro", 20));

            _courseRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                 .ReturnsAsync(course);

            _paymentGatewayMock.Setup(pg => pg.Process())
                               .ReturnsAsync(false);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Error en el procesamiento del pago", exception.Message);
        }

        [Fact]
        public async Task Handle_Valid_Should_Enroll_Student()
        {
            // Arrange
            var command = new EnrollStudentCommand { StudentId = 1, CourseId = 1 };
            var student = new Domain.Entities.Student("Mauro", "Castro", 20);
            var course = new Domain.Entities.Course("Matematica", 100, DateTime.Now, DateTime.Now.AddMonths(6));

            _studentRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                  .ReturnsAsync(student);

            _courseRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<int>()))
                                 .ReturnsAsync(course);

            _paymentGatewayMock.Setup(pg => pg.Process())
                               .ReturnsAsync(true);

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _courseRepositoryMock.Verify(repo => repo.Update(course), Times.Once);
            Assert.Contains(student, course.Students);
        }
    }
}