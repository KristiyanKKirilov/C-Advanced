namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader read = new(inputFilePath))
            {
                int count = 0;               
                StringBuilder sb = new();

                while (!read.EndOfStream)
                {
                    string line = read.ReadLine();
                    if (count % 2 == 0)
                    {                        
                        string replacedLine = ReplaceSymbols(line);
                        string reversedLine = ReversedSymbols(replacedLine);
                        sb.AppendLine(reversedLine);                       
                    }
                    count++;
                }
                return sb.ToString();
            }

        }
        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new(line);
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (var symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }
            return sb.ToString();
        }
        private static string ReversedSymbols(string replacedLine)
        {
            StringBuilder sb = new();
            string[] reversedLine = replacedLine
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            sb.Append(string.Join(' ', reversedLine));
            return sb.ToString();
            
        }

        
    }
}
