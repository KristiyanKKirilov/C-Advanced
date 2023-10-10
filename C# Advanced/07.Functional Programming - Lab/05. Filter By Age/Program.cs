using System;

namespace _05._Filter_By_Age
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

                Person person = new Person(name, age);

                if (!people.Contains(person))
                {
                    people.Add(person);
                }
            }

            string status = Console.ReadLine();
            int ageBorder = int.Parse(Console.ReadLine());
            string filter = Console.ReadLine();

            switch (filter)
            {
                case "name":

                    if (status == "older")
                    {
                        foreach (Person person in people)
                        {
                            if (person.Age >= ageBorder)
                            {
                                Console.WriteLine($"{person.Name}");
                            }
                        }
                    }
                    else
                    {
                        foreach (Person person in people)
                        {
                            if (person.Age < ageBorder)
                            {
                                Console.WriteLine($"{person.Name}");
                            }
                        }
                    }
                    break;

                case "age":

                    if (status == "older")
                    {
                        foreach (Person person in people)
                        {
                            if (person.Age >= ageBorder)
                            {
                                Console.WriteLine($"{person.Age}");
                            }
                        }
                    }
                    else
                    {
                        foreach (Person person in people)
                        {
                            if (person.Age < ageBorder)
                            {
                                Console.WriteLine($"{person.Age}");
                            }
                        }
                    }
                    break;

                case "name age":

                    if (status == "older")
                    {
                        foreach (Person person in people)
                        {
                            if (person.Age >= ageBorder)
                            {
                                Console.WriteLine($"{person.Name} - {person.Age}");
                            }
                        }
                    }
                    else
                    {
                        foreach (Person person in people)
                        {
                            if (person.Age < ageBorder)
                            {
                                Console.WriteLine($"{person.Name} - {person.Age}");
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }



    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }   

        public string Name { get; set; }
        public int Age { get; set; }
    }
}

