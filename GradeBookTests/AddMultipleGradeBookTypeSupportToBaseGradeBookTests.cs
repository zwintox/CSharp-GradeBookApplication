using System;
using System.IO;
using System.Linq;
using GradeBook.GradeBooks;
using Newtonsoft.Json;
using Xunit;

namespace GradeBookTests
{
    public class AddMultipleGradeBookTypeSupportToBaseGradeBookTests
    {
        /// <summary>
        ///     All tests related to the "Cast To StandardGradeBook" task.
        /// </summary>
        [Fact(DisplayName = "Cast To StandardGradeBook @cast-to-standardgradebook")]
        public void CastToStandardGradeBookTests()
        {
            // Get the GradeBookType Enum
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Get the StandardGradeBook Class.
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "StandardGradeBook"
                                     select type).FirstOrDefault();

            // Get StandardGradeBook's constructor
            var constructor = standardGradeBook.GetConstructors().FirstOrDefault();

            // Instantiate StandardGradeBook
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "LoadTest", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "LoadTest");

            // Set Type to Standard
            gradeBook.GetType().GetProperty("Type").SetValue(gradeBook, Enum.Parse(gradebookEnum, "Standard", true));

            // Save the StandardGradeBook to the harddrive for retrieval
            try
            {
                using (var file = new FileStream("LoadTest.gdbk", FileMode.Create, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        var json = JsonConvert.SerializeObject(gradeBook);
                        writer.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.True(ex != null, "Test for GradeBook.GradeBooks.BaseGradeBook.Load was unable to run. This is likely due to issues being able to read/write gradebook files to the local file system.");
            }

            // Retrieve StandardGradeBook from the harddrive.
            var actual = BaseGradeBook.Load("LoadTest");
            File.Delete("LoadTest.gdbk");
            Assert.True(actual.GetType() == standardGradeBook || actual == null, "`GradeBook.GradeBooks.BaseGradeBook.Load` didn't return a `StandardGradeBook` when `Type` was `Standard`.");
        }

        /// <summary>
        ///     All tests related to the "Cast To RankedGradeBook" task.
        /// </summary>
        [Fact(DisplayName = "Cast To RankedGradeBook @cast-to-rankedgradebook")]
        public void CastToRankedGradeBookTests()
        {
            // Get the GradeBookType Enum
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Get the RankedGradeBook Class.
            var rankedGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "RankedGradeBook"
                                     select type).FirstOrDefault();

            // Get RankedGradeBook's constructor
            var constructor = rankedGradeBook.GetConstructors().FirstOrDefault();

            // Instantiate RankedGradeBook
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "LoadTest", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(rankedGradeBook, "LoadTest");

            // Set Type to Ranked
            gradeBook.GetType().GetProperty("Type").SetValue(gradeBook, Enum.Parse(gradebookEnum, "Ranked", true));

            // Save the StandardGradeBook to the harddrive for retrieval
            try
            {
                using (var file = new FileStream("LoadTest.gdbk", FileMode.Create, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        var json = JsonConvert.SerializeObject(gradeBook);
                        writer.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.True(ex != null, "Test for GradeBook.GradeBooks.BaseGradeBook.Load was unable to run. This is likely due to issues being able to read/write gradebook files to the local file system.");
            }

            // Retrieve StandardGradeBook from the harddrive.
            var actual = BaseGradeBook.Load("LoadTest");
            File.Delete("LoadTest.gdbk");
            Assert.True(actual.GetType() == rankedGradeBook || actual == null, "`GradeBook.GradeBooks.BaseGradeBook.Load` didn't return a `RankedGradeBook` when `Type` was `Ranked`.");
        }

        /// <summary>
        ///     All tests related to the "Handle Invalid Types" task.
        /// </summary>
        [Fact(DisplayName = "Handle Invalid Types @handle-invalid-types")]
        public void HandleInvalidTypesTests()
        {
            // Get the GradeBookType Enum
            var gradebookEnum = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                 from type in assembly.GetTypes()
                                 where type.FullName == "GradeBook.Enums.GradeBookType"
                                 select type).FirstOrDefault();

            // Get the StandardGradeBook Class.
            var standardGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                   from type in assembly.GetTypes()
                                   where type.Name == "StandardGradeBook"
                                   select type).FirstOrDefault();

            // Get StandardGradeBook's constructor
            var constructor = standardGradeBook.GetConstructors().FirstOrDefault();

            // Instantiate StandardGradeBook
            var parameters = constructor.GetParameters();
            object gradeBook = null;
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                gradeBook = Activator.CreateInstance(standardGradeBook, "LoadTest", true);
            else if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                gradeBook = Activator.CreateInstance(standardGradeBook, "LoadTest");

            // Set Type to ESNU
            gradeBook.GetType().GetProperty("Type").SetValue(gradeBook, Enum.Parse(gradebookEnum, "ESNU", true));

            // Save the ESNUGradeBook to the harddrive for retrieval
            try
            {
                using (var file = new FileStream("LoadTest.gdbk", FileMode.Create, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        var json = JsonConvert.SerializeObject(gradeBook);
                        writer.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.True(ex != null, "Test for GradeBook.GradeBooks.BaseGradeBook.Load was unable to run. This is likely due to issues being able to read/write gradebook files to the local file system.");
            }

            // Retrieve StandardGradeBook from the harddrive.
            var actual = BaseGradeBook.Load("LoadTest");
            File.Delete("LoadTest.gdbk");
            Assert.True(actual.GetType() == standardGradeBook || actual == null, "`GradeBook.GradeBooks.BaseGradeBook.Load` didn't return a `StandardGradeBook` when `Type` wasn't `Standard` or `Ranked`.");
        }
    }
}
