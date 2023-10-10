namespace ClothesMagazine
{
    public class Cloth
    {
        private string color;
        private int size;
        private string type;
        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size;
            Type = type;
        }
        public string Color 
        { 
            get => color; 
            set => color = value; 
        }
        public int Size 
        {
            get => size;
            set => size = value;
        }
        public string Type 
        {
            get => type;
            set => type = value;
        }

        public override string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }
    }
}
