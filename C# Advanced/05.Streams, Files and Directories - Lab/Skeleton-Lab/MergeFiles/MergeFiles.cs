namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstInput = new StreamReader(firstInputFilePath))
            {
                HashSet<string> symbols = new();

                HashSetFilling(symbols, firstInput);

                using (StreamReader secondInput = new(secondInputFilePath))
                {
                    HashSetFilling(symbols, secondInput);

                    using (StreamWriter outputFile = new(outputFilePath))
                    {
                        foreach (var symbol in symbols.OrderBy(x=>x))
                        {
                            outputFile.WriteLine(symbol);
                        }                        
                    }
                }
            }

        }
        public static HashSet<string> HashSetFilling(HashSet<string> symbols, StreamReader input)
        {
            while(!input.EndOfStream)
            { 
                string currentSymbol = input.ReadLine();
                if (!symbols.Contains(currentSymbol))
                {
                    symbols.Add(currentSymbol);
                }
            }
            return symbols;
        }
    }
}
