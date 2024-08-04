using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xunit;
using ACMESchool.Domain.Entities;

namespace ACMESchool.Domain.Test
{
    public class StudentTests
    {
        [Fact]
        public void Contructor_Should_Create_a_student()
        {
            // Arrange
            var firstName = "Mauro";
            var lastName = "Castro";
            var age = 31;

            // Act
            var student = new Student(firstName, lastName, age);

            // Assert
            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(age, student.Age); 
        }

        [Fact]
        public void Constructor_Should_ThrowException_underrate_age()
        {
            // Arrange
            var firstName = "Mauro";
            var lastName = "Castro";
            var age = 17;


            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, age));
            Assert.Equal("El estudiante debe ser mayor de edad.", exception.Message);
        }

        [Fact]
        public void FullName_Should_Return_Correct_FullName()
        {
            // Arrange
            var firstName = "Mauro";
            var lastName = "Castro";
            var age = 20;
            var student = new Student(firstName, lastName, age);


            // Assert
            Assert.Equal(string.Format("{0} {1}", firstName, lastName), student.FullName);
        } 
      
    }
}