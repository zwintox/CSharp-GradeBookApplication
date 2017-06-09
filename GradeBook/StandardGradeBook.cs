using System;
using System.Linq;

namespace GradeBook
{
    public class StandardGradeBook : GradeBook
    {
        public StandardGradeBook(string name) : base(name)
        {
        }

        public override void CalculateStatistics()
        {
            var allStudentsPoints = 0d;
            var campusPoints = 0d;
            var statePoints = 0d;
            var nationalPoints = 0d;
            var internationalPoints = 0d;

            foreach(var student in Students)
            {
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
            }

            //#todo refactor into it's own method with calculations performed here
            Console.WriteLine("Average Grade of all students is " + (allStudentsPoints/Students.Count));
            Console.WriteLine("Average for only local students is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.Campus).Count()));
            Console.WriteLine("Average for only state students (excluding local) is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.State).Count()));
            Console.WriteLine("Average for only national students (excluding state and local) is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.National).Count()));
            Console.WriteLine("Average for only international students is " + (campusPoints / Students.Where(e => e.Enrollment == EnrollmentType.International).Count()));
        }
    }
}
