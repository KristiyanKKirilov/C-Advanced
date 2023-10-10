using System;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    Town = tokens[2]
                };
                people.Add(person);

            }
            int indexPerson = int.Parse(Console.ReadLine()) - 1;
            int matches = 0;
            int notMatches = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].CompareTo(people[indexPerson]) == 0)
                {
                    matches++;
                }
                else
                {
                    notMatches++;
                }
            }
            if (matches > 1)
            {
                Console.WriteLine($"{matches} {notMatches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}