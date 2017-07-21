using Xunit;

using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBookTests
{
    /* Disclaimer: The tests in this class are NOT recommended practice, they've been made far more compilated and fragile than standard tests out of the 
     need for the project to be able to compile prior to student completion of all tasks which greatly complicates this process, you should not do this 
     in real world testing. */

    public class StandardGradeBookTests
    {
        //[Fact]
        //public void ConstructorTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);
        //    Assert.True(gradeBook.Name == "Test GradeBook");
        //    Assert.True(gradeBook.Type == GradeBookType.Standard);
        //}

        //[Fact]
        //public void GetGPAWeightedATest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);

        //    var expected = 5;
        //    var actual = gradeBook.GetGPA('A',StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAWeightedBTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);

        //    var expected = 4;
        //    var actual = gradeBook.GetGPA('B', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAWeightedCTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);

        //    var expected = 3;
        //    var actual = gradeBook.GetGPA('C', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAWeightedDTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);

        //    var expected = 2;
        //    var actual = gradeBook.GetGPA('D', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAWeightedFTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);

        //    var expected = 1;
        //    var actual = gradeBook.GetGPA('F', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAWeightedOtherTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);

        //    var expected = 0;
        //    var actual = gradeBook.GetGPA('E', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAUnweightedATest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", false);

        //    var expected = 4;
        //    var actual = gradeBook.GetGPA('A', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAUnweightedBTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", false);

        //    var expected = 3;
        //    var actual = gradeBook.GetGPA('B', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAUnweightedCTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", false);

        //    var expected = 2;
        //    var actual = gradeBook.GetGPA('C', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAUnweightedDTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", false);

        //    var expected = 1;
        //    var actual = gradeBook.GetGPA('D', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAUnweightedFTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", false);

        //    var expected = 0;
        //    var actual = gradeBook.GetGPA('F', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetGPAUnweightedOtherTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", false);

        //    var expected = 0;
        //    var actual = gradeBook.GetGPA('E', StudentType.Honors);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeATest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);
        //    var expected = 'A';
        //    var actual = gradeBook.GetLetterGrade(90);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeBTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);
        //    var expected = 'B';
        //    var actual = gradeBook.GetLetterGrade(80);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeCTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);
        //    var expected = 'C';
        //    var actual = gradeBook.GetLetterGrade(70);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeDTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);
        //    var expected = 'D';
        //    var actual = gradeBook.GetLetterGrade(60);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeFTest()
        //{
        //    var gradeBook = new StandardGradeBook("Test GradeBook", true);
        //    var expected = 'F';
        //    var actual = gradeBook.GetLetterGrade(50);
        //    Assert.True(expected == actual);
        //}
    }
}
