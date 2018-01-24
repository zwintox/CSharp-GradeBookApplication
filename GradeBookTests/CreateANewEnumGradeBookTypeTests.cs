using System;
using System.IO;
using System.Linq;
using Xunit;

namespace GradeBookTests
{
    /// <summary>
    ///     This class contains all tests related to the create a new enum gradebooktype task.
    ///     Note: Do not use these tests as example of good testing practices, due to the nature of how Pluralsight projects work
    ///     we have to create tests against code that doesn't exist and changes implimentation, due to this tests are fragile,
    ///     hard to maintain, and don't don't adhere to the "test just one thing" practice commonly used in production tests.
    /// </summary>
    public class CreateANewEnumGradeBookTypeTests
    {
        /// <summary>
        ///     Tests to make sure the GradeBookType file is in the Enums directory.
        /// </summary>
        [Fact(DisplayName = "Is GradeBookType in Enums directory @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeInEnumsFolderTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "Enums" + Path.DirectorySeparatorChar + "GradeBookType.cs";
            // Assert GradeBookType is in the Enums folder
            Assert.True(File.Exists(filePath), "`GradeBookType.cs` was not found in the `Enums` directory.");
        }

        /// <summary>
        ///     Test to make sure the GradeBookType is in the GradeBook.Enums namespace.
        /// </summary>
        [Fact(DisplayName = "Is GradeBookType in the GradeBook.Enums namespace @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeIsInCorrectNamespaceTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Assert GradeBookType was found in the GradeBook.Enums namespace
            Assert.True(gradebookEnum != null, "`GradeBook.Enums.GradeBookType` wasn't found in the `GradeBooks.Enums` namespace.");
        }

        /// <summary>
        ///     Test to make sure GradeBookType has a public access modifier.
        /// </summary>
        [Fact(DisplayName = "Is GradeBookType public @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeIsPublicTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test to make sure the enum `GradeBookType` is public.
            Assert.True(gradebookEnum.IsPublic, "`GradeBook.Enums.GradeBookType` exists, but isn't `public`.");
        }

        /// <summary>
        ///     Test if GradeBookType is an Enum.
        /// </summary>
        [Fact(DisplayName = "Is GradeBookType an Enum @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeIsAnEnumTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test to make sure that `GradeBookType` is an enum not a class
            Assert.True(gradebookEnum.IsEnum, "`GradeBook.Enums.GradeBookType` exists, but isn't an enum.");
        }

        /// <summary>
        ///     Test if GradeBookType contains the value "Standard".
        /// </summary>
        [Fact(DisplayName = "Does GradeBookType contain the value Standard @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeContainsStandardTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test that `GradeBookType` contains the value `Standard`
            Assert.True(Enum.IsDefined(gradebookEnum, "Standard"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `Standard`.");
        }

        /// <summary>
        ///     Test if GradeBookType contains the value "Ranked".
        /// </summary>
        [Fact(DisplayName = "Does GradeBookType contain the value Ranked @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeContainsRankedTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test that `GradeBookType` contains the value `Ranked`
            Assert.True(Enum.IsDefined(gradebookEnum, "Ranked"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `Ranked`.");
        }

        /// <summary>
        ///     Test if GradeBookType contains the value "ESNU".
        /// </summary>
        [Fact(DisplayName = "Does GradeBookType contain the value ESNU @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeContainsESNUTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test that `GradeBookType` contains the value `ESNU`
            Assert.True(Enum.IsDefined(gradebookEnum, "ESNU"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `ESNU`.");
        }

        /// <summary>
        ///     Test if GradeBookType contains the value "OneToFour".
        /// </summary>
        [Fact(DisplayName = "Does GradeBookType contain the value OneToFour @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeContainsOneToFourTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test that `GradeBookType` contains the value `OneToFour`
            Assert.True(Enum.IsDefined(gradebookEnum, "OneToFour"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `OneToFour`.");
        }

        /// <summary>
        ///     Test if GradeBookType contains the value "SixPoint".
        /// </summary>
        [Fact(DisplayName = "Does GradeBookType contain the value SixPoint @create-a-new-enum-gradebooktype")]
        public void GradeBookTypeContainsSixPointTest()
        {
            // Get GradeBookType from the GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test that `GradeBookType` contains the value `SixPoint`
            Assert.True(Enum.IsDefined(gradebookEnum, "SixPoint"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `SixPoint`.");
        }
    }
}
