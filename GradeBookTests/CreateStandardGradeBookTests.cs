using System;
using System.IO;
using System.Linq;
using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    /// <summary>
    ///     This class contains all tests related to the "Create StandardGradeBook class" task.
    ///     Note: Do not use these tests as example of good testing practices, due to the nature of how Pluralsight projects work
    ///     we have to create tests against code that doesn't exist and changes implimentation, due to this tests are fragile,
    ///     hard to maintain, and don't don't adhere to the "test just one thing" practice commonly used in production tests.
    /// </summary>
    public class CreateStandardGradeBookTests
    {
        /// <summary>
        ///     Tests to make sure the StandardGradeBook file is in the GradeBooks directory.
        /// </summary>
        [Fact(DisplayName = "Does StandardGradeBook exist in the GradeBooks Folder @create-the-standardgradebook-class")]
        public void StardardGradeBookExistsTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "GradeBooks" + Path.DirectorySeparatorChar + "StandardGradeBook.cs";
            // Assert StandardGradeBook is in the GradeBooks folder
            Assert.True(File.Exists(filePath), "`StandardGradeBook.cs` was not found in the `GradeBooks` folder.");
        }

        /// <summary>
        ///     Test to make sure the StandardGradeBook is in the GradeBook.GradeBooks namespace.
        /// </summary>
        [Fact(DisplayName = "Is StandardGradeBook in the GradeBook.GradeBooks namespace @create-the-standardgradebook-class")]
        public void StandardGradeBookIsInCorrectNamespaceTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                                 select type).FirstOrDefault();

            // Assert StandardGradeBook was found in the GradeBook.GradeBooks namespace
            Assert.True(gradebook != null, "`StandardGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");
        }

        /// <summary>
        ///     Test to make sure StandardGradeBook has a public access modifier.
        /// </summary>
        [Fact(DisplayName = "Is StandardGradeBook public @create-the-standardgradebook-class")]
        public void StandardGradeBookIsPublicTest()
        {
            // Get StandardGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                                 select type).FirstOrDefault();

            // Test to make sure the enum StandardGradeBook is public.
            Assert.True(gradebook.IsPublic, "`GradeBook.GradeBooks.StandardGradeBook` exists, but isn't `public`.");
        }

        /// <summary>
        ///     Test that StandardGradeBook inherits BaseGradeBook.
        /// </summary>
        [Fact(DisplayName = "Does StandardGradeBook inherit BaseGradeBook @create-the-standardgradebook-class")]
        public void StandardGradeBookInheritsBaseGradeBookTest()
        {
            // Get StandardGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                             select type).FirstOrDefault();

            // Assert that StandardGradeBook's BaseType is BaseGradeBook
            Assert.True(gradebook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.StandardGradeBook` doesn't inherit `BaseGradeBook`");
        }

        /// <summary>
        ///     Test that StandardGradeBook has a constructor.
        /// </summary>
        [Fact(DisplayName = "Does StandardGradeBook have a constructor @update-standardgradebook-type")]
        public void StandardGradeBookHasAConstructor()
        {
            // Get StandardGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                             select type).FirstOrDefault();

            // Get StandardGradeBook's first constructor (should be the only constructor)
            var constructor = gradebook.GetConstructors().FirstOrDefault();

            // Assert a constructor was found
            Assert.True(constructor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");
        }

        /// <summary>
        ///     Tests all requirements for creating the `StandardGradeBook` class.
        /// </summary>
        [Fact(DisplayName = "Create the StandardGradeBook class @update-standardgradebook-type")]
        [Trait("Category", "CreateStandardGradeBook")]
        public void CreateStandardGradeBookTest()
        {
            // Get StandardGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                             select type).FirstOrDefault();

            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Get StandardGradeBook's first constructor (should be the only constructor)
            var constructor = gradebook.GetConstructors().FirstOrDefault();

            // Get constructor's parameters
            var parameters = constructor.GetParameters();

            // Instantiate the StandardGradeBook
            object standardGradeBook = null;
            if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                standardGradeBook = Activator.CreateInstance(gradebook, "LoadTest");

            // GUARD CODE - Without this code this test will fail once the project is refactored to accomidate weighted grading DO NOT REMOVE!!!
            else if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                standardGradeBook = Activator.CreateInstance(gradebook, "LoadTest", true);
            // END GUARD CODE

            // Assert the Type property's value is Standard
            Assert.True(standardGradeBook.GetType().GetProperty("Type").GetValue(standardGradeBook).ToString() == Enum.Parse(gradebookEnum, "Standard", true).ToString(), "`Type` wasn't set to `GradeBookType.Standard` by the `GradeBook.GradeBooks.StandardGradeBook` Constructor.");
        }

        /// <summary>
        ///     Ignore this test, it's here as a necessity to ensure the Project's UI behaves on the "StandardGradeBook Invoke BaseGradeBook Task".
        ///     It will pass on the completion of that task despite it not actually testing it. (testing user code is weird)
        /// </summary>
        [Fact(DisplayName = "Doesn't actually test Invoke, but makes the UI work @standardgradebook-invoke-basegradebook")]
        public void MakeStandardGradeBookInvokeTaskWorkTest()
        {
            // Get StandardGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.StandardGradeBook"
                             select type).FirstOrDefault();

            // Assert that StandardGradeBook's BaseType is BaseGradeBook
            Assert.True(gradebook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.StandardGradeBook` doesn't inherit `BaseGradeBook`");
        }
    }
}
