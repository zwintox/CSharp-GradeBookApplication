using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace GradeBookTests
{
    /* Disclaimer: The tests in this class are NOT recommended practice, they've been made far more compilated and fragile than standard tests out of the 
     need for the project to be able to compile prior to student completion of all tasks which greatly complicates this process, you should not do this 
     in real world testing. */

    public class StandardGradeBookTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);

            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            Assert.True((string)gradeBook.GetType().GetProperty("Name").GetValue(gradeBook) == "Test GradeBook", "`Name` wasn't set properly by `GradeBook.GradeBooks.StandardGradeBook` Construtor.");
            Assert.True(gradeBook.GetType().GetProperty("Type").GetValue(gradeBook).GetType() == Enum.Parse(gradebookEnum, "Standard", true).GetType(), "`Type` wasn't set properly by the `GradeBook.GradeBooks.StandardGradeBook` Constructor.");
        }

        [Fact]
        public void GetLetterGradeATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'A';
            var actual = (char)method.Invoke(gradeBook, new object[] { 90 });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetLetterGrade didn't give an A to students with an average grade of 90% or more.");
        }

        [Fact]
        public void GetLetterGradeBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'B';
            var actual = (char)method.Invoke(gradeBook, new object[] { 80 });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetLetterGrade didn't give an B to students with an average grade between 80% and 90%.");
        }

        [Fact]
        public void GetLetterGradeCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'C';
            var actual = (char)method.Invoke(gradeBook, new object[] { 70 });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetLetterGrade didn't give an C to students with an average grade between 70% and 80%.");
        }

        [Fact]
        public void GetLetterGradeDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'D';
            var actual = (char)method.Invoke(gradeBook, new object[] { 60 });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetLetterGrade didn't give an D to students with an average grade between 70% and 60%.");
        }

        [Fact]
        public void GetLetterGradeFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'F';
            var actual = (char)method.Invoke(gradeBook, new object[] { 50 });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetLetterGrade didn't give an F to students with an average grade below 60%.");
        }
    }
}