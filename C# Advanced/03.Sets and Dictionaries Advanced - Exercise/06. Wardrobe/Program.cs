using System;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();
            int numberLineOfClothes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLineOfClothes; i++)
            {

                string[] clothesByColor = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = clothesByColor[0];

                if (!colors.ContainsKey(color))
                {
                    colors.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < clothesByColor.Length; j++)
                {
                    string currentClothing = clothesByColor[j];

                    if (!colors[color].ContainsKey(currentClothing))
                    {
                        colors[color].Add(currentClothing, 0);
                    }
                    colors[color][currentClothing]++;

                }

            }
            string[] searchedItem = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searchedItem[0];
            string searchedClothing = searchedItem[1];

            foreach (var (currentColor, currentItem) in colors)
            {
                Console.WriteLine($"{currentColor} clothes:");

                foreach (var (item, count) in currentItem)
                {

                    if (searchedColor == currentColor && searchedClothing == item)
                    {
                        Console.WriteLine($"* {item} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item} - {count}");
                    }

                }
            }
        }
    }
}