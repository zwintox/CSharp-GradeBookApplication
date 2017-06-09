using GradeBook;
using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBookTests
{
    public class StudentTests
    {
        [Fact]
        public void ConstructorNameTest()
        {
            var actual = new Student("Test Student",StudentType.Standard,EnrollmentType.Campus);
            Assert.True(actual.Name == "Test Student");
        }

        [Fact]
        public void ConstructorTypeTest()
        {
            var actual = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            Assert.True(actual.Type == StudentType.Standard);
        }

        [Fact]
        public void ConstructorEnrollmentTest()
        {
            var actual = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            Assert.True(actual.Enrollment == EnrollmentType.Campus);
        }

        [Fact]
        public void ConstructorGradesNotNullTest()
        {
            var actual = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            Assert.True(actual.Grades != null);
        }

        [Fact]
        public void AddGradeTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.AddGrade(75.1);
            Assert.True(student.Grades.Count == 1 && student.Grades[0] == 75.1);
        }

        [Fact]
        public void AddGradeZeroAcceptedTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.AddGrade(0);
            Assert.True(student.Grades.Count == 1 && student.Grades[0] == 0);
        }

        [Fact]
        public void AddGradeOneHundredAcceptedTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.AddGrade(100);
            Assert.True(student.Grades.Count == 1 && student.Grades[0] == 100);
        }

        [Fact]
        public void AddGradeExceptionOnLowerThanZeroTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            Assert.Throws(typeof(ArgumentException), () => student.AddGrade(-10));
        }

        [Fact]
        public void AddGradeExceptionOnMoreThanOneHundredTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            Assert.Throws(typeof(ArgumentException), () => student.AddGrade(110));
        }

        [Fact]
        public void RemoveGradeTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double>{ 50, 75, 100 };
            student.RemoveGrade(75);
            Assert.True(student.Grades.Count == 2 && !student.Grades.Contains(75));
        }

        [Fact]
        public void AverageGradeTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double> { 50, 75, 100 };
            Assert.True(student.AverageGrade == 75);
        }

        [Fact]
        public void LetterGradeATest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double> { 100 };
            Assert.True(student.LetterGrade == 'a');
        }

        [Fact]
        public void LetterGradeBTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double> { 90 };
            Assert.True(student.LetterGrade == 'b');
        }

        [Fact]
        public void LetterGradeCTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double> { 80 };
            Assert.True(student.LetterGrade == 'c');
        }

        [Fact]
        public void LetterGradeDTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double> { 70 };
            Assert.True(student.LetterGrade == 'd');
        }

        [Fact]
        public void LetterGradeFTest()
        {
            var student = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            student.Grades = new List<double> { 60 };
            Assert.True(student.LetterGrade == 'f');
        }
    }
}
