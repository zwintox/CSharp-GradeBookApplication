using GradeBook;
using GradeBook.Enums;
using System;
using System.Collections.Generic;
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

            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

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

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

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

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

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

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

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

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

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

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetLetterGrade");

            var expected = 'F';
            var actual = (char)method.Invoke(gradeBook, new object[] { 50 });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetLetterGrade didn't give an F to students with an average grade below 60%.");
        }

        #region BaseGradeBookTests.GetGPA
        [Fact]
        public void GetGPAStandardStudentIsNotWeightedATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 4;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 4 when the grade is 'A', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsNotWeightedBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 3;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'B', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 3 when the grade is 'B', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsNotWeightedCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 2;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'C', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 2 when the grade is 'C', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsNotWeightedDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 1;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'D', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 1 when the grade is 'D', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsNotWeightedFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 0;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'F', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 0 when the grade is 'F', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsWeightedATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 4;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 4 when the grade is 'A', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsWeightedBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 3;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'B', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 3 when the grade is 'B', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsWeightedCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 2;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'C', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 2 when the grade is 'C', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsWeightedDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 1;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'D', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 1 when the grade is 'D', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAStandardStudentIsWeightedFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 0;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'F', StudentType.Standard });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 0 when the grade is 'F', the Student is Standard, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsNotWeightedATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 4;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 4 when the grade is 'A', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsNotWeightedBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 3;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'B', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 3 when the grade is 'B', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsNotWeightedCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 2;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'C', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 2 when the grade is 'C', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsNotWeightedDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 1;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'D', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 1 when the grade is 'D', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsNotWeightedFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 0;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'F', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 0 when the grade is 'F', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsWeightedATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 5;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 4 when the grade is 'A', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsWeightedBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 4;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'B', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 3 when the grade is 'B', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsWeightedCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 3;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'C', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 2 when the grade is 'C', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsWeightedDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 2;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'D', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 1 when the grade is 'D', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPAHonorsStudentIsWeightedFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 1;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'F', StudentType.Honors });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 0 when the grade is 'F', the Student is Honors, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsNotWeightedATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 4;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'A', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 4 when the grade is 'A', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsNotWeightedBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 3;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'B', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 3 when the grade is 'B', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsNotWeightedCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 2;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'C', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 2 when the grade is 'C', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsNotWeightedDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 1;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'D', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 1 when the grade is 'D', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsNotWeightedFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", false);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 0;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'F', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 0 when the grade is 'F', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsWeightedATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 5;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'A', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 4 when the grade is 'A', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsWeightedBTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 4;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'B', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 3 when the grade is 'B', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsWeightedCTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 3;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'C', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 2 when the grade is 'C', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsWeightedDTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 2;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'D', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 1 when the grade is 'D', the Student is DuelEnrolled, and grades are not weighted.");
        }

        [Fact]
        public void GetGPADuelEnrolledStudentIsWeightedFTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            var expected = 1;
            var actual = (double)method.Invoke(gradeBook, new object[] { 'F', StudentType.DuelEnrolled });
            Assert.True(expected == actual, "GradeBook.GradeBooks.StandardGradeBook.GetGPA didn't give a GPA of 0 when the grade is 'F', the Student is DuelEnrolled, and grades are not weighted.");
        }
        #endregion

        [Fact]
        public void AddStudentExceptionWhenNoNameTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "GradeBook.GradeBooks.StandardGradeBook doesn't exist.");

            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.StandardGradeBook have the expected parameters.");

            MethodInfo method = standardGradeBook.GetMethod("AddStudent");

            var exception = Record.Exception(() => method.Invoke(gradeBook, new object[] { new Student(string.Empty, StudentType.Standard, EnrollmentType.Campus) }));
            Assert.True(exception != null, "GradeBook.GradeBooks.BaseGradeBook.AddStudent didn't throw an exception when a student's name was empty when used from a StandardGradeBook.");
        }

        [Fact]
        public void AddStudentTest()
        {
            var rankedGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "RankedGradeBook"
                                   select type).FirstOrDefault();
            Assert.True(rankedGradeBook != null, "GradeBook.GradeBooks.RankedGradeBook doesn't exist.");

            var ctor = rankedGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook");
            Assert.True(gradeBook != null, "The constructor for GradeBook.GradeBooks.RankedGradeBook have the expected parameters.");

            MethodInfo method = rankedGradeBook.GetMethod("AddStudent");

            var expected = new Student("Test Student", StudentType.Standard, EnrollmentType.Campus);
            method.Invoke(gradeBook, new object[] { new Student("Test Student", StudentType.Standard, EnrollmentType.Campus) });
            Assert.True(((List<Student>)gradeBook.GetType().GetProperty("Students").GetValue(gradeBook)).FirstOrDefault(e => e.Name == "Test Student") != null, "GradeBook.GradeBooks.BaseGradeBook.AddStudent didn't successfully add a student when called through RankedGradeBook.");
        }
    }
}