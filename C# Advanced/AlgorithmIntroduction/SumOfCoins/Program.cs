﻿using System;

namespace SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int finalSum = 18;
            int currentSum = 0;
            int[] coins = new int[] { 10, 10, 5, 5, 2, 2, 1, 1 };
            Queue<int> resultCoins = new Queue<int>();

            for (int i = 0; i < coins.Length; i++)
            {
                if(currentSum + coins[i] > finalSum)
                {
                    continue;
                }
                currentSum += coins[i];
                resultCoins.Enqueue(coins[i]);
                
            }
            Console.WriteLine("Sum not found");
        }
    }
}