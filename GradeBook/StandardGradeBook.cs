using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class StandardGradeBook : IGradeBook
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Student> Students { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddGrade()
        {
            throw new NotImplementedException();
        }

        public void CalculateStatistics()
        {
            throw new NotImplementedException();
        }

        public void RemoveGrade()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
