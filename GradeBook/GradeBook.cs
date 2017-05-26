using System.Collections.Generic;

namespace GradeBook
{
    public abstract class GradeBook
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public virtual void Create(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
        public virtual void AddGrade() { }
        public virtual void RemoveGrade() { }
        public virtual void Load() { }
        public virtual void Save() { }
        public abstract void CalculateStatistics();
    }
}
