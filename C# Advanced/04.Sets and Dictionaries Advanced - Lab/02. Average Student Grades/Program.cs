using System;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new();
            int numberOfStudents = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());                    
                }
               
                    students[studentName].Add(grade);
                
                
            }
            foreach (var student in students)
            {
                                          
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x=>string.Format($"{x:F2}")))} (avg: {student.Value.Average():f2})");
                
            }
        }
    }
}