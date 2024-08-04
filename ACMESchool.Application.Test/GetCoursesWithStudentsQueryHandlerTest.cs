using ACMESchool.Application.Course.Queries.GetCoursesWithStudents;
using ACMESchool.Application.Course.Query.GetCoursesWithStudents;
using ACMESchool.Persistence.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Application.Test
{
    public class GetCoursesWithStudentsQueryHandlerTests
    {

        private readonly Domain.Entities.Student Mauro;
        private readonly Domain.Entities.Student Juan;
        private readonly Domain.Entities.Course Matematica;
        private readonly Domain.Entities.Course Lengua;
        private readonly List<Domain.Entities.Course> Courses;
        public GetCoursesWithStudentsQueryHandlerTests()
        {
            Mauro = new Domain.Entities.Student("Mauro", "Castro", 20);
            Juan = new Domain.Entities.Student("Juan", "Perez", 20);
            Matematica = new Domain.Entities.Course("Matematica", 100, DateTime.Today, DateTime.Today.AddDays(30));
            Lengua = new Domain.Entities.Course("Lengua", 50, DateTime.Today, DateTime.Today.AddDays(3));

            Matematica.EnrollStudent(Mauro);
            Matematica.EnrollStudent(Juan);

            Lengua.EnrollStudent(Mauro);

            Courses = [Matematica, Lengua];

        }

        [Fact]
        public async Task Handle_Should_Return_CoursesWithStudents()
        {
            // Arrange
            var courseRepositoryMock = new Mock<ICourseRepository>();

            courseRepositoryMock.Setup(repo => repo.GetCoursesInRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(Courses);

            var queryHandler = new GetCoursesWithStudentsQueryHandler(courseRepositoryMock.Object);
            var query = new GetCoursesWithStudentsQuery
            {
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now
            };

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.CoursesWithStudents.Count);

            Assert.Equal("Matematica", result.CoursesWithStudents[0].CourseName);
            Assert.Equal(2, result.CoursesWithStudents[0].Students.Count);
            Assert.Contains("Mauro Castro", result.CoursesWithStudents[0].Students);
            Assert.Contains("Juan Perez", result.CoursesWithStudents[0].Students);

            Assert.Equal("Lengua", result.CoursesWithStudents[1].CourseName);
            Assert.Single(result.CoursesWithStudents[1].Students);
            Assert.Contains("Mauro Castro", result.CoursesWithStudents[1].Students);
        }


        [Fact]
        public async Task Handle_Should_Return_EmptyList()
        {
            // Arrange
            var courseRepositoryMock = new Mock<ICourseRepository>();
             
            courseRepositoryMock.Setup(repo => repo.GetCoursesInRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Domain.Entities.Course>());

            var queryHandler = new GetCoursesWithStudentsQueryHandler(courseRepositoryMock.Object);
            var query = new GetCoursesWithStudentsQuery
            {
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now
            };

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert 
            Assert.Empty(result.CoursesWithStudents); 
        }


    }
}