namespace ApocalypsePreparation
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] textilesNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] medicamentsNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> textilesQueue = new(textilesNumbers);
            Stack<int> medicamentsStack = new(medicamentsNumbers);

            Dictionary<string, int> items = new();

            while (true)
            {
                if (!textilesQueue.Any() && !medicamentsStack.Any())
                {
                    Console.WriteLine("Textiles and medicaments are both empty.");
                    break;
                }
                if (!textilesQueue.Any())
                {
                    Console.WriteLine("Textiles are empty.");
                    break;
                }
                if (!medicamentsStack.Any())
                {
                    Console.WriteLine("Medicaments are empty.");
                    break;
                }
                int currentTextile = textilesQueue.Dequeue();
                int currentMedicament = medicamentsStack.Pop();

                if (Sum(currentTextile, currentMedicament) == 30)
                {
                    if (!items.ContainsKey("Patch"))
                    {
                        items.Add("Patch", 0);
                    }
                    items["Patch"]++;
                }
                else if (Sum(currentTextile, currentMedicament) == 40)
                {
                    if (!items.ContainsKey("Bandage"))
                    {
                        items.Add("Bandage", 0);
                    }
                    items["Bandage"]++;
                }
                else if (Sum(currentTextile, currentMedicament) == 100)
                {
                    if (!items.ContainsKey("MedKit"))
                    {
                        items.Add("MedKit", 0);
                    }
                    items["MedKit"]++;
                }
                else if (Sum(currentTextile, currentMedicament) > 100)
                {
                    if (!items.ContainsKey("MedKit"))
                    {
                        items.Add("MedKit", 0);
                    }
                    items["MedKit"]++;
                    int sum = Sum(currentTextile, currentMedicament);
                    sum -= 100;
                    int newMedicament = medicamentsStack.Pop() + sum;
                    medicamentsStack.Push(newMedicament);
                }
                else
                {
                    int newMedicament = currentMedicament + 10;
                    medicamentsStack.Push(newMedicament);
                }

            }
            foreach (var (item, count) in items.Where(i => i.Value > 0).OrderByDescending(c => c.Value).ThenBy(i => i.Key))
            {
                Console.WriteLine($"{item} - {count}");
            }
            if (textilesQueue.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textilesQueue)}");
            }

            if (medicamentsStack.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicamentsStack)}");
            }

        }
        static int Sum(int textile, int medicament) => textile + medicament;
    }
}
