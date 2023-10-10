using System;

namespace EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new();
            SortedSet<Person> sortedPeople = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1])
                };
                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}