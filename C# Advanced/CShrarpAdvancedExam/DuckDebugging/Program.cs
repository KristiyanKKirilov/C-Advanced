
using System.Reflection.PortableExecutable;
using System.Text;

namespace DuckDebugging
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int darthVaderDucky = 0;
            int thorDucky = 0;
            int bigBlueRubberDucky = 0;
            int smallYellowRubberDucky = 0;

            int[] programNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] timeNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> programNumbersQueue = new(programNumbers);
            Stack<int> timeNumbersStack = new(timeNumbers);

            while (programNumbersQueue.Any() && timeNumbersStack.Any())
            {
                int currentProgram = programNumbersQueue.Peek();
                int currentTime = timeNumbersStack.Peek();
                int sum = Sum(currentProgram, currentTime);
                if (sum >= 0 && sum <= 60)
                {
                    darthVaderDucky++;
                    Removing(programNumbersQueue, timeNumbersStack);

                }
                else if (sum >= 61 && sum <= 120)
                {
                    thorDucky++;
                    Removing(programNumbersQueue, timeNumbersStack);
                }
                else if (sum >= 121 && sum <= 180)
                {
                    bigBlueRubberDucky++;
                    Removing(programNumbersQueue, timeNumbersStack);
                }
                else if (sum >= 181 && sum <= 240)
                {
                    smallYellowRubberDucky++;
                    Removing(programNumbersQueue, timeNumbersStack);
                }
                else if (sum > 240)
                {
                    int number = programNumbersQueue.Dequeue();
                    programNumbersQueue.Enqueue(number);
                    int newNumber = timeNumbersStack.Peek() - 2;
                    timeNumbersStack.Pop();
                    timeNumbersStack.Push(newNumber);
                }

            }

            StringBuilder sb = new();
            sb.AppendLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            sb.AppendLine($"Darth Vader Ducky: {darthVaderDucky}");
            sb.AppendLine($"Thor Ducky: {thorDucky}");
            sb.AppendLine($"Big Blue Rubber Ducky: {bigBlueRubberDucky}");
            sb.AppendLine($"Small Yellow Rubber Ducky: {smallYellowRubberDucky}");
            Console.WriteLine(sb.ToString());

        }

        static int Sum(int currentProgram, int currentTime) => currentProgram * currentTime;
        static void Removing(Queue<int> queue, Stack<int> stack)
        {
            queue.Dequeue();
            stack.Pop();
        }
    }
}