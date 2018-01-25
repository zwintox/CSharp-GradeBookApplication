using System;
using System.IO;
using System.Linq;
using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    /// <summary>
    ///     This class contains all tests related to the "Create RankedGradeBook class" task.
    ///     Note: Do not use these tests as example of good testing practices, due to the nature of how Pluralsight projects work
    ///     we have to create tests against code that doesn't exist and changes implimentation, due to this tests are fragile,
    ///     hard to maintain, and don't don't adhere to the "test just one thing" practice commonly used in production tests.
    /// </summary>
    public class CreateRankedGradeBookTests
    {
        /// <summary>
        ///     Tests to make sure the RankedGradeBook file is in the GradeBooks directory.
        /// </summary>
        [Fact(DisplayName = "Does RankedGradeBook exist in the GradeBooks Folder @create-the-rankedgradebook-class")]
        public void StardardGradeBookExistsTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "GradeBooks" + Path.DirectorySeparatorChar + "RankedGradeBook.cs";
            // Assert RankedGradeBook is in the GradeBooks folder
            Assert.True(File.Exists(filePath), "`RankedGradeBook.cs` was not found in the `GradeBooks` folder.");
        }

        /// <summary>
        ///     Test to make sure the RankedGradeBook is in the GradeBook.GradeBooks namespace.
        /// </summary>
        [Fact(DisplayName = "Is RankedGradeBook in the GradeBook.GradeBooks namespace @create-the-rankedgradebook-class")]
        public void RankedGradeBookIsInCorrectNamespaceTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.GradeBooks.RankedGradeBook"
                                 select type).FirstOrDefault();

            // Assert RankedGradeBook was found in the GradeBook.GradeBooks namespace
            Assert.True(gradebook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");
        }

        /// <summary>
        ///     Test to make sure RankedGradeBook has a public access modifier.
        /// </summary>
        [Fact(DisplayName = "Is RankedGradeBook public @create-the-rankedgradebook-class")]
        public void RankedGradeBookIsPublicTest()
        {
            // Get RankedGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.GradeBooks.RankedGradeBook"
                                 select type).FirstOrDefault();

            // Test to make sure the enum RankedGradeBook is public.
            Assert.True(gradebook.IsPublic, "`GradeBook.GradeBooks.RankedGradeBook` exists, but isn't `public`.");
        }

        /// <summary>
        ///     Test that RankedGradeBook inherits BaseGradeBook.
        /// </summary>
        [Fact(DisplayName = "Does RankedGradeBook inherit BaseGradeBook @create-the-rankedgradebook-class")]
        public void RankedGradeBookInheritsBaseGradeBookTest()
        {
            // Get RankedGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.RankedGradeBook"
                             select type).FirstOrDefault();

            // Assert that RankedGradeBook's BaseType is BaseGradeBook
            Assert.True(gradebook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.RankedGradeBook` doesn't inherit `BaseGradeBook`");
        }

        /// <summary>
        ///     Test that RankedGradeBook has a constructor.
        /// </summary>
        [Fact(DisplayName = "Does RankedGradeBook have a constructor @update-rankedgradebook-type")]
        public void RankedGradeBookHasAConstructor()
        {
            // Get RankedGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.RankedGradeBook"
                             select type).FirstOrDefault();

            // Get RankedGradeBook's first constructor (should be the only constructor)
            var constructor = gradebook.GetConstructors().FirstOrDefault();

            // Assert a constructor was found
            Assert.True(constructor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");
        }

        /// <summary>
        ///     Tests all requirements for creating the `RankedGradeBook` class.
        /// </summary>
        [Fact(DisplayName = "Create the RankedGradeBook class @update-rankedgradebook-type")]
        [Trait("Category", "CreateRankedGradeBook")]
        public void CreateRankedGradeBookTest()
        {
            // Get RankedGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.RankedGradeBook"
                             select type).FirstOrDefault();

            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Get RankedGradeBook's first constructor (should be the only constructor)
            var constructor = gradebook.GetConstructors().FirstOrDefault();

            // Get constructor's parameters
            var parameters = constructor.GetParameters();

            // Instantiate the RankedGradeBook
            object rankedGradeBook = null;
            if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                rankedGradeBook = Activator.CreateInstance(gradebook, "LoadTest");

            // GUARD CODE - Without this code this test will fail once the project is refactored to accomidate weighted grading DO NOT REMOVE!!!
            else if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                rankedGradeBook = Activator.CreateInstance(gradebook, "LoadTest", true);
            // END GUARD CODE

            // Assert the Type property's value is Ranked
            Assert.True(rankedGradeBook.GetType().GetProperty("Type").GetValue(rankedGradeBook).ToString() == Enum.Parse(gradebookEnum, "Ranked", true).ToString(), "`Type` wasn't set to `GradeBookType.Ranked` by the `GradeBook.GradeBooks.RankedGradeBook` Constructor.");
        }

        /// <summary>
        ///     Ignore this test, it's here as a necessity to ensure the Project's UI behaves on the "RankedGradeBook Invoke BaseGradeBook Task".
        ///     It will pass on the completion of that task despite it not actually testing it. (testing user code is weird)
        /// </summary>
        [Fact(DisplayName = "Doesn't actually test Invoke, but makes the UI work @rankedgradebook-invoke-basegradebook")]
        public void MakeRankedGradeBookInvokeTaskWorkTest()
        {
            // Get RankedGradeBook from the GradeBook.GradeBooks namespace
            var gradebook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                             from type in assembly.GetTypes()
                             where type.FullName == "GradeBook.GradeBooks.RankedGradeBook"
                             select type).FirstOrDefault();

            // Assert that RankedGradeBook's BaseType is BaseGradeBook
            Assert.True(gradebook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.RankedGradeBook` doesn't inherit `BaseGradeBook`");
        }
    }
}
