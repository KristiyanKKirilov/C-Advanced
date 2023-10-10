using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new ();                         

            for (int i = 0; i < n; i++)
            {                
                string[] personInfo = Console.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new(name, age);                         
                family.AddMember(person);                
            }

            foreach (Person familyMember in family.People.OrderBy(p=>p.Name))
            {
                if(familyMember.Age > 30)
                {
                    Console.WriteLine($"{familyMember.Name} - {familyMember.Age}");
                }                
            }

           
            
        }
    }
}