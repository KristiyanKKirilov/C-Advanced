using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        public BankAccount(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; }
    }
}
