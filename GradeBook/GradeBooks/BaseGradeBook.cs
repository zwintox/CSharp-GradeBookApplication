using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public abstract class BaseGradeBook
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public bool IsWeighted { get; set; }
        public GradeBookType Type { get; set; }

        protected BaseGradeBook(string name, bool isWeighted)
        {
            Name = name;
            IsWeighted = isWeighted;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
                throw new ArgumentException("A Name is required to add a student to a gradebook.");
            Students.Add(student);
        }
        public void RemoveStudent(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to remove a student from a gradebook.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("student " + name + " was not found, try again.");
                return;
            }
            Students.Remove(student);
        }
        public void AddGrade(string name, double score)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to add a grade to a student.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("student " + name + " was not found, try again.");
                return;
            }
            student.AddGrade(score);
        }
        public void RemoveGrade(string name, double score)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("A Name is required to remove a grade from a student.");
            var student = Students.FirstOrDefault(e => e.Name == name);
            if (student == null)
            {
                Console.WriteLine("student " + name + " was not found, try again.");
                return;
            }
            student.RemoveGrade(score);
        }
        public void ListStudents()
        {
            foreach(var student in Students)
            {
                Console.WriteLine(student.Name + " : " + student.Type + " : " + student.Enrollment);
            }
        }
        public static BaseGradeBook Load(string name)
        {
            if(!File.Exists(name + ".gdbk"))
            {
                Console.WriteLine("Gradebook could not be found.");
                return null;
            }

            using (var file = new FileStream(name + ".gdbk", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(file))
                {
                    BaseGradeBook gradebook;
                    var json = reader.ReadToEnd();
                    var jobject =  JsonConvert.DeserializeObject<JObject>(json);
                    var type = Enum.Parse(typeof(GradeBookType), jobject.GetValue("Type").ToString(), true);
                    switch(type)
                    {
                        case GradeBookType.Standard:
                            gradebook = JsonConvert.DeserializeObject<StandardGradeBook>(json);
                            break;
                        case GradeBookType.Ranked:
                            gradebook = JsonConvert.DeserializeObject<RankedGradeBook>(json);
                            break;
                        default:
                            throw new ArgumentException("The specified gradebook appears to be corrupted.");
                    }
                    return gradebook;
                }
            }
        }
        public void Save()
        {
            using (var file = new FileStream(Name + ".gdbk", FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this);
                    writer.Write(json);
                }
            }
        }
        public abstract double GetGPA(char letterGrade, bool isWeighted, StudentType studentType);
        public abstract char GetLetterGrade(double averageGrade);
        public abstract void CalculateStatistics();
        public abstract void CalculateStudentStatistics(string name);
    }
}
