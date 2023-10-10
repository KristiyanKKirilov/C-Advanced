using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class Student
    {
        private string name;
        private int age;
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age {
            get
            {
                return age;
            }
            set
            {
                this.age = value;
            }
        }

        
    }
}
