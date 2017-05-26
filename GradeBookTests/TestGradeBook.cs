using System;

namespace GradeBookTests
{
    //This class exists to provide a default implimentation of the GradeBook for testing
    
    public class TestGradeBook : GradeBook.GradeBook
    {
        public override void CalculateStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
