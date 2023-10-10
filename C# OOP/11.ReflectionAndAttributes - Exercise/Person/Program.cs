using System;
using System.Reflection;

namespace Person
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Person);
            Person instance = Activator.CreateInstance(type, "das", 112) as Person;
            FieldInfo field = type.GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo method = type.GetMethod("GetAge", (BindingFlags)60);
            field.SetValue(instance, 11);
            //Console.WriteLine(instance.GetAge());
            object result = method.Invoke(instance, new object[] { 12});
            Console.WriteLine(result);
        }
    }

    public class Person 
    {
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            this.age = age;
        }
        public string Name { get; set; }

        public int GetAge(int ageCurr) => ageCurr;
    }

}