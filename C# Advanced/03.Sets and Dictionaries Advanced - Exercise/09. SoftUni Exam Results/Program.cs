using System;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> contestors = new();
            Dictionary<string, int> languageSubmissions = new();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] contestorData = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = contestorData[0];


                if (contestors.ContainsKey(username) && contestorData[1] == "banned")
                {
                    contestors.Remove(username);
                    continue;
                }

                string language = contestorData[1];
                int points = int.Parse(contestorData[2]);

                if (points > 100)
                {
                    continue;
                }

                if (!contestors.ContainsKey(username))
                {
                    contestors.Add(username, points);
                }
                               
                if (points > contestors[username])
                {
                    contestors[username] = points;
                }

                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions.Add(language, 0);
                }
                languageSubmissions[language]++;

            }

            Console.WriteLine("Results:");

            foreach (var contestor in contestors.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{contestor.Key} | {contestor.Value}");
            }
            Console.WriteLine("Submissions:");

            foreach (var language in languageSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }    
}