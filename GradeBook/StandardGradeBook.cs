using System;
using System.Linq;

namespace GradeBook
{
    public class StandardGradeBook : GradeBook
    {
        public StandardGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Standard;
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

            foreach(var student in Students)
            {
                student.LetterGrade = GetLetterGrade(student.AverageGrade);
                Console.WriteLine(student.Name + " (" + student.LetterGrade + ":" + student.AverageGrade + "): No Weighted Grade.");
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
            Console.WriteLine("Average Grade of all students is " + (allStudentsPoints/Students.Count));
            Console.WriteLine("Average for only local students is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.Campus).Count()));
            Console.WriteLine("Average for only state students (excluding local) is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.State).Count()));
            Console.WriteLine("Average for only national students (excluding state and local) is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.National).Count()));
            Console.WriteLine("Average for only international students is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.International).Count()));
            Console.WriteLine("Average for students excluding honors and duel enrollment is " + (standardPoints / Students.Where(e => e.Type == StudentType.Standard).Count()));
            Console.WriteLine("Average for only honors students is " + (honorPoints / Students.Where(e => e.Type == StudentType.Honors).Count()));
            Console.WriteLine("Average for only duel enrolled students is " + (duelEnrolledPoints / Students.Where(e => e.Type == StudentType.DuelEnrolled).Count()));
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 90)
                return 'A';
            else if (averageGrade >= 80)
                return 'B';
            else if (averageGrade >= 70)
                return 'C';
            else if (averageGrade >= 60)
                return 'D';
            else
                return 'F';
        }
    }
}
