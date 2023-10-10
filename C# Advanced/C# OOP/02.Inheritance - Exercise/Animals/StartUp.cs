using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                //input
                string animalType = input;
                string[] animalTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalTokens[0];
                int age = int.Parse(animalTokens[1]);
                string gender = animalTokens[2];
                try
                {
                    switch (animalType)
                    {

                        case "Dog":
                            Dog dog = new(name, age, gender);
                            Add(animals, dog);
                            break;
                        case "Cat":
                            Cat cat = new(name, age, gender);
                            Add(animals, cat);
                            break;
                        case "Frog":
                            Frog frog = new(name, age, gender);
                            Add(animals, frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new(name, age);
                            Add(animals, kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(name, age);
                            Add(animals, tomcat);
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            foreach (var animal in animals)
            {
                string type = animal.GetType().Name;
                Console.WriteLine(type);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ProduceSound());
            }
        }
        public static void Add(List<Animal> animals, Animal animal)
        {
            animals.Add(animal);
        }

    }
}
