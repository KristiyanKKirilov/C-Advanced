using System;

namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                Name = "Vich"
            };
            Console.WriteLine(student.Name);
        }
    }
    public class Student
    {
        private string name;

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            { 
                this.name = value; 
            }
        }
    }
}