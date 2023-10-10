using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFieldInfo
{
    public class CustomClass
    {
        private string name;
        public string family = "Fikovi";
        internal string nonstop;
        protected string intersive;
        private static string nameless;

        public int PublicProp { get; set; }
        private string PrivateProp { get; set; }
    }
}
