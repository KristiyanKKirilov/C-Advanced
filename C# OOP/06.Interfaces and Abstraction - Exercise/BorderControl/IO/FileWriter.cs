using BorderControl.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../test.txt";
            using StreamWriter sw = new (filePath, true);
            sw.WriteLine(line);
        }
    }
}
