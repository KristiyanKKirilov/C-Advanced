using System.Reflection;

namespace GetFieldInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(CustomClass);
            PropertyInfo[] properties = type.GetProperties((BindingFlags)60);
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
                Console.WriteLine(property.PropertyType.Name);
                Console.WriteLine("-----"); 
                
            }
        }
    }
}