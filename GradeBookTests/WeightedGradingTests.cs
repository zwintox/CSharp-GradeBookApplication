using GradeBook.Enums;
using GradeBook.GradeBooks;
using GradeBook.UserInterfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace GradeBookTests
{
    public class WeightedGradingTests
    {
        [Fact(DisplayName = "Add IsWeighted To BaseGradeBook")]
        [Trait("Category", "AddIsWeightedPropertyTest")]
        public void AddIsWeightedPropertyTest()
        {
            var isWeightedProperty = typeof(BaseGradeBook).GetProperty("IsWeighted");

            Assert.True(isWeightedProperty != null, "`GradeBook.GradeBooks.BaseGradeBook` does not contain an `IsWeighted` property. @add-isweighted-to-basegradebook");
            Assert.True(isWeightedProperty.GetGetMethod().IsPublic == true, "`GradeBook.GradeBooks.BaseGradeBook`'s `IsWeighted` property is not public. @add-isweighted-to-basegradebook");
            Assert.True(isWeightedProperty.PropertyType == typeof(bool), "`GradeBook.GradeBooks.BaseGradeBook`'s `IsWeighted` is not of type `bool`. @add-isweighted-to-basegradebook");
        }

        [Fact(DisplayName = "Refactor Constructor of BaseGradeBook")]
        [Trait("Category", "RefactorConstructorTest")]
        public void RefactorConstructorTest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "`GradeBook.GradeBooks.StandardGradeBook` doesn't exist. @add-bool-to-basegradebook-constructor");

            // Test if `StandardGradeBook` is `public`.
            Assert.True(standardGradeBook.IsPublic, "`GradeBook.GradeBooks.StandardGradeBook` isn't public. @add-bool-to-basegradebook-constructor");

            // Test if `StandardGradeBook` is inheritting `BaseGradeBook`.
            Assert.True(standardGradeBook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.StandardGradeBook` doesn't inherit `BaseGradeBook`. @add-bool-to-basegradebook-constructor");

            // Test if `StandardGradeBook`'s constructor has the proper signature (consider both this task and later signature)
            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook. @add-bool-to-basegradebook-constructor");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            Assert.True(parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool), "`GradeBook.GradeBooks.BaseGradeBook`'s constructor doesn't have the correct parameters. It should be a `string` and a `bool`. @add-bool-to-standardgradebook @add-bool-to-rankedgradebook");

            gradeBook = Activator.CreateInstance(standardGradeBook, "WeightedTest", true);
            Assert.True(gradeBook.GetType().GetProperty("IsWeighted").GetValue(gradeBook).ToString().ToLower() == "true", "`GradeBook.GradeBooks.BaseGradeBook`'s constructor didn't propertly set the `IsWeighted` property based on the provided bool parameter. @set-isweighted-property @instantiate-with-weight");

            //Setup Test
            var output = string.Empty;
            Console.Clear();
            using (var consoleInputStream = new StringReader("close"))
            {
                Console.SetIn(consoleInputStream);
                using (var consolestream = new StringWriter())
                {
                    Console.SetOut(consolestream);
                    StartingUserInterface.CreateCommand("create test standard");
                    output = consolestream.ToString().ToLower();
                }
            }
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standardOutput);
            StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardInput);

            //Test that message written to console when parts.length != 4.
            Assert.True(output.Contains("command not valid"), "`GradeBook.UserInterfaces.StartingUserInterface` didn't write a message to the console when the create command didn't contain a name, type, and if it was weighted (true / false). @add-weighted-to-createcommand");

            //Test that message written to console is correct.
            Assert.True(output.Contains("command not valid, create requires a name, type of gradebook, if it's weighted (true / false)."), "`GradeBook.UserInterfaces.StartingUserInterface` didn't write 'Command not valid, Create requires a name, type of gradebook, if it's weighted (true / false)..' to the console when the create command didn't contain both a name and type. @add-weighted-to-createcommand @add-weighted-to-message");

            //Test that `CreateCommand` escapes returns without setting the gradebook when parts.Length != 4.
            Assert.True(!output.Contains("created gradebook"), "`GradeBook.UserInterfaces.StartingUserInterface` still created a gradebook when the create command didn't contain a name, type, if it's weighted (true / false). @add-weighted-to-createcommand");

            output = string.Empty;
            Console.Clear();
            using (var consoleInputStream = new StringReader("close"))
            {
                Console.SetIn(consoleInputStream);
                using (var consolestream = new StringWriter())
                {
                    Console.SetOut(consolestream);
                    StartingUserInterface.CreateCommand("create test standard true");
                    output = consolestream.ToString().ToLower();
                }
            }
            standardOutput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standardOutput);
            standardInput = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardInput);

            Assert.True(output.Contains("standard"), "`GradeBook.UserInterfaces.StartingUserInterface` didn't create a gradebook when the `CreateCommand` included a name, type, and if it was weighted (true / false). @add-weighted-to-createcommand");
        }

        /// <summary>
        ///     Tests all functionality
        /// </summary>
        [Fact(DisplayName = "Update BaseGradeBook's GetGPA Method")]
        [Trait("Category", "GetWeightedGPATest")]
        public void GetWeightedGPATest()
        {
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();
            Assert.True(standardGradeBook != null, "`GradeBook.GradeBooks.StandardGradeBook` doesn't exist. @update-basegradebook-s-getgpa-method");

            // Test if `StandardGradeBook` is `public`.
            Assert.True(standardGradeBook.IsPublic, "`GradeBook.GradeBooks.StandardGradeBook` isn't public. @update-basegradebook-s-getgpa-method");

            // Test if `StandardGradeBook` is inheritting `BaseGradeBook`.
            Assert.True(standardGradeBook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.StandardGradeBook` doesn't inherit `BaseGradeBook`. @update-basegradebook-s-getgpa-method");

            // Test if `StandardGradeBook`'s constructor has the proper signature (consider both this task and later signature)
            var ctor = standardGradeBook.GetConstructors().FirstOrDefault();
            Assert.True(ctor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook. @update-basegradebook-s-getgpa-method");

            var parameters = ctor.GetParameters();
            object gradeBook = null;
            Assert.True(parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool), "`GradeBook.GradeBooks.BaseGradeBook`'s constructor doesn't have the correct parameters. It should be a `string` and a `bool`. @update-basegradebook-s-getgpa-method");

            gradeBook = Activator.CreateInstance(standardGradeBook, "WeightedTest", true);
            MethodInfo method = standardGradeBook.GetMethod("GetGPA");

            // Test weighting works correctly for Weighted gradebooks
            Assert.True((double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Standard }) == 4,"`GradeBook.GradeBooks.BaseGradeBook`'s `GetGPA` method weighted a student's grade even when they weren't an Honors or Duel Enrolled student. @update-basegradebook-s-getgpa-method");
            Assert.True((double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Honors }) == 5, "`GradeBook.GradeBooks.BaseGradeBook`'s `GetGPA` method did not weight a student's when they were an Honors student. @update-basegradebook-s-getgpa-method");
            Assert.True((double)method.Invoke(gradeBook, new object[] { 'A', StudentType.DuelEnrolled }) == 5, "`GradeBook.GradeBooks.BaseGradeBook`'s `GetGPA` method did not weight a student's when they were a Duel Enrolled student. @update-basegradebook-s-getgpa-method");

            // Test weighting works correctly for unweighted gradebooks
            gradeBook.GetType().GetProperty("IsWeighted").SetValue(gradeBook,false);
            Assert.True((double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Standard }) == 4, "`GradeBook.GradeBooks.BaseGradeBook`'s `GetGPA` method weighted a student's grade when the gradebook was not weighted. @update-basegradebook-s-getgpa-method");
            Assert.True((double)method.Invoke(gradeBook, new object[] { 'A', StudentType.Honors }) == 4, "`GradeBook.GradeBooks.BaseGradeBook`'s `GetGPA` method weighted a student's grade when the gradebook was not weighted. @update-basegradebook-s-getgpa-method");
            Assert.True((double)method.Invoke(gradeBook, new object[] { 'A', StudentType.DuelEnrolled }) == 4, "`GradeBook.GradeBooks.BaseGradeBook`'s `GetGPA` method weighted a student's grade when the gradebook was not weighted. @update-basegradebook-s-getgpa-method");
        }

        /// <summary>
        ///     Tests Help Command update to ensure all changes were made correctly.
        /// </summary>
        [Fact(DisplayName = "Update HelpCommand Method")]
        [Trait("Category", "UpdateHelpCommandAgain")]
        public void UpdateHelpCommandTest()
        {
            //Setup Test
            var output = string.Empty;
            Console.Clear();
            using (var consoleInputStream = new StringReader("close"))
            {
                Console.SetIn(consoleInputStream);
                using (var consolestream = new StringWriter())
                {
                    Console.SetOut(consolestream);
                    StartingUserInterface.HelpCommand();
                    output = consolestream.ToString().ToLower();
                }
            }
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standardOutput);

            // Test if help command message is correct
            Assert.True(output.Contains("create 'name' 'type' 'weighted' - creates a new gradebook where 'name' is the name of the gradebook, 'type' is what type of grading it should use, and 'weighted' is whether or not grades should be weighted (true or false)."), "`GradeBook.UserInterfaces.StartingUserInterface.HelpCommand` didn't write \"Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).\" @update-helpcommand-method");
        }
    }
}
