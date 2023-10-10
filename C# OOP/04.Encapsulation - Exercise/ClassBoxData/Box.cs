using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length= length;
            Width= width;
            Height= height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return 2 * (Length * Width) + 2 * (Length * Height) + 2 * (Height * Width);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (Length + Width) * Height;
        }
        public double Volume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");            
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");
            return sb.ToString();
        }

    }
}
