using System;

using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBookTests
{
    //This class exists to provide a default implementation of the GradeBook for testing
    
    public class TestGradeBook : BaseGradeBook
    {
        public TestGradeBook(string name, bool isWeighted) : base(name, isWeighted) { }

        public override void CalculateStatistics()
        {
            throw new NotImplementedException();
        }

        public override void CalculateStudentStatistics(string name)
        {
            throw new NotImplementedException();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            throw new NotImplementedException();
        }
    }
}
