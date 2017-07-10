using GradeBook;
using System;
using Xunit;

namespace GradeBookTests
{
    public class GradeBookTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            Assert.True(gradeBook.Name == "Test GradeBook");
            Assert.True(gradeBook.Students != null);
        }

        [Fact]
        public void AddStudentTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            var student = new Student("Test Student",StudentType.Standard,EnrollmentType.Campus);
            gradeBook.AddStudent(student);
            Assert.True(gradeBook.Students.Count == 1);
            Assert.True(gradeBook.Students[0] == student);
        }

        [Fact]
        public void AddStudentThrowsExceptionOnEmptyNameTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            var student = new Student(string.Empty, StudentType.Standard, EnrollmentType.Campus);
            Assert.Throws(typeof(ArgumentException),() => gradeBook.AddStudent(student));
        }
    }
}
