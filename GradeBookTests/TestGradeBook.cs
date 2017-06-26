using System;
using GradeBook;

namespace GradeBookTests
{
    //This class exists to provide a default implimentation of the GradeBook for testing
    
    public class TestGradeBook : GradeBook.GradeBook
    {
        public TestGradeBook(string name) : base(name) { }

        public override void CalculateStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
