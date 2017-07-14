using System;
using System.Linq;

using GradeBook.Enums;

namespace GradeBook
{
    public class RankedGradeBook : GradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            var allStudentsPoints = 0d;
            var campusPoints = 0d;
            var statePoints = 0d;
            var nationalPoints = 0d;
            var internationalPoints = 0d;
            var standardPoints = 0d;
            var honorPoints = 0d;
            var duelEnrolledPoints = 0d;

            foreach (var student in Students)
            {
                student.LetterGrade = GetLetterGrade(student.AverageGrade);
                student.GPA = GetGPA(student.LetterGrade, IsWeighted, student.Type);

                Console.WriteLine(student.Name + " (" + student.LetterGrade + ":" + student.AverageGrade + "): GPA: " + student.GPA + ".");
                allStudentsPoints += student.AverageGrade;

                switch (student.Enrollment)
                {
                    case EnrollmentType.Campus:
                        campusPoints += student.AverageGrade;
                        break;
                    case EnrollmentType.State:
                        statePoints += student.AverageGrade;
                        break;
                    case EnrollmentType.National:
                        nationalPoints += student.AverageGrade;
                        break;
                    case EnrollmentType.International:
                        internationalPoints += student.AverageGrade;
                        break;
                }

                switch (student.Type)
                {
                    case StudentType.Standard:
                        standardPoints += student.AverageGrade;
                        break;
                    case StudentType.Honors:
                        honorPoints += student.AverageGrade;
                        break;
                    case StudentType.DuelEnrolled:
                        duelEnrolledPoints += student.AverageGrade;
                        break;
                }
            }

            //#todo refactor into it's own method with calculations performed here
            Console.WriteLine("Average Grade of all students is " + (allStudentsPoints / Students.Count));
            if (campusPoints != 0)
                Console.WriteLine("Average for only local students is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.Campus).Count()));
            if (statePoints != 0)
                Console.WriteLine("Average for only state students (excluding local) is " + (statePoints / Students.Where(e => e.Enrollment == EnrollmentType.State).Count()));
            if (nationalPoints != 0)
                Console.WriteLine("Average for only national students (excluding state and local) is " + (nationalPoints / Students.Where(e => e.Enrollment == EnrollmentType.National).Count()));
            if (internationalPoints != 0)
                Console.WriteLine("Average for only international students is " + (internationalPoints / Students.Where(e => e.Enrollment == EnrollmentType.International).Count()));
            if (standardPoints != 0)
                Console.WriteLine("Average for students excluding honors and duel enrollment is " + (standardPoints / Students.Where(e => e.Type == StudentType.Standard).Count()));
            if (honorPoints != 0)
                Console.WriteLine("Average for only honors students is " + (honorPoints / Students.Where(e => e.Type == StudentType.Honors).Count()));
            if (duelEnrolledPoints != 0)
                Console.WriteLine("Average for only duel enrolled students is " + (duelEnrolledPoints / Students.Where(e => e.Type == StudentType.DuelEnrolled).Count()));
        }

        public override void CalculateStudentStatistics(string name)
        {
            var student = Students.FirstOrDefault(e => e.Name == name);
            student.LetterGrade = GetLetterGrade(student.AverageGrade);
            student.GPA = GetGPA(student.LetterGrade, IsWeighted, student.Type);

            Console.WriteLine(student.Name + " (" + student.LetterGrade + ":" + student.AverageGrade + "): GPA: " + student.GPA + ".");
            Console.WriteLine();
            Console.WriteLine("Grades:");
            foreach (var grade in student.Grades)
            {
                Console.WriteLine(grade);
            }
        }

        public override double GetGPA(char letterGrade, bool isWeighted, StudentType studentType)
        {
            if (isWeighted)
            {
                switch (studentType)
                {
                    case StudentType.DuelEnrolled:
                    case StudentType.Honors:
                        {
                            switch (letterGrade)
                            {
                                case 'A':
                                    return 5;
                                case 'B':
                                    return 4;
                                case 'C':
                                    return 3;
                                case 'D':
                                    return 2;
                                case 'F':
                                    return 1;
                            }
                            break;
                        }
                }
            }

            switch (letterGrade)
            {
                case 'A':
                    return 4;
                case 'B':
                    return 3;
                case 'C':
                    return 2;
                case 'D':
                    return 1;
                case 'F':
                    return 0;
            }
            return 0;
        }

        public override char GetLetterGrade(double averageGrade)
        {
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
