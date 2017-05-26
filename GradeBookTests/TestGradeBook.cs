using System;

namespace GradeBookTests
{
    //This class exists to provide a default implimentation of the GradeBook for testing
    
    public class TestGradeBook : GradeBook.GradeBook
    {
        public TestGradeBook(string name) : base(name) { }

        protected override void CalculateStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
