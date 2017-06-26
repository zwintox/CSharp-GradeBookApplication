using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class GradeBook
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public bool IsWeighted { get; set; }
        public GradeBookType Type { get; set; }

        protected GradeBook(string name, bool isWeighted)
        {
            Name = name;
            IsWeighted = isWeighted;
            Students = new List<Student>();
        }

        public virtual void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
                throw new ArgumentException("A Name is required to add a student to a gradebook.");
            Students.Add(student);
        }
        public virtual void RemoveStudent() { }
        public static GradeBook Load(string name)
        {
            throw new NotImplementedException();
        }
        public static void Save()
        {
            throw new NotImplementedException();
        }
        public abstract char GetLetterGrade(double averageGrade);
        public abstract void CalculateStatistics();
    }
}
