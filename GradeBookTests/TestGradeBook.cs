using System;
using GradeBook;

namespace GradeBookTests
{
    //This class exists to provide a default implimentation of the GradeBook for testing
    
    public class TestGradeBook : GradeBook.BaseGradeBook
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

        public override double GetGPA(char letterGrade, bool isWeighted, StudentType studentType)
        {
            throw new NotImplementedException();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            throw new NotImplementedException();
        }
    }
}
