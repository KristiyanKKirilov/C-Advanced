using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        private List<Cloth> clothes;
        private string type;
        private int capacity;

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            clothes = new();
        }
        public List<Cloth> Clothes 
        {
            get => clothes; 
            set=> clothes = value;
        }
        public string Type
        {
            get => type;
            set => type = value;
        }
        public int Capacity
        {
            get => capacity;
            set => capacity = value;
        }
        public void AddCloth(Cloth cloth)
        {
            if(Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }
        public bool RemoveCloth(string color)
        {
            Cloth currentCloth = Clothes.FirstOrDefault(c => c.Color == color);
            if(currentCloth is null)
            {
                return false;
            }
            Clothes.Remove(currentCloth);
            return true;
        }
        public Cloth GetSmallestCloth()
        {
            int minSize= int.MaxValue;
            foreach (var clothing in Clothes)
            {
                if(clothing.Size < minSize)
                {
                    minSize = clothing.Size;
                }
            }
            Cloth cloth = Clothes.FirstOrDefault(c => c.Size == minSize);
            return cloth;
        }
        public Cloth GetCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(c => c.Color == color);
            return cloth;
        }
        public int GetClothCount() => Clothes.Count;
        public string Report()
        {
            Clothes = Clothes.OrderBy(c => c.Size).ToList();
            StringBuilder sb = new();
            sb.AppendLine($"{Type} magazine contains:");
            sb.AppendLine(string.Join(Environment.NewLine, Clothes));
            return sb.ToString().TrimEnd();

        }
    }
}
