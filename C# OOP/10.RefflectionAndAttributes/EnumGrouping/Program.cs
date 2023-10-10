using System;
using System.Reflection;

namespace EnumGrouping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Day day = Day.Monday | Day.Tuesday | Day.Sunday;
            //    Day day = (Day)134;
            //    Console.WriteLine(day.HasFlag(Day.Tuesday));
            //    Console.WriteLine(day);
            //}
            //enum Day
            //{
            //    Monday = 2,
            //    Tuesday = 4,
            //    Wednesday = 8,
            //    Thursday = 16,
            //    Friday = 32,
            //    Saturday = 64,
            //    Sunday = 128,
            //}


            //Type type = typeof(Human);
            //FieldInfo field = type.GetField("name", (BindingFlags)60);
            //Human human = new();
            //Human human2 = new("human2");
            //field.SetValue(human, "human1");
            //Console.WriteLine(field.GetValue(human));
            //Console.WriteLine(field.GetValue(human2));

            Type type = typeof(Human);
            ConstructorInfo[] constructorInfos= type.GetConstructors();
            Human human = (Human)constructorInfos[0].Invoke(new object[] { });
            Human human2 = (Human)constructorInfos[1].Invoke(new object[] {"Harry" });
            foreach (ConstructorInfo constructorInfo in constructorInfos)
            {
                Console.WriteLine(constructorInfo.Name);
                ParameterInfo[] parameters = constructorInfo.GetParameters();
                Console.WriteLine(parameters.Length);
                foreach (ParameterInfo parameter in parameters)
                {
                    Console.WriteLine(parameter.Name);
                    Console.WriteLine(parameter.ParameterType.Name);
                }
                Console.WriteLine("------");
            }

        }

    }
    class Human
    {
        private string name = "ivash";
        public Human()
        {

            
        }
        public Human(string name)
        {
            this.name = name;
        }
    }
}