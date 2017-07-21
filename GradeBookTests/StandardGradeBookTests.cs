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
            if (standardGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);

            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            if (gradebookEnum == null)
                throw new Exception("GradeBook.Enums.GradeBookType doesn't exist.");

            Assert.True((string)gradeBook.GetType().GetProperty("Name").GetValue(gradeBook) == "Test GradeBook");
            Assert.True(gradeBook.GetType().GetProperty("Type").GetValue(gradeBook).GetType() == Enum.Parse(gradebookEnum, "Standard", true).GetType());
        }

        [Fact]
        public void GetLetterGradeATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            if (standardGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'A';
            var actual = (char)method.Invoke(gradeBook, new object[] { 90 });
            Assert.True(expected == actual);
        }

        [Fact]
        public void GetLetterGradeBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            if (standardGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'B';
            var actual = (char)method.Invoke(gradeBook, new object[] { 80 });
            Assert.True(expected == actual);
        }

        [Fact]
        public void GetLetterGradeCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            if (standardGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'C';
            var actual = (char)method.Invoke(gradeBook, new object[] { 70 });
            Assert.True(expected == actual);
        }

        [Fact]
        public void GetLetterGradeDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            if (standardGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'D';
            var actual = (char)method.Invoke(gradeBook, new object[] { 60 });
            Assert.True(expected == actual);
        }

        [Fact]
        public void GetLetterGradeFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            if (standardGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            object gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'F';
            var actual = (char)method.Invoke(gradeBook, new object[] { 50 });
            Assert.True(expected == actual);
        }
    }
}
