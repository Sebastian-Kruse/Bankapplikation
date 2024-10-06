using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bankapplikation
{
    class Account
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        public TransactionHistory TransactionHistory { get; set; }

        public Account(string accountNumber, string ownerName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = initialBalance;
            TransactionHistory = new TransactionHistory();
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            TransactionHistory.AddTransaction($"Deposit: +{amount} kr");
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            TransactionHistory.AddTransaction($"Withdraw: -{amount} kr");
        }
    }

}
