using Newtonsoft.Json;
using System;

namespace JsonSerialiseExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new();
            Student student = new("Ivo", 11);
            Student student2 = new("Ivo12", 12);
            students.Add(student);
            students.Add(student2);
            Console.WriteLine(JsonConvert.SerializeObject(students));
            string format = "[{\"Name\":\"Ivo\",\"Age\":11},{\"Name\":\"Ivo12\",\"Age\":12}]";
            //using (StreamWriter writer = new("../../../student-db.txt"))
            //{
            //    writer.WriteLine($"Name: {student.Name} - Age: {student.Age}");
            //}
            List<Student> newStudents = JsonConvert.DeserializeObject<List<Student>>(format);
            Console.WriteLine(newStudents.Count);

        }
    }

    public class Student
    {

        public Student(string name, int age)
        {
            Name= name;
            Age= age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}