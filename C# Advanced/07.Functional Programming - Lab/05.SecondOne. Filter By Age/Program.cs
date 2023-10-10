using System;

namespace _05.SecondOne._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person()
                {
                    Name = name,
                    Age = age,

                };
                //people.Add(new Person() { Name = name, Age = age });

                if (!people.Contains(person))
                {
                    people.Add(person);
                }
            }

            string status = Console.ReadLine();
            int ageBorder = int.Parse(Console.ReadLine());
            string filter = Console.ReadLine();

            Func<Person, bool> filterType = GetFilter(status, ageBorder);

            people = people.Where(filterType).ToList();

            Action<Person> printer = Printer(filter);

            foreach (var person in people)
            {
                printer(person);
            }


        }
        static Func<Person, bool> GetFilter(string status, int ageBorder)
        {
            switch (status)
            {
                case "older": return person => person.Age >= ageBorder;
                case "younger": return person => person.Age < ageBorder;
                default:
                    return null;
            }
        }

        static Action<Person> Printer(string filter)
        {
            switch (filter)
            {
                case "name age":
                    return person => Console.WriteLine($"{person.Name} - {person.Age}");
                case "name":
                    return person => Console.WriteLine($"{person.Name}");
                case "age":
                    return person => Console.WriteLine($"{person.Age}");
                default:
                    return null;
            }
        }
    }


    public class Person
    {
        public Person() { }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}

