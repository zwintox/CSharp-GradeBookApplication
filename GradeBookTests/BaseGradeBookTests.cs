using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GradeBookTests
{
    public class BaseGradeBookTests
    {
        [Fact]
        public void BaseGradeContainsIsWeightedTest()
        {
            var baseGradeBook = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from type in assembly.GetTypes()
                                     where type.Name == "BaseGradeBook"
                                     select type).FirstOrDefault();

            Assert.True(baseGradeBook.GetProperty("IsWeighted").PropertyType.ToString() == "System.Boolean", "GradeBook.GradeBooks.BaseGradeBook.Load does not have a public property `IsWeighted` of type `bool`.");
        }
    }
}
