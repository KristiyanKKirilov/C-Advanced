using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class CustomEnumerator:IEnumerator<Student>
    {
        private int index = -1;
        private List<Student> students;

        public CustomEnumerator(List<Student> students)        {
            
            this.students = students;
        }

        public Student Current => students[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            index++;
            return index < students.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
