using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeBook
{
    public abstract class GradeBook
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public bool IsWeighted { get; set; }
        public GradeBookType Type { get; set; }

        protected GradeBook(string name, bool isWeighted)
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
            Students.Remove(student);
        }
        public void AddGrade(string name, double score)
        {
            var student = Students.FirstOrDefault(e => e.Name == name);
            student.AddGrade(score);
        }
        public void RemoveGrade(string name, double score)
        {
            var student = Students.FirstOrDefault(e => e.Name == name);
            student.RemoveGrade(score);
        }
        public static GradeBook Load(string name)
        {
            using (var file = new FileStream(name + ".gdbk", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(file))
                {
                    GradeBook gradebook;
                    var json = reader.ReadToEnd();
                    var jobject =  JsonConvert.DeserializeObject<JObject>(json);
                    var type = Enum.Parse(typeof(GradeBookType), jobject.GetValue("Type").ToString(), true);
                    switch(type)
                    {
                        case GradeBookType.Standard:
                            gradebook = JsonConvert.DeserializeObject<StandardGradeBook>(json);
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
        public abstract char GetLetterGrade(double averageGrade);
        public abstract void CalculateStatistics();
    }
}
