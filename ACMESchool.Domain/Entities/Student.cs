using System;
using System.Collections.Generic;
using System.Text;

namespace ACMESchool.Domain.Entities
{
    public class Student
    {
        private const int ADULTLIMITAGE = 18;
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public int Age { get; private set; }

        public List<Course> Courses { get; private set; }
        public Student(string firstName, string lastName, int age)
        {

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            Courses = new List<Course>();
        }

        public Student()
        {
        }

        public bool IsAdult()
        {
            return Age >= ADULTLIMITAGE;
        }
    }
}
