using System;
using System.Linq;
using Xunit;

using GradeBook;
using GradeBook.Enums;

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

        [Fact]
        public void RemoveStudentTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            gradeBook.Students.Add(new Student("johnson", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.RemoveStudent("jamie");
            Assert.True(gradeBook.Students.FirstOrDefault(e => e.Name == "jamie") == null);
        }

        [Fact]
        public void RemoveStudentThrowsExceptionOnEmptyNameTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook", true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            Assert.Throws(typeof(ArgumentException), () => gradeBook.RemoveStudent(string.Empty));
        }

        [Fact]
        public void RemoveStudentStudentNotFoundTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook",true);
            gradeBook.Students.Add(new Student("jamie", StudentType.Standard, EnrollmentType.Campus));
            gradeBook.RemoveStudent("robert");
        }
    }
}
