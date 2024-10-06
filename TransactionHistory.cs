using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankapplikation
{
    class TransactionHistory
    {
        public string FirstTransaction { get; set; }
        public string LastTransaction { get; set; }

        public void AddTransaction(string transaction)
        {
            string transactionEntry = $"{System.DateTime.Now}: {transaction}";
            if (FirstTransaction == null)
            {
                FirstTransaction = transactionEntry;
            }
            LastTransaction = transactionEntry;
        }
    }
}
