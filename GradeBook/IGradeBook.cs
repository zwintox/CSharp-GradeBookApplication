using System.Collections.Generic;

namespace GradeBook
{
    public interface IGradeBook
    {
        string Name { get; set; }
        List<Student> Students { get; set; }

        void AddGrade();
        void RemoveGrade();
        void Save();
        void CalculateStatistics();
    }
}
