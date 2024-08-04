using ACMESchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Domain.Test
{
    public class CourseTests
    {
        [Fact]
        public void Constructor_Should_Create_Course()
        {
            // Arrange
            var name = "Matematicas";
            var fee = 100;
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 6, 30);

            // Act
            var course = new Course(name, fee, startDate, endDate);

            // Assert
            Assert.Equal(name, course.Name);
            Assert.Equal(fee, course.Fee);
            Assert.Equal(startDate, course.StartDate);
            Assert.Equal(endDate, course.EndDate);
            Assert.Empty(course.Students);
        }

        [Fact]
        public void EnrollStudent_Should_Add_Student()
        {
            // Arrange
            var course = new Course("Matematica", 100, DateTime.Now, DateTime.Now.AddMonths(6));
            var student = new Student("Mauro", "Castro", 20);

            // Act
            course.EnrollStudent(student);

            // Assert
            Assert.Contains(student, course.Students);
        }

        [Fact]
        public void EnrollStudent_Already_Enrolled_Student_Should_Throw_Exception()
        {
            // Arrange
            var course = new Course("Matematica", 100, DateTime.Now, DateTime.Now.AddMonths(6));
            var student = new Student("Mauro", "Castro", 20);
            course.EnrollStudent(student);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => course.EnrollStudent(student));
            Assert.Equal("El alumno ya está inscrito en este curso.", exception.Message);
        }

        [Fact]
        public void PaymentRequired_Fee_Greater_Than_Zero_Should_Return_True()
        {
            // Arrange
            var course = new Course("Matematica", 100, DateTime.Now, DateTime.Now.AddMonths(6));

            // Act
            var paymentRequired = course.PaymentRequired();

            // Assert
            Assert.True(paymentRequired);
        }

        [Fact]
        public void PaymentRequired_Fee_Equal_Zero_Should_Return_False()
        {
            // Arrange
            var course = new Course("Matematica", 0, DateTime.Now, DateTime.Now.AddMonths(6));

            // Act
            var paymentRequired = course.PaymentRequired();

            // Assert
            Assert.False(paymentRequired);
        }
    }
}