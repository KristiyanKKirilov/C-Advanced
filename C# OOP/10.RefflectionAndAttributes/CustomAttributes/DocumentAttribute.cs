using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DocumentAttribute : Attribute
    {
        public DocumentAttribute()
        {
            Color = ConsoleColor.Red;
        }
        public DocumentAttribute(bool isCritical)
        {
            IsCritical = isCritical;
        }
        public bool IsCritical { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
