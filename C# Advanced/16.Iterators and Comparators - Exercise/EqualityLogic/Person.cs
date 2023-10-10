using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }       

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result != 0)
            {
                return result;

            }
            return Age.CompareTo(other.Age);
            
        }
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if(other == null)
            {
                return false;
            }
            return Name == other.Name && Age == other.Age;
        }
        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode() + Age.GetHashCode();
            return hashCode;
        }     
    }
}
