using System;
using System.Linq;

using Xunit;

namespace GradeBookTests
{
    public class EnumTests
    {
        [Fact]
        public void GradeBookTypeExists()
        {
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");
        }

        [Fact]
        public void GradeBookTypeContainsStandardTest()
        {
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            var expected = "Standard";
            var actual = Enum.Parse(gradebookEnum, "Standard", true).ToString();
            Assert.True(actual == expected, "`GradeBook.Enums.GradeBookType` doesn't contain the value `Standard`.");
        }

        [Fact]
        public void GradeBookTypeContainsRankedTest()
        {
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            var expected = "Ranked";
            var actual = Enum.Parse(gradebookEnum, "Ranked", true).ToString();
            Assert.True(actual == expected, "`GradeBook.Enums.GradeBookType` doesn't contain the value `Ranked`.");
        }

        [Fact]
        public void GradeBookTypeContainsESNUTest()
        {
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            var expected = "ESNU";
            var actual = Enum.Parse(gradebookEnum, "ESNU", true).ToString();
            Assert.True(actual == expected, "`GradeBook.Enums.GradeBookType` doesn't contain the value `ESNU`.");
        }

        [Fact]
        public void GradeBookTypeContainsOneToFourTest()
        {
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            var expected = "OneToFour";
            var actual = Enum.Parse(gradebookEnum, "OneToFour", true).ToString();
            Assert.True(actual == expected, "`GradeBook.Enums.GradeBookType` doesn't contain the value `OneToFour`.");
        }

        [Fact]
        public void GradeBookTypeContainsSixPointTest()
        {
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();
            Assert.True(gradebookEnum != null, "GradeBook.Enums.GradeBookType doesn't exist.");

            var expected = "SixPoint";
            var actual = Enum.Parse(gradebookEnum, "SixPoint", true).ToString();
            Assert.True(actual == expected, "`GradeBook.Enums.GradeBookType` doesn't contain the value `SixPoint`.");
        }
    }
}
