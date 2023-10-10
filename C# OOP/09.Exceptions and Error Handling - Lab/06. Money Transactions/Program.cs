using System;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> bank = new();
            string[] bankInfos = Console.ReadLine().Split(',');

            for (int i = 0; i < bankInfos.Length; i++)
            {
                string[] bankPair = bankInfos[i].Split('-');
                int bankId = int.Parse(bankPair[0]);
                double bankBalance = double.Parse(bankPair[1]);
                bank.Add(bankId, bankBalance);
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ');
                string command = tokens[0];
                int id = int.Parse(tokens[1]);
                double sum = double.Parse(tokens[2]);

                try
                {
                                     
                    switch (command)
                    {
                        case "Deposit":
                            bank[id] += sum;
                            break;
                        case "Withdraw":
                            if (sum > bank[id])
                            {
                                throw new ArgumentNullException("", "Insufficient balance!");
                            }
                            bank[id] -= sum;
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {id} has new balance: {bank[id]:f2}");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(KeyNotFoundException ex)
                {
                    Console.WriteLine("Invalid account!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

            }
        }
    }
}