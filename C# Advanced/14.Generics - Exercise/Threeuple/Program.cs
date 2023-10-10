using System;
using Threeuple;

namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] nameTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] drinkTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] bankTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CustomThreeuple<string, string, string> nameAdresssTown = new($"{nameTokens[0]} {nameTokens[1]}", nameTokens[2], string.Join(' ', nameTokens[3..]));
            CustomThreeuple<string, int, bool> drinking = new(drinkTokens[0], int.Parse(drinkTokens[1]), drinkTokens[2] == "drunk");
            CustomThreeuple<string, double, string> nameBalanceBank = new(bankTokens[0], double.Parse(bankTokens[1]), bankTokens[2]);

            Console.WriteLine(nameAdresssTown.ToString());
            Console.WriteLine(drinking.ToString());
            Console.WriteLine(nameBalanceBank.ToString());
        }
    }
}