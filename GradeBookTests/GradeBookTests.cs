using Xunit;

namespace GradeBookTests
{
    public class GradeBookTests
    {
        [Fact]
        public void CreateTest()
        {
            var gradeBook = new TestGradeBook();
            gradeBook.Create("Test GradeBook");
            Assert.True(gradeBook.Name == "Test GradeBook");
            Assert.True(gradeBook.Students != null);
        }
    }
}
