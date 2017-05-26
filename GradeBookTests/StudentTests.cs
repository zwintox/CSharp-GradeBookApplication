using GradeBook;
using Xunit;

namespace GradeBookTests
{
    public class StudentTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var actual = new Student("Test Student",StudentType.Standard,EnrollmentType.Campus);
            Assert.True(actual.Name == "Test Student");
            Assert.True(actual.Type == StudentType.Standard);
            Assert.True(actual.Enrollment == EnrollmentType.Campus);
            Assert.True(actual.Grades != null);
        }

        [Fact]
        public void AddGradeTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.AddGrade(75.1);
            Assert.True(student.Grades.Count == 1);
            Assert.True(student.Grades[0] == 75.1);
        }
    }
}
