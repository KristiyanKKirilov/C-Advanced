using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions
{
    public class Promotions
    {
        public decimal GetPromotionPercentage(DayOfWeek dayOfWeek)
        {
            if(dayOfWeek == DayOfWeek.Saturday)
            {
                return 10;
            }
            else if(dayOfWeek == DayOfWeek.Monday)
            {
                return 25;
            }
            else if (dayOfWeek == DayOfWeek.Tuesday)
            {
                return 15;
            }

            return 0;
        }
    }
}
