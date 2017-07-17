using System;
using System.Linq;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Where(e => e.Grades.Count > 0).Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Where(e => e.Grades.Count > 0).Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students in order to provide grades.");
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            var gradeScale = Students.Count()*0.2;

            if (grades[(int)Math.Ceiling(gradeScale)-1] <= averageGrade)
                return 'A';
            else if (grades[(int)Math.Ceiling(gradeScale*2)-1] <= averageGrade)
                return 'B';
            else if (grades[(int)Math.Ceiling(gradeScale*3)-1] <= averageGrade)
                return 'C';
            else if (grades[(int)Math.Ceiling(gradeScale*4)-1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
