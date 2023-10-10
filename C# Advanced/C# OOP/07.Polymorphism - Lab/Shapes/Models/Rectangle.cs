using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height { get => height; private set => height = value; }
        public double Width { get => width; private set => width = value; }
        public override double CalculateArea() => Width * Height;

        public override double CalculatePerimeter() => 2 * (Width + Height);

        public virtual string Draw() => $"Drawing {this.GetType().Name}";
    }
}
