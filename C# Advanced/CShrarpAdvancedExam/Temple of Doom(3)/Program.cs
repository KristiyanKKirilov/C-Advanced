namespace Temple_of_Doom
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] tools = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] substances = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            List<int> challenges = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            Queue<int> toolQueue = new(tools);
            Stack<int> substanceStack = new(substances);
            

            while (true)
            {
                if (!toolQueue.Any() && challenges.Any())
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
                if (!substanceStack.Any() && challenges.Any())
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
                if (!challenges.Any())
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;
                }
                int currentTool = toolQueue.Dequeue();
                int currentSubstance = substanceStack.Pop();
                int sum = currentTool * currentSubstance;
                if (challenges.Contains(sum))
                {
                    challenges.Remove(sum);
                }
                else
                {
                    currentTool += 1;
                    int[] newQueue = toolQueue.ToArray();
                    toolQueue.Clear();
                    foreach (var item in newQueue)
                    {
                        toolQueue.Enqueue(item);
                    }
                    toolQueue.Enqueue(currentTool);

                    currentSubstance -= 1;
                    if (currentSubstance > 0)
                    {
                        substanceStack.Push(currentSubstance);
                    }
                }
            }
            if (toolQueue.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", toolQueue)}");
            }
            if (substanceStack.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substanceStack)}");
            }
            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}