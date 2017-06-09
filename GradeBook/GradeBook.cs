using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class GradeBook
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        protected GradeBook(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public virtual void AddStudent(Student student)
        {
            if(string.IsNullOrEmpty(student.Name))
                throw new ArgumentException("A Name is required to add a student to a gradebook.");
            Students.Add(student);
        }
        public virtual void RemoveStudent() { }
        public static GradeBook Load(string name)
        {
            throw new NotImplementedException();
        }
        public virtual void Save() { }
        public abstract void CalculateStatistics();
    }
}
