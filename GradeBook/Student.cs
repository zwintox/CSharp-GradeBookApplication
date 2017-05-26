using System.Collections.Generic;

namespace GradeBook
{
    public class Student
    {
        public string Name { get; set; }
        public StudentType Type { get; set; }
        public EnrollmentType Enrollment { get; set; }
        public List<double> Grades { get; set; }

        public Student(string name, StudentType studentType, EnrollmentType enrollment)
        {
            Name = name;
            Type = studentType;
            Enrollment = enrollment;
            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }
        public void RemoveGrade() { }
        public void SaveGrade() { }
        public void CalculateStatistics() { }
    }
}
