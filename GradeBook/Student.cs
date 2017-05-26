using System.Collections.Generic;

namespace GradeBook
{
    public class Student
    {
        public string Name { get; set; }
        public StudentType Type { get; set; }
        public EnrollmentType Enrollment { get; set; }
        public List<decimal> Grades { get; set; }

        public Student(string name, StudentType studentType, EnrollmentType enrollment)
        {
            Name = name;
            Type = studentType;
            Enrollment = enrollment;
        }

        public void AddGrade() { }
        public void RemoveGrade() { }
        public void SaveGrade() { }
        public void CalculateStatistics() { }
    }
}
