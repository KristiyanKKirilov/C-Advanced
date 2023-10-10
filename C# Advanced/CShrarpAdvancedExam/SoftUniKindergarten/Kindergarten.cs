using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private string name;
        private int capacity;
        private List<Child> registry;


        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<Child> Registry
        {
            get { return registry; }
            set { registry = value; }
        }
        public int ChildrenCount { get => Count(); }
        public bool AddChild(Child child)
        {
            if(Registry.Count < Capacity)
            {
               Registry.Add(child);
                return true;
            }
            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            Child child = Registry.FirstOrDefault(c => c.FirstName + " " + c.LastName == childFullName);
            if(child is null)
            {
                return false;
            }

            Registry.Remove(child);
            return true;
        }
        public int Count() => Registry.Count;

        public Child GetChild(string childFullName)
        {
            Child child = Registry.FirstOrDefault(c => c.FirstName + " " + c.LastName == childFullName);

            if (child is null)
            {
                return null;
            }

            return child;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry.OrderByDescending(c => c.Age).ThenBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
           
            return sb.ToString().TrimEnd();
        }

    }
}
