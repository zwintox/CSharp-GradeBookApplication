using Xunit;

namespace GradeBookTests
{
    public class GradeBookTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var gradeBook = new TestGradeBook("Test GradeBook");
            Assert.True(gradeBook.Name == "Test GradeBook");
            Assert.True(gradeBook.Students != null);
        }
    }
}
