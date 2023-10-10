using System;
namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new (4, 2);
            Console.WriteLine(triangle.Area());
        }
    }
    class Figure
    {
        public Figure()
        {

        }
        public Figure(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public virtual int Area()
        {
            return Width * Height;
        }
    }
    class Rectangle : Figure
    {
        public Rectangle()
        {

        }
        public Rectangle(int width, int height, string color) : base(width, height)
        {
            Color = color;
        }
        public string Color { get; set; }
    }
    class Square : Rectangle
    {
        public Square()
        {

        }
        public Square(int width, int height, string color) : base(width, height, color)
        {

        }
    }
    class Triangle : Figure
    {
        public Triangle(int width, int height) : base(width, height)
        {

        }
        public override int Area()
        {
            return Width * Height / 2;
        }
    }
   
}