using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get => radius; private set => radius = value; }
        public override double CalculateArea()
            => Math.PI * radius * radius;

        public override double CalculatePerimeter()
            => 2 * Math.PI * radius;

        public virtual string Draw() => $"Drawing {this.GetType().Name}";
    }
}
