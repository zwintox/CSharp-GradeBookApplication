using System.Reflection;
using System;
using System.Collections.Generic;
using Xunit;

using GradeBook;
using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBookTests
{
    public class RankedGradeBookTests
    {
        [Fact]
        public void ConstructorTest()
        {
            var rankedGradeBook = Type.GetType("GradeBook.GradeBooks.RankedGradeBook");
            if (rankedGradeBook == null)
                throw new Exception("GradeBook.GradeBooks.RankedGradeBook doesn't exist.");
            object gradeBook = Activator.CreateInstance(rankedGradeBook, "Test GradeBook", true);
            
            Assert.True((string)gradeBook.GetType().GetProperty("Name").GetValue(gradeBook) == "Test GradeBook");
            //Assert.True(gradeBook.GetType().GetProperty("Type") == GradeBookType.Ranked);
        }

        //[Fact]
        //public void GetLetterGradeThrowsExceptionOnNotEnoughStudentsTest()
        //{
        //    var gradeBook = new RankedGradeBook("Test GradeBook", true);
        //    var student = new Student("jamie", StudentType.Standard, EnrollmentType.Campus);
        //    Assert.Throws(typeof(InvalidOperationException), () => gradeBook.GetLetterGrade(100));
        //}

        //[Fact]
        //public void GetLetterGradeATest()
        //{
        //    var gradeBook = new RankedGradeBook("Test GradeBook", true)
        //    {
        //        Students =  new List<Student>
        //        {
        //            new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 100 }
        //            },
        //            new Student("john",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 75 }
        //            },
        //            new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 50 }
        //            },
        //            new Student("tom",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 25 }
        //            },
        //            new Student("tony",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 0 }
        //            }
        //        }
        //    };

        //    var expected = 'A';
        //    var actual = gradeBook.GetLetterGrade(100);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeBTest()
        //{
        //    var gradeBook = new RankedGradeBook("Test GradeBook", true)
        //    {
        //        Students = new List<Student>
        //        {
        //            new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 100 }
        //            },
        //            new Student("john",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 75 }
        //            },
        //            new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 50 }
        //            },
        //            new Student("tom",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 25 }
        //            },
        //            new Student("tony",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 0 }
        //            }
        //        }
        //    };

        //    var expected = 'B';
        //    var actual = gradeBook.GetLetterGrade(75);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeCTest()
        //{
        //    var gradeBook = new RankedGradeBook("Test GradeBook", true)
        //    {
        //        Students = new List<Student>
        //        {
        //            new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 100 }
        //            },
        //            new Student("john",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 75 }
        //            },
        //            new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 50 }
        //            },
        //            new Student("tom",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 25 }
        //            },
        //            new Student("tony",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 0 }
        //            }
        //        }
        //    };

        //    var expected = 'C';
        //    var actual = gradeBook.GetLetterGrade(50);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeDTest()
        //{
        //    var gradeBook = new RankedGradeBook("Test GradeBook", true)
        //    {
        //        Students = new List<Student>
        //        {
        //            new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 100 }
        //            },
        //            new Student("john",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 75 }
        //            },
        //            new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 50 }
        //            },
        //            new Student("tom",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 25 }
        //            },
        //            new Student("tony",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 0 }
        //            }
        //        }
        //    };

        //    var expected = 'D';
        //    var actual = gradeBook.GetLetterGrade(25);
        //    Assert.True(expected == actual);
        //}

        //[Fact]
        //public void GetLetterGradeFTest()
        //{
        //    var gradeBook = new RankedGradeBook("Test GradeBook", true)
        //    {
        //        Students = new List<Student>
        //        {
        //            new Student("jamie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 100 }
        //            },
        //            new Student("john",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 75 }
        //            },
        //            new Student("jackie",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 50 }
        //            },
        //            new Student("tom",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 25 }
        //            },
        //            new Student("tony",StudentType.Standard,EnrollmentType.Campus)
        //            {
        //                Grades = new List<double>{ 0 }
        //            }
        //        }
        //    };

        //    var expected = 'F';
        //    var actual = gradeBook.GetLetterGrade(0);
        //    Assert.True(expected == actual);
        //}
    }
}
