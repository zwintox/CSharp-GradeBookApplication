using System.Collections.Generic;

namespace GradeBook
{
    public class Student
    {
        string Name { get; set; }
        StudentType Type { get; set; }
        EnrollmentType Enrollment { get; set; }
        List<decimal> Grades { get; set; }

        public Student()
        {

        }

        void AddGrade() { }
        void RemoveGrade() { }
        void SaveGrade() { }
        void CalculateStatistics() { }
    }
}
