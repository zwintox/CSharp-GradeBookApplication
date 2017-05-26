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

        protected virtual void AddStudent() { }
        protected virtual void RemoveStudent() { }
        protected virtual void Load() { }
        protected virtual void Save() { }
        protected abstract void CalculateStatistics();
    }
}
