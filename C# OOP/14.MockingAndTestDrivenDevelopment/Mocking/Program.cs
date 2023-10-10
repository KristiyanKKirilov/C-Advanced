using System;

namespace Promotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Promotions promotions = new();
            Console.WriteLine(promotions.GetPromotionPercentage(DayOfWeek.Monday));
        }
    }
}