namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                string words = reader.ReadLine();
                List<string> splittedWords = words.Split(' ').ToList();

                using (StreamReader text = new StreamReader(textFilePath))
                {
                    Dictionary<string, int> wordFounded = new Dictionary<string, int>();


                    while (!text.EndOfStream)
                    {
                        string line = text.ReadLine().ToLower();
                        string[] currentWords = line.Split(new char[] { ',', '.', '/', '(', ')', '!', '?', '-', ';', ':', '"', ' ' });

                        
                        foreach (var word in splittedWords)
                        {
                            if (!wordFounded.ContainsKey(word))
                            {
                                wordFounded.Add(word, 0);   
                            }

                            for (int i = 0; i < currentWords.Length; i++)
                            {
                                if (currentWords[i] == word)
                                {
                                    wordFounded[word]++;
                                }
                            }
                        }
                    }
                    using (StreamWriter write = new StreamWriter(outputFilePath))
                    {
                        foreach (var (currentWord, numberCount) in wordFounded.OrderByDescending(x=>x.Value))
                        {
                            write.WriteLine($"{currentWord} - {numberCount}");
                        }
                    }
                }
            }
        }
    }
}
