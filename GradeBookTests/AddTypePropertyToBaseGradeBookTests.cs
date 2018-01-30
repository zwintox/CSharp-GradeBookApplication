using System;
using System.Linq;
using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    /// <summary>
    ///     This class contains all tests related to the "add a type property to BaseGradeBook" task.
    ///     Note: Do not use these tests as example of good testing practices, due to the nature of how Pluralsight projects work
    ///     we have to create tests against code that doesn't exist and changes implimentation, due to this tests are fragile,
    ///     hard to maintain, and don't don't adhere to the "test just one thing" practice commonly used in production tests.
    /// </summary>
    public class AddTypePropertyToBaseGradeBookTests
    {
        /// <summary>
        ///     All tests related to the "Create a new Enum GradeBookType" task.
        /// </summary>
        [Fact(DisplayName = "Create New Enum GradeBookType Tests @add-a-gradebooktype-property-to-basegradebook")]
        public void CreateNewEnumGradeBookTypeTests()
        {
            // Get property Type from BaseGradeBook
            var typeProperty = typeof(BaseGradeBook).GetProperty("Type");

            // Test that the property Type exists in BaseGradeBook
            Assert.True(typeProperty != null, "`GradeBook.GradeBooks.BaseGradeBook` doesn't contain a property `Type` or `Type` is not `public`.");

            // Get GradeBookType Enum from GradeBook.Enums namespace
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Test that the property Type is of type GradeBookType
            Assert.True(typeProperty.PropertyType == gradebookEnum, "`GradeBook.GradeBooks.BaseGradeBook` contains a property `Type` but it is not of type `GradeBookType`.");

            // Test that the property Type's getter is public
            Assert.True(typeProperty.GetGetMethod() != null, "`GradeBook.GradeBooks.BaseGradeBook` contains a property `Type` but it's getter is not `public`.");

            // Test that the property Type's setter is public
            Assert.True(typeProperty.GetSetMethod() != null, "`GradeBook.GradeBooks.BaseGradeBook` contains a property `Type` but it's setter is not `public`.");
        }
    }
}
