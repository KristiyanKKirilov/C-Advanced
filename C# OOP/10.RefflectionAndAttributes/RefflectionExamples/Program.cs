using System;
using System.Reflection;
using System.Text;

namespace RefflectionExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type typeRobot = typeof(Robot);
            StringBuilder sb = GetInstance<StringBuilder>();
            Robot robot = GetInstance<Robot>();
            Console.WriteLine(robot.Name);

            return;
            Type listType = typeof(List<int>);
            Type[] interfaces = listType.GetInterfaces();
            foreach (Type interfaceType in interfaces)
            {
                PrintInfo(interfaceType);
            }

            
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Console.WriteLine($"Classes count: {types.Length - 1}");
            foreach (Type type in types)
            {
                if (type.Name == "Program")
                {
                    continue;
                }
                Console.WriteLine(type.Name);
            }
        }
        static void PrintInfo(Type type)
        {
            
            Console.WriteLine(type.Name);
            Console.WriteLine("------");
        }
        static T GetInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T).GetType());
        }
    }
    public class Robot
    {
        public Robot()
        {
            Name = "RobotBoy";
        }
        public string Name { get; set; }
    }
}