using System;

namespace CustomEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftUni uni = new SoftUni();
            uni.AddStudent(new Student("Ivan", 15));
            uni.AddStudent(new Student("Blago", 15));

            foreach (var student in uni)
            {
                Console.WriteLine($"Student Name -> {student.Name} : Student Age -> {student.Age}");
            }
        }
    }
}