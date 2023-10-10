namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new();
            
            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int lettersCount = currentLine.Count(char.IsLetter);
                int punctuationsCount = currentLine.Count(char.IsPunctuation);
                sb.AppendLine($"Line {i + 1}: {currentLine} ({lettersCount})({punctuationsCount})");
            }
            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
